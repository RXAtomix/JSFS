import Mobile from './Mobile.js';
import BALL_IMAGE_SRC from '../images/balle24.png';


// default values for a Ball : image and shifts
const SHIFT_X = -8;
const SHIFT_Y = -4;
const val_strat = [-3,-2,-1,0,0,1,2,3];

/**
 * a Ball is a mobile with a ball as image and that bounces in a Game (inside the game's canvas)
 */
export default class Ball extends Mobile {

  /**  build a ball
   *
   * @param  {number} x       the x coordinate
   * @param  {number} y       the y coordinate
   * @param  {Game} theGame   the Game this ball belongs to
   */
  constructor(x, y, theGame) {
    super(x, y, BALL_IMAGE_SRC , SHIFT_X, SHIFT_Y);
    this.theGame = theGame;
  }


  /**
   * when moving a ball bounces inside the limit of its game's canvas
   */
  move() {
    if (this.y <= 0 || (this.y+this.height >= this.theGame.canvas.height)) {
      this.shiftY = - this.shiftY;    // rebond en haut ou en bas
    }
    else if (this.collisionWithPaddleG(this.theGame.getPaddleG())) {
      const coord_paddleG_y = this.theGame.getPaddleG().get_y();
      const pasG = this.theGame.getPaddleG().height / val_strat.length;
      const diff_g = this.y - coord_paddleG_y + 24;
      const strate_g = Math.floor(diff_g / pasG);
      this.shiftY += val_strat[strate_g];
      this.shiftX -= val_strat[strate_g];
      this.shiftX = - this.shiftX;
      this.theGame.collision(this.shiftX, this.shiftY, this.x, this.y);
    }
    super.move();
    if (this.x <= 0 || this.x + this.width >= this.theGame.canvas.width){
      this.shiftX = 0;
      this.shiftY = 0;
      if (this.x <= 0){
        this.theGame.increase_points_playerD();
      }
      else{
        this.theGame.increase_points_playerG();
      }
      this.x = this.tempx;
      this.y = this.tempy;
      this.theGame.getPaddleG().x = this.theGame.getPaddleG().tempx;
      this.theGame.getPaddleG().y = this.theGame.getPaddleG().tempy;
      return true;
    }
    return false;
  }

  collisionWithPaddleG (paddle){
    const coord_paddle_x = paddle.get_x();
    const coord_paddle_y_haut = paddle.get_y();
    const coord_paddle_y_bas = paddle.get_y () + paddle.height;
    if (this.x <= coord_paddle_x + paddle.width){
      if(this.y + this.height >= coord_paddle_y_haut && this.y <= coord_paddle_y_bas){
        return true;
      }
    }
    return false;
  }

  change_Sh (shiftX, shiftY, x, y) {
    this.shiftX = - shiftX;
    this.shiftY = shiftY;
    this.x = this.theGame.canvas.width - x;
    this.y = y;
  }

}
