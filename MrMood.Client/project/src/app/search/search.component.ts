import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SheetService } from '../core/services/sheet.service';
import { SongService } from '../core/services/song.service';
import { Direction } from '../core/models/direction.model';
import { Point } from '../core/models/point.model';
import { Song } from '../core/models/song.model';


@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  constructor(
  ) {}

  public song : string;
}
