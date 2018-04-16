import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { UploadComponent } from '../upload/upload.component';
import { SharedModule } from '../shared';
import { SheetRoutingModule } from './sheet-routing.module';
import { SheetComponent } from './sheet.component';

@NgModule({
  imports: [
    SharedModule,
    SheetRoutingModule
  ],
  declarations: [
    SheetComponent,
  ]
})
export class SheetModule {}
