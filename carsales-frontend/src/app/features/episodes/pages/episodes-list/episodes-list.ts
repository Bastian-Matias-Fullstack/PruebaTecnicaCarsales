import { Component, inject, signal } from '@angular/core';
import { EpisodesService } from '../../services/episodes';
import { Episode } from '../../../../core/models/episode';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-episodes-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './episodes-list.html',
  styleUrls: ['./episodes-list.scss'],
})
export class EpisodesList {
  private episodesService = inject(EpisodesService);

  episodes = signal<Episode[]>([]);
  loading = signal(true);
  error = signal<string | null>(null);

  currentPage = signal(1);
  totalPages = signal(1);
  totalCount = signal(0);

  searchTerm = signal('');
  isSearching = signal(false);

  constructor() {
    this.loadEpisodes();
  }

  loadEpisodes(page: number = 1): void {
    this.loading.set(true);
    this.error.set(null);
    this.episodesService.getEpisodes(page).subscribe({
      next: (response) => {
        this.episodes.set(response.results);
        this.currentPage.set(page);
        this.totalPages.set(response.info.pages);
        this.totalCount.set(response.info.count);
        this.isSearching.set(false);
        this.loading.set(false);
      },
      error: () => {
        this.error.set('No se pudo conectar con el servidor. Intenta nuevamente en unos segundos.');
        this.loading.set(false);
      },
    });
  }
  // Helpers botones
  canGoPrev(): boolean {
    return this.currentPage() > 1;
  }

  canGoNext(): boolean {
    return this.currentPage() < this.totalPages();
  }

  goToPrev(): void {
    if (this.canGoPrev()) {
      this.loadEpisodes(this.currentPage() - 1);
    }
  }

  goToNext(): void {
    if (this.canGoNext()) {
      this.loadEpisodes(this.currentPage() + 1);
    }
  }

  onSearch(): void {
    const term = this.searchTerm().trim();

    // Si se limpia el campo, volvemos al listado normal
    if (!term) {
      this.isSearching.set(false);
      this.loadEpisodes(1);
      return;
    }

    this.loading.set(true);
    this.error.set(null);
    this.isSearching.set(true);

    this.episodesService.searchEpisodes(term).subscribe({
      next: (response) => {
        this.episodes.set(response.results);
        this.totalPages.set(1);
        this.currentPage.set(1);
        this.totalCount.set(response.info?.count ?? response.results.length);
        this.loading.set(false);
      },
      error: () => {
        this.error.set('Error al buscar episodios');
        this.loading.set(false);
      },
    });
  }
}
