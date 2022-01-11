import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { CRUD } from '../../core/enum/CRUD';
import { AssetService } from '../../core/services/api';
import { AssetModel } from '../../models';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit, OnDestroy {
  @ViewChild('actionTpl', { static: true }) actionTpl: TemplateRef<any>;
  @ViewChild('myModal') public myModal: ModalDirective;
  options = {}
  data = [];
  columns: any = {};
  asset: AssetModel = {} as AssetModel;
  action: CRUD = CRUD.VIEW;
  actions = CRUD;
  getSubsription: Subscription;
  createSubsription: Subscription;
  updateSubsription: Subscription;
  deleteSubsription: Subscription;
  editRow: AssetModel = {} as AssetModel;
  constructor(private assetService: AssetService, private toastr: ToastrService) {

  }
  ngOnInit(): void {
    this.initialise();
    this.columns = [
      { key: 'fileName', title: 'File Name', width: 150, sorting: true },
      { key: 'mimeType', title: 'Mime Type', width: 300, sorting: true },
      { key: 'country', title: 'Country', width: 100, sorting: true, },
      { key: 'description', title: 'Description', width: 500, sorting: true, noWrap: { head: true, body: true } },
      { key: 'action', title: '<div class="blue">Action</div>', align: { head: 'center', body: 'center' }, sorting: false, width: 170, cellTemplate: this.actionTpl }
    ];
    this.options = {
      rowClickEvent: true,
      rowPerPageMenu: [5, 10, 20, 30, 50, 100],
      rowPerPage: 10
    };
  }
  initialise() {
    this.getSubsription = this.assetService.getAllAssets$().subscribe(data => {
      this.data = data;
    });
  }
  onView(row: AssetModel) {
    this.asset = row;
    this.action = CRUD.VIEW;
    this.myModal.show();
  }
  onAdd() {
    this.asset = {} as AssetModel;
    this.action = CRUD.CREATE;
    this.myModal.show();
  }
  onEdit(row: AssetModel) {
    this.asset = this.createCopy(row);
    this.editRow = this.createCopy(row);
    this.action = CRUD.UPDATE;
    this.myModal.show();
  }
  createAsset() {
    this.createSubsription = this.assetService.createAsset$(this.asset).subscribe(data =>
      this.onSuccess("Asset created successfully")
    );
  }
  updateAsset() {
    this.updateSubsription = this.assetService.updateAsset$(this.asset).subscribe(data =>
      this.onSuccess("Asset updated successfully")
    );
  }
  onDelete(row: AssetModel) {
    if (window.confirm('Are sure you want to delete this item ?')) {
      this.deleteSubsription = this.assetService.deleteAsset$(row.id).subscribe(data =>
        this.onSuccess("Asset deleted successfully"));
    }
  }

  onReset() {
    this.asset = this.action === CRUD.UPDATE ? this.createCopy(this.editRow) : {} as AssetModel;
  }

  createCopy(obj: any) {
    return JSON.parse(JSON.stringify(obj));
  }

  onSuccess(message: string) {
    this.toastr.success(message);
    this.myModal.hide();
    this.initialise();
  }

  ngOnDestroy(): void {
    this.createSubsription?.unsubscribe();
    this.getSubsription?.unsubscribe();
    this.updateSubsription?.unsubscribe();
    this.deleteSubsription?.unsubscribe();
  }
}
