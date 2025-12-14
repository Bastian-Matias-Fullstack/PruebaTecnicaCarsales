import { Routes } from '@angular/router';
import { EpisodesList } from './features/episodes/pages/episodes-list/episodes-list';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'episodes',
    pathMatch: 'full',
  },
  {
    path: 'episodes',
    component: EpisodesList,
  },
];
