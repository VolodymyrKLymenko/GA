import { Component } from '@angular/core';
import { LocationService } from 'src/core/location.service';
import { GABestRouteService } from 'src/core/ga-best-route-service/gabestroute.service';
import { Place, Route } from 'src/core/ga-best-route-service/route.model';
import { StatisticEntity } from 'src/core/models/statistic.model';
import { LoaderService, LoaderState } from 'src/core/loader/loader.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.styl']
})
export class AppComponent {
  public hasLoadedResources = false;
  private subscription: Subscription;

  public mapInitialized = false;
  public markerIconUrl: string;
  public options: any;
  public overlays: any[];
  public route: Route;
  public statisticEntities: StatisticEntity[] = [];

  private calculationCount = 0;
  private tempPlaces = []

  constructor(
    private locationService: LocationService,
    private loaderService: LoaderService,
    private gaBestRouteCalculation: GABestRouteService
  ) { }

  public ngOnInit(): void {
    this.options = {
      zoom: 12
    };

    this.setLoaderState();
    this.initializeLocation();

    this.overlays = [];
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

  private setLoaderState(): void {
    this.subscription = this.loaderService.loaderState
      .subscribe((state: LoaderState) => {
        this.hasLoadedResources = state.show;
      });
  }

  public CalculateRoute(): void {
    this.gaBestRouteCalculation.CalculateBestRoute(this.tempPlaces)
      .subscribe(route => {
        this.route = route;

        this.calculationCount = this.calculationCount + 1;
        this.statisticEntities.push(
          {
            id: this.calculationCount,
            distance: this.route.distance,
            durationInMilliseconds: this.route.durationInMilliseconds,
            generationsCount: this.route.generationsCount
          } as StatisticEntity
        )

        this.overlays = [];
        this.tempPlaces.forEach(place => {
          this.overlays.push(
            new google.maps.Marker({position: {lat: place.x, lng: place.y}, title:"Konyaalti", icon: this.markerIconUrl})
          )
        });
    
        for (let index = 0; index < this.route.route.length - 1; index++) {
          var place1 = this.route.route[index];
          var place2 = this.route.route[index + 1];
    
          this.overlays.push(
            new google.maps.Polyline({path: [{lat: place1.x, lng: place1.y},{lat: place2.x, lng: place2.y}], geodesic: true, strokeColor: '#FF0000', strokeOpacity: 0.5, strokeWeight: 2})
          );
        }
    
        place1 = this.route.route[0];
        place2 = this.route.route[this.route.route.length-1];
    
        this.overlays.push(
          new google.maps.Polyline({path: [{lat: place1.x, lng: place1.y},{lat: place2.x, lng: place2.y}], geodesic: true, strokeColor: '#FF0000', strokeOpacity: 0.5, strokeWeight: 2})
        );
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

    this.tempPlaces.push(
      { x: event.latLng.lat(), y: event.latLng.lng(), id: "001" } as Place,
    );
  }
}
