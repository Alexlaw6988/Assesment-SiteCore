import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AssetModel } from '../../../models/assetModel';

@Injectable({
  providedIn: 'root'
})
export class AssetService{
  private readonly baseDataURL: string;

  constructor(
    private http: HttpClient,
  )
  {
    this.baseDataURL = 'api';
  }

  private getRequest<T>(URL: string) {
    return this.http.get<T>(this.baseDataURL + URL, { headers: this.getHttpHeaders()});
  }

  private getHttpHeaders(){
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
      'Pragma': 'no-cache'
    });
  }
  
  // #region Assets requests
  getAllAssets$(): Observable<AssetModel[]>{
    return this.getRequest<AssetModel[]>('/assets');
  }

}
