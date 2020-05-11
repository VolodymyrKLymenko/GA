import { Component } from '@angular/core';
import { LocationService } from 'src/core/location.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.styl']
})
export class AppComponent {
  public mapInitialized = false;
  public markerIconUrl: string;
  public options: any;
  public overlays: any[];

  constructor(
    private locationService: LocationService
  ) { }

  public ngOnInit(): void {
    this.options = {
      zoom: 12
    };

    this.initializeLocation();

    this.overlays = [
      new google.maps.Marker({position: {lat: 49.879466, lng: 23.897648}, title:"Konyaalti", icon: this.markerIconUrl}),
      new google.maps.Marker({position: {lat: 49.883707, lng: 23.899216}, title:"Ataturk Park", icon: this.markerIconUrl}),
      new google.maps.Marker({position: {lat: 49.885233, lng: 23.992323}, title:"Oldtown", icon: this.markerIconUrl}),

      new google.maps.Polyline({path: [{lat: 49.86149, lng: 23.89743},{lat: 49.86341, lng: 23.99463}, {lat: 46.86149, lng: 32.63743}], geodesic: true, strokeColor: '#FF0000', strokeOpacity: 0.5, strokeWeight: 2})
    ];
  }

  private initializeLocation(): void {
    this.markerIconUrl = this.locationService.getMapIconUrl();

    if (this.locationService.userLatitude === null
      || this.locationService.userLongitude === null) {
        this.locationService.initializeLocation();
    }

    window.navigator.geolocation.getCurrentPosition(location => {
      this.options.center = {
        lat: location.coords.latitude,
        lng: location.coords.longitude
      }

      this.mapInitialized = true;
    });
  }

  public handleMapClick(event): void {
    this.overlays.push(
      new google.maps.Marker(
      {
        position: {lat: event.latLng.lat(), lng: event.latLng.lng()},
        title:"Konyaalti",
        icon: this.markerIconUrl
      })
    );
  }
}
