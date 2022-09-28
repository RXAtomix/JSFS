import Mobile from './Mobile.js';
import MoveState from "./moveState";
import PADDLE_IMAGE_SRC from '../images/paddle.png';

// default values for a paddle : image and shifts
const SHIFT_X = 0;
const SHIFT_Y = 5;

/**
 * a paddle is a mobile with a paddle as image and that bounces in a Game (inside the game's canvas)
 */
export default class Paddle extends Mobile {

  /**  build a paddle
   *
   * @param  {number} x       the x coordinate
   * @param  {number} y       the y coordinate
   * @param  {Game} theGame   the Game this paddle belongs to
   */
  constructor(x, y, theGame) {
    super(x, y, PADDLE_IMAGE_SRC , SHIFT_X, SHIFT_Y);
    this.theGame = theGame;
    this.moving = null;
  }


  /**
   * when moving a paddle can only go up and down
   */
  move(direction) {
    if (direction == "up"){
      this.shiftY = - this.shiftY;
    }
    else if (direction == "down"){
      this.shiftY = + this.shiftY;
    }
    super.move();
  }

  up(){
    if (MoveState === MoveState.UP)
      return true;
  }

  down(){
    if (MoveState === MoveState.DOWN)
      return true;
  }

  moveUp(){
        this.shiftY = -SHIFT_Y;
        this.moving = MoveState.UP;
  }

  moveDown(){
    this.shiftY = +SHIFT_Y;
    this.moving = MoveState.DOWN;
  }

  stopMoving(){
    this.moving = MoveState.NONE;
  }

  move(box){
    if (this.moving === MoveState.UP){
      this.y = Math.max(0, this.y + this.shiftY);
    }
    if (this.moving === MoveState.DOWN){
      this.y = Math.min((box.height - this.height), this.y + this.shiftY);
    }
  }

  get_x (){
    return this.x;
  }

  get_y (){
    return this.y;
  }

  set_y (new_y){
    this.y = new_y;
  }

}
