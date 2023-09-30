import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import {
  IsoscelesTriangle,
  ScaleneTriangle,
  EquilateralTriangle,
  Rectangle,
  Square,
  Parallelogram,
  Pentagon,
  Hexagon,
  Heptagon,
  Octagon,
  Circle
} from '../shape-generator/shape-generator';

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
  sendIsoscelesTriangle(data: any): Observable<IsoscelesTriangle> {
    var url = this.getUrl('api/ShapeGenerator/GetIsoscelesTriangle');
    var params = new HttpParams()
      .set('sideLength', data.sideLength)
      .set('baseLength', data.baseLength);
    return this.http.get<IsoscelesTriangle>(url, { params });
  }

  // send request to backend to get the IsoscelesTriangle info
  sendScaleneTriangle(data: any): Observable<ScaleneTriangle> {
    var url = this.getUrl('api/ShapeGenerator/GetScaleneTriangle');
    var params = new HttpParams()
      .set('aSide', data.aSide)
      .set('bSide', data.bSide)
      .set('cSide', data.cSide);
    return this.http.get<ScaleneTriangle>(url, { params });
  }

  // send request to backend to get the EquilateralTriangle info
  sendEquilateralTriangle(data: any): Observable<EquilateralTriangle> {
    var url = this.getUrl('api/ShapeGenerator/GetEquilateralTriangle');
    var params = new HttpParams()
      .set('sideLength', data.sideLength);
    return this.http.get<EquilateralTriangle>(url, { params });
  }

  // send request to backend to get the Rectangle info
  sendRectangle(data: any): Observable<Rectangle> {
    var url = this.getUrl('api/ShapeGenerator/GetRectangle');
    var params = new HttpParams()
      .set('length', data.length)
      .set("width", data.width);
    return this.http.get<Rectangle>(url, { params });
  }

  // send request to backend to get the square info
  sendSquare(data: any): Observable<Square> {
    var url = this.getUrl('api/ShapeGenerator/GetSquare');
    var params = new HttpParams()
      .set('sideLength', data.sideLength);
    return this.http.get<Square>(url, { params });
  }

  // send request to backend to get the parallelogram info
  sendParallelogram(data: any): Observable<Parallelogram> {
    var url = this.getUrl('api/ShapeGenerator/GetParallelogram');
    var params = new HttpParams()
      .set('height', data.height)
      .set('sideLength', data.sideLength)
    return this.http.get<Parallelogram>(url, { params });
  }

  // send request to backend to get the pentagon info
  sendPentagon(data: any): Observable<Pentagon> {
    var url = this.getUrl('api/ShapeGenerator/GetPentagon');
    var params = new HttpParams()
      .set('sideLength', data.sideLength);
    return this.http.get<Pentagon>(url, { params });
  }

  // send request to backend to get the hexagon info
  sendHexagon(data: any): Observable<Hexagon> {
    var url = this.getUrl('api/ShapeGenerator/GetHexagon');
    var params = new HttpParams()
      .set('sideLength', data.sideLength);
    return this.http.get<Hexagon>(url, { params });
  }

  // send request to backend to get the heptagon info
  sendHeptagon(data: any): Observable<Heptagon> {
    var url = this.getUrl('api/ShapeGenerator/GetHeptagon');
    var params = new HttpParams()
      .set('sideLength', data.sideLength);
    return this.http.get<Heptagon>(url, { params });
  }

  // send request to backend to get the octagon info
  sendOctagon(data: any): Observable<Octagon> {
    var url = this.getUrl('api/ShapeGenerator/GetOctagon');
    var params = new HttpParams()
      .set('sideLength', data.sideLength);
    return this.http.get<Octagon>(url, { params });
  }

  // send request to backend to get the circle info
  sendCirlce(data: any): Observable<Circle> {
    var url = this.getUrl('api/ShapeGenerator/GetCircle');
    var params = new HttpParams()
      .set('diameter', data.diameter);
    return this.http.get<Circle>(url, { params });
  }
}
