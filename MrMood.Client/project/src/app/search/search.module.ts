import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../shared';
import { SheetComponent } from '../sheet/sheet.component';
import { SearchRoutingModule } from './search-routing.module';


@NgModule({
  imports: [
    SharedModule,
    SearchRoutingModule
  ],
  declarations: [
    SheetComponent
  ]
})
export class SearchModule {}
