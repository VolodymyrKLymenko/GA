import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {
  Governaments,
  Governament,
} from './governaments.model';
import { ApiRoutes } from 'src/utilities/api-routes';

@Injectable({
  providedIn: 'root'
})
export class GovernmentService {
  constructor(private http: HttpClient) {
  }

  public getGovernments(): Observable<Governaments> {
    return this.http.get<Governaments>
          (`${ApiRoutes.governments}`);
  }
}
