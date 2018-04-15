window.onload = function() {
    var sm = new SheetManager();
    sm.initialize();
    sm.show(
        [new Song("a", 10, 50),
        new Song("a", -10, 80),
        new Song("a", -10, -50),
        new Song("a", -10, 50)]
    );
    sm.waitForClick();
};

class SheetManager {
    
    private static SIZE : number = 600;
    private static BACKGROUND_COLOR = '#C3F5B3';
    private static STROKE_COLOR = '#657460';
    private static DARK_STROKE_COLOR = '#101e0f';
    private static PADDING = 10;
    private static SONG_RADIUS = 5;
    private static ARROW = 5;
    canvas: HTMLCanvasElement;
    ctx: CanvasRenderingContext2D;
    public static songs : Song[];

    public initialize() {
        this.canvas = <HTMLCanvasElement>document.getElementById('cnvs');
        this.ctx = this.canvas.getContext("2d");
        this.canvas.width = SheetManager.SIZE;
        this.canvas.height = SheetManager.SIZE; 
        this.renew();
  
    }

    private drawArrow(direction : Direction, head : Point) {
        if (direction == Direction.Right) {
            this.ctx.moveTo(head.x, head.y);
            this.ctx.lineTo(head.x - SheetManager.ARROW * 2, head.y - SheetManager.ARROW / 2);
            this.ctx.moveTo(head.x, head.y);
            this.ctx.lineTo(head.x - SheetManager.ARROW * 2, head.y + SheetManager.ARROW / 2);
        }

        if (direction == Direction.Up) {
            this.ctx.moveTo(head.x, head.y);
            this.ctx.lineTo(head.x - SheetManager.ARROW / 2, head.y + SheetManager.ARROW * 2);
            this.ctx.moveTo(head.x, head.y);
            this.ctx.lineTo(head.x + SheetManager.ARROW / 2, head.y + SheetManager.ARROW * 2);
        }
    }

    private renew() {
        this.ctx.clearRect(0,0,SheetManager.SIZE, SheetManager.SIZE);
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
        this.ctx.fillRect(0,0, SheetManager.SIZE, SheetManager.SIZE);
        this.ctx.strokeStyle = SheetManager.STROKE_COLOR;

        this.ctx.beginPath();
        this.ctx.moveTo(SheetManager.PADDING, SheetManager.SIZE / 2);
        this.ctx.lineTo(SheetManager.SIZE -  SheetManager.PADDING, SheetManager.SIZE / 2);
        this.ctx.moveTo(SheetManager.SIZE / 2, SheetManager.PADDING);
        this.ctx.lineTo(SheetManager.SIZE / 2, SheetManager.SIZE - SheetManager.PADDING);
      
        this.drawArrow(Direction.Up, new Point(SheetManager.SIZE / 2, SheetManager.PADDING));
        this.drawArrow(Direction.Right, new Point(SheetManager.SIZE - SheetManager.PADDING, SheetManager.SIZE/2));
        
        this.ctx.stroke();   
    }

    public show(songs : Song[]) {
        SheetManager.songs = songs;

        this.ctx.fillStyle = SheetManager.STROKE_COLOR;
        songs.forEach(element => {
            this.ctx.beginPath();
            this.ctx.arc(
                SheetManager.measure() * element.x + SheetManager.SIZE / 2,
                SheetManager.SIZE / 2 - SheetManager.measure() * element.y,
                SheetManager.SONG_RADIUS, 0, 2 * Math.PI);
            this.ctx.fill();
        });
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
        this.canvas.onmousemove = <any>this.mouseMove;
    }

    private mouseMove(e : any) {
        
        this.canvas = <HTMLCanvasElement>document.getElementById('cnvs');
        this.ctx = this.canvas.getContext("2d");
        this.ctx.fillStyle = SheetManager.DARK_STROKE_COLOR;
        SheetManager.songs.forEach(song => {
            var distanceX = song.x - (e.layerX - SheetManager.SIZE / 2)  / SheetManager.measure();
            var distanceY = song.y - (SheetManager.SIZE / 2 - e.layerY) / SheetManager.measure();

            var distance = Math.sqrt(Math.pow(distanceX,2) + Math.pow(distanceY,2));
            if (distance <= SheetManager.SONG_RADIUS) {
                this.ctx.fillStyle = SheetManager.DARK_STROKE_COLOR;
            } else 
            {
                this.ctx.fillStyle = SheetManager.STROKE_COLOR;
            }
            this.ctx.beginPath();
            this.ctx.arc(
                song.x * SheetManager.measure() + SheetManager.SIZE / 2, 
                SheetManager.SIZE/2 - song.y * SheetManager.measure(), 
                SheetManager.SONG_RADIUS, 0, 2 * Math.PI);
            this.ctx.fill();
        });
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
    }

    public waitForClick() {
        this.canvas.onclick = <any>this.mouseClick;
    }

    private mouseClick(e) {
        this.canvas = <HTMLCanvasElement>document.getElementById('cnvs');
        this.ctx = this.canvas.getContext("2d");
        this.ctx.fillStyle = SheetManager.DARK_STROKE_COLOR;
        this.ctx.beginPath();
        this.ctx.arc(
            e.layerX, 
            e.layerY,
            SheetManager.SONG_RADIUS + 5, 0, 2 * Math.PI);
        this.ctx.fill();
        
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
    }

    public static measure() {
        return SheetManager.SIZE / 200;
    }
}


enum Direction { Left, Up, Down, Right}

class Song {
    constructor(
        public name : string,
        public x : number,
        public y : number
    ) {
    }
}

class Point {
    
    constructor(
        public x : number,
        public y : number
    ){}
}