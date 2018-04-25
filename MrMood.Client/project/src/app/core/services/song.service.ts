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
  
  getAll() {
    var response = this.apiService.getWithPath('http://localhost:1483/api/songs/1');

    response.subscribe(e =>{console.log(e.response);})

    return [];
  }

  getById(id : number): Song[] {
      return [];
      //return this.apiService.get('/api/songs/'+ id);
      
    // return this.apiService.get('/tags')
    //       .pipe(map(data => data.tags));
  }

}
