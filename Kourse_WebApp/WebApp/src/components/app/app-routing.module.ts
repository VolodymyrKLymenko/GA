import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StatisticModule } from '../statistic/statistic.module';
import { CalculationModule } from '../calculation/calculation.module';

const routes: Routes = [
  {
    path: 'statistic',
    loadChildren: () => StatisticModule
  },
  {
    path: 'calculation',
    loadChildren: () => CalculationModule
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
