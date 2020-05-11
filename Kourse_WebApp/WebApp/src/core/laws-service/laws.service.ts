import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {
  Law,
} from './law.model';
import { ApiRoutes } from 'src/utilities/api-routes';

@Injectable({
  providedIn: 'root'
})
export class LawService {
  constructor(private http: HttpClient) {
  }

  public getGovernments(government: string): Observable<Law[]> {
    return this.http.get<Law[]>(`${ApiRoutes.laws}/${government}/bills-${government}.json`);
  }
}
