window.onload = function () {
    var sm = new SheetManager();
    sm.initialize();
    sm.show([new Song("a", 10, 50),
        new Song("a", -10, 80),
        new Song("a", -10, -50),
        new Song("a", -10, 50)]);
    sm.waitForClick();
};
var SheetManager = (function () {
    function SheetManager() {
    }
    SheetManager.prototype.initialize = function () {
        this.canvas = document.getElementById('cnvs');
        this.ctx = this.canvas.getContext("2d");
        this.canvas.width = SheetManager.SIZE;
        this.canvas.height = SheetManager.SIZE;
        this.renew();
    };
    SheetManager.prototype.drawArrow = function (direction, head) {
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
    };
    SheetManager.prototype.renew = function () {
        this.ctx.clearRect(0, 0, SheetManager.SIZE, SheetManager.SIZE);
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
        this.ctx.fillRect(0, 0, SheetManager.SIZE, SheetManager.SIZE);
        this.ctx.strokeStyle = SheetManager.STROKE_COLOR;
        this.ctx.beginPath();
        this.ctx.moveTo(SheetManager.PADDING, SheetManager.SIZE / 2);
        this.ctx.lineTo(SheetManager.SIZE - SheetManager.PADDING, SheetManager.SIZE / 2);
        this.ctx.moveTo(SheetManager.SIZE / 2, SheetManager.PADDING);
        this.ctx.lineTo(SheetManager.SIZE / 2, SheetManager.SIZE - SheetManager.PADDING);
        this.drawArrow(Direction.Up, new Point(SheetManager.SIZE / 2, SheetManager.PADDING));
        this.drawArrow(Direction.Right, new Point(SheetManager.SIZE - SheetManager.PADDING, SheetManager.SIZE / 2));
        this.ctx.stroke();
    };
    SheetManager.prototype.show = function (songs) {
        var _this = this;
        SheetManager.songs = songs;
        this.ctx.fillStyle = SheetManager.STROKE_COLOR;
        songs.forEach(function (element) {
            _this.ctx.beginPath();
            _this.ctx.arc(SheetManager.measure() * element.x + SheetManager.SIZE / 2, SheetManager.SIZE / 2 - SheetManager.measure() * element.y, SheetManager.SONG_RADIUS, 0, 2 * Math.PI);
            _this.ctx.fill();
        });
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
        this.canvas.onmousemove = this.mouseMove;
    };
    SheetManager.prototype.mouseMove = function (e) {
        var _this = this;
        this.canvas = document.getElementById('cnvs');
        this.ctx = this.canvas.getContext("2d");
        this.ctx.fillStyle = SheetManager.DARK_STROKE_COLOR;
        SheetManager.songs.forEach(function (song) {
            var distanceX = song.x - (e.layerX - SheetManager.SIZE / 2) / SheetManager.measure();
            var distanceY = song.y - (SheetManager.SIZE / 2 - e.layerY) / SheetManager.measure();
            var distance = Math.sqrt(Math.pow(distanceX, 2) + Math.pow(distanceY, 2));
            if (distance <= SheetManager.SONG_RADIUS) {
                _this.ctx.fillStyle = SheetManager.DARK_STROKE_COLOR;
            }
            else {
                _this.ctx.fillStyle = SheetManager.STROKE_COLOR;
            }
            _this.ctx.beginPath();
            _this.ctx.arc(song.x * SheetManager.measure() + SheetManager.SIZE / 2, SheetManager.SIZE / 2 - song.y * SheetManager.measure(), SheetManager.SONG_RADIUS, 0, 2 * Math.PI);
            _this.ctx.fill();
        });
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
    };
    SheetManager.prototype.waitForClick = function () {
        this.canvas.onclick = this.mouseClick;
    };
    SheetManager.prototype.mouseClick = function (e) {
        this.canvas = document.getElementById('cnvs');
        this.ctx = this.canvas.getContext("2d");
        this.ctx.fillStyle = SheetManager.DARK_STROKE_COLOR;
        this.ctx.beginPath();
        this.ctx.arc(e.layerX, e.layerY, SheetManager.SONG_RADIUS + 5, 0, 2 * Math.PI);
        this.ctx.fill();
        this.ctx.fillStyle = SheetManager.BACKGROUND_COLOR;
    };
    SheetManager.measure = function () {
        return SheetManager.SIZE / 200;
    };
    SheetManager.SIZE = 600;
    SheetManager.BACKGROUND_COLOR = '#C3F5B3';
    SheetManager.STROKE_COLOR = '#657460';
    SheetManager.DARK_STROKE_COLOR = '#101e0f';
    SheetManager.PADDING = 10;
    SheetManager.SONG_RADIUS = 5;
    SheetManager.ARROW = 5;
    return SheetManager;
})();
var Direction;
(function (Direction) {
    Direction[Direction["Left"] = 0] = "Left";
    Direction[Direction["Up"] = 1] = "Up";
    Direction[Direction["Down"] = 2] = "Down";
    Direction[Direction["Right"] = 3] = "Right";
})(Direction || (Direction = {}));
var Song = (function () {
    function Song(name, x, y) {
        this.name = name;
        this.x = x;
        this.y = y;
    }
    return Song;
})();
var Point = (function () {
    function Point(x, y) {
        this.x = x;
        this.y = y;
    }
    return Point;
})();
