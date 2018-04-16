import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from './api.service';
import { map } from 'rxjs/operators/map';
import { Song } from '../models/song.model';

@Injectable()
export class SongService {
  constructor (
    private apiService: ApiService
  ) {}

  getAll(): Song[] {
    
      return [new Song('t', 12, 31, 1,'artist', 322, 'filename', ['123'])];
    // return this.apiService.get('/tags')
    //       .pipe(map(data => data.tags));
  }

}
