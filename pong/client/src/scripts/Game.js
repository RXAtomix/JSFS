import Ball from './Ball.js';
import Paddle from './Paddle.js';

const nb_but = 10;
/**
 * a Game animates a ball bouncing in a canvas
 */
export default class Game {

  #io;
  /**
   * build a Game
   *
   * @param  {Canvas} canvas the canvas of the game
   */
  constructor(canvas) {
    this.raf = null;
    this.canvas = canvas;
    this.ball = new Ball(this.canvas.width/2, this.canvas.height/2, this);
    this.paddleG = new Paddle(10,this.canvas.height/2,this);
    this.paddleD = new Paddle (this.canvas.width-37,this.canvas.height/2,this);
    this.poinst_playerG = 0;
    this.poinst_playerD = 0;
    this.begin = false;
    this.#io;
  }

  /** start this game animation */
  start() {
    this.#io = io ();
    this.#io.connect();
    this.change(this.#io);
    this.#io.emit('ball', this.ball.shiftX, this.ball.shiftY, this.ball.x, this.ball.y);
    this.#io.on ('changeSh', (shiftX, shiftY, x, y) => {this.ball.change_Sh(shiftX, shiftY, x, y)});
    this.#io.on ("nb", () => {
      this.#io.on('start', () => {this.moveAndDraw();});
    });
    this.#io.on('replay', () => {
      this.ball = new Ball(this.canvas.width/2, this.canvas.height/2, this);
      /*this.paddleG = new Paddle(10,this.canvas.height/2,this);
      this.paddleD = new Paddle (this.canvas.width-37,this.canvas.height/2,this);*/
      this.#io.emit('ball', this.ball.shiftX, this.ball.shiftY, this.ball.x, this.ball.y);
      this.#io.on ('changeSh', (shiftX, shiftY, x, y) => {this.ball.change_Sh(shiftX, shiftY, x, y)});
      this.moveAndDraw();
    });
  }

  stopgame () {
    window.cancelAnimationFrame(this.raf);
    this.#io.disconnect(true);
  }

  /** move then draw the bouncing ball */
  moveAndDraw() {
    const ctxt = this.canvas.getContext("2d");
    ctxt.clearRect(0, 0, this.canvas.width, this.canvas.height);
    // draw and move the ball
    this.ball.draw(ctxt);
    const res = this.ball.move();
    //draw the paddles
    this.paddleG.draw(ctxt);
    this.paddleG.move(this.canvas);
    this.paddleD.draw(ctxt);
    this.movePaddleD(this.#io);
    this.#io.emit("move",this.paddleG.get_y());
    if(res) {
      window.cancelAnimationFrame(this.raf);
    } else {
      this.raf = window.requestAnimationFrame(this.moveAndDraw.bind(this));
    }
  }

  keyDownActionHandler(event){
        switch (event.key){
            case "ArrowUp":
                this.paddleG.moveUp();
                this.#io.emit("move",this.paddleG.get_y());
                break;
            case "Up":
                this.paddleG.moveUp();
                this.#io.emit("move",this.paddleG.get_y());
                break;
            case "ArrowDown":
                this.paddleG.moveDown();
                this.#io.emit("move",this.paddleG.get_y());
                break;
            case "Down":
                this.paddleG.moveDown();
                this.#io.emit("move",this.paddleG.get_y());
                break;
            case " ":
                if(this.id == 1) {
                  if(this.begin) {
                    this.#io.emit('replay');
                  } else {
                    this.#io.emit('start');
                    this.begin = true;
                  }
                }
                break;
            default:
                return;
        }
        event.preventDefault();
    }

    keyUpActionHandler(event) {
        switch (event.key) {
            case "ArrowUp":
                this.paddleG.stopMoving();
                this.#io.emit("move",this.paddleG.get_y());
                break;
            case "ArrowDown":
                this.paddleG.stopMoving();
                this.#io.emit("move",this.paddleG.get_y());
                break;
            default: return;
        }
        event.preventDefault();
    }

    collision(shiftX, shiftY, x, y) {
      this.#io.emit('collision', shiftX, shiftY, x, y);
    }

    movePaddleD (socket){
      socket.on ('move', (y) => {
        this.paddleD.set_y(y)});
    }

    getPaddleG (){
      return this.paddleG;
    }

    getPaddleD(){
      return this.paddleD;
    }

    getCanvasWidth (){
      return this.canvas.height;
    }

    increase_points_playerG (){
      this.poinst_playerG ++;
      document.getElementById('score').innerHTML = "Your score is " + this.poinst_playerG;
    }

    increase_points_playerD (){
      this.poinst_playerD ++;
      document.getElementById('score').innerHTML = "Your score is " + this.poinst_playerG;
    }

    getio (){
      return this.#io;
    }

    change (socket){
      socket.on('first' , () => {
        document.getElementById('start').value = 'First player (click here to disconnect)';
        this.id = 1;
      });
      socket.on('second' , () => {
        document.getElementById('start').value = 'Second player (click here to disconnect)';
        this.id = 2;
      });
      socket.on('no' , () => {
        document.getElementById('start').value = 'Cannot connect';
      });
      socket.on('other', () =>{
        document.getElementById('start').value = 'You were disconnected cause your opponnent disconnect (click here to be able to reconnect)';
        this.stopgame();
      });
    }
}
