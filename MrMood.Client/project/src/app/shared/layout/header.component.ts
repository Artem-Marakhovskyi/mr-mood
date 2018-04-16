import { Component, OnInit } from '@angular/core';

import { Modal } from 'ngx-modialog/plugins/bootstrap';
import { User, UserService } from '../../core';
import { SheetService } from '../../core/services/sheet.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-layout-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {
  constructor(
    private router : Router
  ) {}

  ngOnInit() {
    
  }

  search() {
    this.router.navigate(['/sheet']);
  }

  upload() {
    this.router.navigate(['/upload']); 
  }

}
