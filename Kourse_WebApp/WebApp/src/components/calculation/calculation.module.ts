import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { TableModule } from 'primeng/table';
import { GMapModule } from 'primeng/gmap';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CalculationComponent } from './calculation.component';
import { CalculationRoutingModule } from './calculation-routing.module';

@NgModule({
  declarations: [
    CalculationComponent
  ],
  imports: [
    CalculationRoutingModule,
    NgbModule,
    CommonModule,
    HttpClientModule,
    GMapModule,
    TableModule,
    MatProgressSpinnerModule
  ],
  providers: []
})
export class CalculationModule { }
