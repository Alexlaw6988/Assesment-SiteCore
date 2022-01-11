import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AssetService } from '../../core/services/api';
import { AssetModel } from '../../models';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  @ViewChild('actionTpl', { static: true }) actionTpl: TemplateRef<any>;
  @ViewChild('myModal') public myModal: ModalDirective;
  options = {}
  data = [];
  columns: any = {};
  asset:AssetModel= {} as AssetModel;
  constructor(private assetService: AssetService) { }
  ngOnInit(): void {
    this.assetService.getAllAssets$().subscribe(data => {
      this.data = data;
    });
    this.columns = [
      { key: 'fileName', title: 'File Name', width: 150, sorting: true },
      { key: 'mimeType', title: 'Mime Type', width: 300, sorting: true },
      { key: 'country', title: 'Country', width: 100, sorting: true, },
      { key: 'description', title: 'Description', width: 500, sorting: true, noWrap: { head: true, body: true } },
      { key: 'zip', title: '<div class="blue">Action</div>', align: { head: 'center', body: 'center' }, sorting: false, width: 80, cellTemplate: this.actionTpl }
    ];
    this.options = {
      rowClickEvent: true,
      rowPerPageMenu: [5, 10, 20, 30, 50, 100],
      rowPerPage: 10
    };
  }
  edit(row: AssetModel) {
    this.asset = row;
    this.myModal.show();
  }
}
