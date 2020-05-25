import { Component } from '@angular/core';

import { Subscription } from 'rxjs';

import { LocationService } from 'src/core/location.service';
import { GABestRouteService } from 'src/core/ga-best-route-service/gabestroute.service';
import { Place, Route } from 'src/core/ga-best-route-service/route.model';
import { StatisticEntity } from 'src/core/models/statistic.model';
import { LoaderService, LoaderState } from 'src/core/loader/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.styl']
})
export class AppComponent {
  public hasLoadedResources = false;
  private subscription: Subscription;

  constructor(
    private loaderService: LoaderService
  ) { }

  public ngOnInit(): void {
    this.setLoaderState();
  }

  private setLoaderState(): void {
    this.subscription = this.loaderService.loaderState
      .subscribe((state: LoaderState) => {
        this.hasLoadedResources = state.show;
      });
  }
}
