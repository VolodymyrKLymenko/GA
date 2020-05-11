import { Component, OnInit } from '@angular/core';

import { LocationService } from 'src/core/location.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.styl']
})
export class MapComponent implements OnInit {
  public latitude = 0;
  public longitude = 0;
  public markerIconUrl: string;

  constructor(
    private locationService: LocationService
  ) { }

  public ngOnInit(): void {
    this.initializeLocation();
  }

  public updateLocation(lat: number, long: number): void {
    this.longitude = long;
    this.latitude = lat;
  }

  private initializeLocation(): void {
    this.markerIconUrl = this.locationService.getMapIconUrl();

    if (this.locationService.userLatitude === null
      || this.locationService.userLongitude === null) {
        this.locationService.initializeLocation().subscribe(res => console.log('SAFASFASFASFA'));
    }

    this.longitude = this.locationService.userLongitude;
    this.latitude = this.locationService.userLatitude;

    console.log(this.longitude);
  }
}
