import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgmCoreModule } from '@agm/core';
import { AgmDirectionModule } from 'agm-direction'; 

import { MapComponent } from './map.component';
import { MapRoutingModule } from './map-routing.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    MapComponent
  ],
  imports: [
    MapRoutingModule,
    CommonModule,
    HttpClientModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCDhjF3LNn2qqYUivCkiyYD8lQMAzihz7I'
      /* apiKey is required, unless you are a
      premium customer, in which case you can
      use clientId
      */
    }),
    AgmDirectionModule
  ]
})
export class MapModule { }
