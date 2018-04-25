import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { SheetService } from '../core/services/sheet.service';
import { SongService } from '../core/services/song.service';
import { Direction } from '../core/models/direction.model';
import { Point } from '../core/models/point.model';
import { Song } from '../core/models/song.model';


@Component({
  selector: 'sheet',
  templateUrl: './sheet.component.html',
  styleUrls: ['./sheet.component.css']
})
export class SheetComponent implements OnInit {
  constructor(
    private roter: Router,
    private sheetService : SheetService,
    private songService : SongService
  ) {}
  @Input()
  public selectedSong : string;
  public static instance : SheetComponent;
  ngOnInit() {
    this.showSearch(this.songService.getAll());
    SheetComponent.instance = this;
  }


  canvas: HTMLCanvasElement;
  ctx: CanvasRenderingContext2D;

  public showSearch(songs : Song[]) {


    // dialogRef.result
    //   .then( result => alert(`The result is: ${result}`) );
      
    this.canvas = <HTMLCanvasElement>document.getElementById('cnvs');
    this.ctx = this.canvas.getContext("2d");
    this.canvas.width = SheetService.SIZE;
    this.canvas.height = SheetService.SIZE; 
    this.renew();

    this.show(songs);
    this.waitForClick();
  }

  private drawArrow(direction : Direction, head : Point) {
      if (direction == Direction.Right) {
          this.ctx.moveTo(head.x, head.y);
          this.ctx.lineTo(head.x - SheetService.ARROW * 2, head.y - SheetService.ARROW / 2);
          this.ctx.moveTo(head.x, head.y);
          this.ctx.lineTo(head.x - SheetService.ARROW * 2, head.y + SheetService.ARROW / 2);
      }

      if (direction == Direction.Up) {
          this.ctx.moveTo(head.x, head.y);
          this.ctx.lineTo(head.x - SheetService.ARROW / 2, head.y + SheetService.ARROW * 2);
          this.ctx.moveTo(head.x, head.y);
          this.ctx.lineTo(head.x + SheetService.ARROW / 2, head.y + SheetService.ARROW * 2);
      }
  }

  private renew() {
      this.ctx.clearRect(0,0,SheetService.SIZE, SheetService.SIZE);
      this.ctx.fillStyle = SheetService.BACKGROUND_COLOR;
      this.ctx.fillRect(0,0, SheetService.SIZE, SheetService.SIZE);
      this.ctx.strokeStyle = SheetService.STROKE_COLOR;

      this.ctx.beginPath();
      this.ctx.moveTo(SheetService.PADDING, SheetService.SIZE / 2);
      this.ctx.lineTo(SheetService.SIZE -  SheetService.PADDING, SheetService.SIZE / 2);
      this.ctx.moveTo(SheetService.SIZE / 2, SheetService.PADDING);
      this.ctx.lineTo(SheetService.SIZE / 2, SheetService.SIZE - SheetService.PADDING);
    
      this.drawArrow(Direction.Up, new Point(SheetService.SIZE / 2, SheetService.PADDING));
      this.drawArrow(Direction.Right, new Point(SheetService.SIZE - SheetService.PADDING, SheetService.SIZE/2));
      
      this.ctx.stroke();   
  }

  public show(songs : Song[]) {
      SheetService.songs = songs;

      this.ctx.fillStyle = SheetService.STROKE_COLOR;
      songs.forEach(element => {
          this.ctx.beginPath();
          this.ctx.arc(
              SheetService.measure() * element.meanTempo + SheetService.SIZE / 2,
              SheetService.SIZE / 2 - SheetService.measure() * element.meanEnergy,
              SheetService.SONG_RADIUS, 0, 2 * Math.PI);
          this.ctx.fill();
      });
      this.ctx.fillStyle = SheetService.BACKGROUND_COLOR;
      this.canvas.onmousemove = <any>this.mouseMove;
  }

  private mouseMove(e : any) {
      
      this.canvas = <HTMLCanvasElement>document.getElementById('cnvs');
      this.ctx = this.canvas.getContext("2d");
      this.ctx.fillStyle = SheetService.DARK_STROKE_COLOR;

      var selSong = '';
      SheetService.songs.forEach(song => {
          var distanceX = song.meanTempo - (e.layerX - SheetService.SIZE / 2)  / SheetService.measure();
          var distanceY = song.meanEnergy - (SheetService.SIZE / 2 - e.layerY) / SheetService.measure();

          var distance = Math.sqrt(Math.pow(distanceX,2) + Math.pow(distanceY,2));
          if (distance <= SheetService.SONG_RADIUS) {
              this.ctx.fillStyle = SheetService.DARK_STROKE_COLOR;
              selSong = song.songTitle;
          } else 
          {
              this.ctx.fillStyle = SheetService.STROKE_COLOR;
          }
          this.ctx.beginPath();
          this.ctx.arc(
              song.meanTempo * SheetService.measure() + SheetService.SIZE / 2, 
              SheetService.SIZE/2 - song.meanEnergy * SheetService.measure(), 
              SheetService.SONG_RADIUS, 0, 2 * Math.PI);
          this.ctx.fill();
      });

    SheetComponent.setSong(selSong);
          
      this.ctx.fillStyle = SheetService.BACKGROUND_COLOR;
  }

  public waitForClick() {
      this.canvas.onclick = <any>this.mouseClick;
  }

  public static setSong(song : string) {
    SheetComponent.instance.selectedSong = song;
  }

  private mouseClick(e) {
      this.canvas = <HTMLCanvasElement>document.getElementById('cnvs');
      this.ctx = this.canvas.getContext("2d");
      this.ctx.fillStyle = SheetService.DARK_STROKE_COLOR;
      this.ctx.beginPath();
      this.ctx.arc(
          e.layerX, 
          e.layerY,
          SheetService.SONG_RADIUS + 5, 0, 2 * Math.PI);
      this.ctx.fill();
      
      this.ctx.fillStyle = SheetService.BACKGROUND_COLOR;
  }
}
