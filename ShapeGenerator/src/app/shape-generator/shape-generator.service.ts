import { Injectable } from '@angular/core';
import { IsoscelesTriangle, ScaleneTriangle } from '../shape-generator/shape-generator';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class ShapeGeneratorService {

  constructor(
    private http: HttpClient
  ) {}

  getUrl(url: string) {
    return environment.baseUrl + url;
  }

  // send request to backend to get the IsoscelesTriangle info
  getIsoscelesTriangle(data : any): Observable<IsoscelesTriangle> {
    var url = this.getUrl('api/ShapeGenerator/GetIsoscelesTriangle');
    var params = new HttpParams()
      .set('sideLength', data.sideLength)
      .set('baseLength', data.baseLength);
    return this.http.get<IsoscelesTriangle>(url, { params });
  }

  // send request to backend to get the IsoscelesTriangle info
  getScaleneTriangle(data: any): Observable<ScaleneTriangle> {
    var url = this.getUrl('api/ShapeGenerator/GetScaleneTriangle');
    var params = new HttpParams()
      .set('aSide', data.aSide)
      .set('bSide', data.bSide)
      .set('cSide', data.cSide);
    return this.http.get<ScaleneTriangle>(url, { params });
  }
}
