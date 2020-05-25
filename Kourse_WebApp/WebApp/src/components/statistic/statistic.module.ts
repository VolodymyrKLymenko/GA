import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ChartModule } from 'primeng/chart';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';

import { StatisticComponent } from './statistic.component';
import { StatisticRoutingModule } from './statistic-routing.module';

@NgModule({
  declarations: [
    StatisticComponent
  ],
  imports: [
    StatisticRoutingModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TableModule,
    ChartModule,
    InputTextModule
  ],
  providers: []
})
export class StatisticModule { }
