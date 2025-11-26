import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EpisodesResponse } from '../../../core/models/episodes-response';

@Injectable({
  providedIn: 'root',
})
export class EpisodesService {

  private http = inject(HttpClient);

  private readonly baseUrl = 'https://localhost:7149/api/episodes';

  getEpisodes(page: number = 1): Observable<EpisodesResponse> {
    return this.http.get<EpisodesResponse>(`${this.baseUrl}?page=${page}`);
  }

  searchEpisodes(name: string): Observable<EpisodesResponse> {
    return this.http.get<EpisodesResponse>(`${this.baseUrl}/search?name=${name}`);
  }
}
