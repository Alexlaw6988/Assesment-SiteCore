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

  private putRequest<T>(URL: string,data : T) {
    return this.http.put(this.baseDataURL + URL,data, { headers: this.getHttpHeaders()});
  }
  private postRequest<T>(URL: string,data : T) {
    return this.http.post<T>(this.baseDataURL + URL,data, { headers: this.getHttpHeaders()});
  }
  private deleteRequest(URL: string) {
    return this.http.delete(this.baseDataURL + URL, { headers: this.getHttpHeaders()});
  }
  private patchRequest<T>(URL: string,data : T) {
    return this.http.patch<T>(this.baseDataURL + URL,data,{ headers: this.getHttpHeaders()});
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

  createAsset$(data:AssetModel){
    return this.postRequest<AssetModel>('/assets',data);
  }

  updateAsset$(data:AssetModel){
    return this.putRequest<AssetModel>('/assets',data);
  }

  patchAsset$(data:AssetModel){
    return this.patchRequest<AssetModel>('/assets',data);
  }

  deleteAsset$(id:number){
    return this.deleteRequest(`/assets/${id}`);
  }
  //#endregion

}
