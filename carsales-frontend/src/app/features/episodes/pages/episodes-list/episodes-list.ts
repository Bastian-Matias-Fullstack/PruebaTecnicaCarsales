import { Component, inject } from '@angular/core';
import { EpisodesService } from '../../services/episodes';
import { Episode } from '../../../../core/models/episode';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';  


@Component({
  selector: 'app-episodes-list',
  standalone: true,
  imports: [CommonModule,
  FormsModule]   ,    
  templateUrl: './episodes-list.html',
styleUrls: ['./episodes-list.scss'],

})
export class EpisodesList {

  private episodesService = inject(EpisodesService);

  episodes: Episode[] = [];
  loading = true;
  error: string | null = null;

  currentPage = 1;
  totalPages = 1;
  totalCount = 0;

  searchTerm = '';
  isSearching = false;

  constructor() {
    this.loadEpisodes();
  }

loadEpisodes(page: number = 1): void {
  this.loading = true;
  this.error = null;

  this.episodesService.getEpisodes(page).subscribe({
    next: (response) => {
      this.episodes = response.results;

      this.currentPage = page;
      this.totalPages = response.info.pages;
      this.totalCount = response.info.count;

      this.isSearching = false;
      this.loading = false;
    },
    error: () => {
      this.error = 'Error al obtener los episodios';
      this.loading = false;
    }
  });
  }
   //  helpers para los botones
  canGoPrev(): boolean {
    return this.currentPage > 1;
  }

  canGoNext(): boolean {
    return this.currentPage < this.totalPages;
  }

  goToPrev(): void {
    if (this.canGoPrev()) {
      this.loadEpisodes(this.currentPage - 1);
    }
  }

  goToNext(): void {
    if (this.canGoNext()) {
      this.loadEpisodes(this.currentPage + 1);
    }
  }
   onSearch(): void {
    const term = this.searchTerm.trim();

    if (!term) {
      // Si limpiamos el texto, volvemos al listado normal página 1
      this.isSearching = false;
      this.loadEpisodes(1);
      return;
    }

    this.loading = true;
    this.error = null;
    this.isSearching = true;

    this.episodesService.searchEpisodes(term).subscribe({
      next: (response) => {
        this.episodes = response.results;
        // En modo búsqueda no usamos paginación del backend (por ahora)
        this.totalPages = 1;
        this.currentPage = 1;
        this.totalCount = response.info?.count ?? response.results.length;
        this.loading = false;
      },
      error: () => {
        this.error = 'Error al buscar episodios';
        this.loading = false;
      }
    });
  }
}

