import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ModalModule } from 'ngx-modialog';
import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import {
  FooterComponent,
  HeaderComponent,
  SharedModule
} from './shared';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { BootstrapModalModule } from 'ngx-modialog/plugins/bootstrap';
import { SheetService } from './core/services/sheet.service';
import { SheetComponent } from './sheet/sheet.component';
import { SheetRoutingModule } from './sheet/sheet-routing.module';
import { SongService } from './core/services/song.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, FooterComponent, HeaderComponent, SheetComponent],
  imports: [
    BrowserModule,
    CoreModule,
    SharedModule,
    FormsModule,
    HomeModule,
    ModalModule.forRoot(),
    BootstrapModalModule,
    AppRoutingModule,
    SheetRoutingModule
  ],
  providers: [
    SheetService, SongService],
  bootstrap: [AppComponent]
})
export class AppModule {}
