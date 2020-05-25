import { Time } from '@angular/common';

export class StatisticEntity {
    id: number;
    distance: number;
    durationInMilliseconds: number;
    generationsCount: number;
}

export class CalculationStatistic {
  amountOfData: number;
  duration: Time
}
