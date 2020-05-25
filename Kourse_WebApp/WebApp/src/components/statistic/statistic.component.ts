import { Component, OnInit, ViewChild } from '@angular/core';

import { GABestRouteService } from 'src/core/ga-best-route-service/gabestroute.service';
import { UIChart } from 'primeng/chart/chart';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.styl']
})
export class StatisticComponent implements OnInit {
  public data: any;
  public inputData: string = "100, 200, 300";

  private datasets: any[] = [];
  private countOfCharts = 0;

  constructor(
    private gaBestRouteCalculation: GABestRouteService
  ) { }

  ngOnInit(): void {
  }

  public update(event: Event): void {
    this.rebuildGraphic();
  }

  private rebuildGraphic(): void {
    this.gaBestRouteCalculation.CalculateStatistic(this.inputData.split(', ').map(e => +e))
      .subscribe(result => {
        console.log(result);
        var labels = [];
        var datas = [];

        result.forEach(statistic => {
          labels.push(statistic.amountOfData);
          datas.push(statistic.duration);
        });

        this.datasets.push(
          {
            label: 'First Dataset',
            data: datas,
            fill: false,
            borderColor: '#'+(0x1000000+(Math.random())*0xffffff).toString(16).substr(1,6)
          }
        );

        this.data = {
          labels: labels,
          datasets: this.datasets
        };
      });
  }
}
