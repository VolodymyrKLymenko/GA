import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapModule } from '../map/map.module';

const routes: Routes = [
  {
    path: 'map',
    loadChildren: () => MapModule
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
