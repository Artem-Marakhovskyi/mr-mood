
import { Injectable } from '@angular/core';
import { Song } from '../models/song.model';
import { Direction } from '../models/direction.model';
import { Point } from '../models/point.model';

@Injectable()
export class SheetService {

    public static SIZE : number = 600;
    public static BACKGROUND_COLOR = '#C3F5B3';
    public static STROKE_COLOR = '#657460';
    public static DARK_STROKE_COLOR = '#101e0f';
    public static PADDING = 10;
    public static SONG_RADIUS = 5;
    public static ARROW = 5;
    public static songs : Song[];

    constructor(
    ) {
    }

    public static measure() {
        return SheetService.SIZE / 200;
    }

}