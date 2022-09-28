import MoveState from "./movestate";
import Mobile from "./mobile";

import StarshipImageSrc from "../assets/images/vaisseau-ballon-petit.png";

// Taille du vaisseau du joueur
const STARSHIP_HEIGHT = 90;
const STARSHIP_WIDTH = 60;

export default class Starship extends Mobile {

    constructor(canvas, x, y, starship_height = STARSHIP_HEIGHT, starship_width = STARSHIP_WIDTH) {
        super(x,y, StarshipImageSrc, STARSHIP_WIDTH, STARSHIP_HEIGHT);
        this.canvas = canvas;
        this.ctx = this.canvas.getContext("2d"); // ctx est le contexte ici
        this.moving = null;
        this.shiftY = 0;
        this.draw(this.ctx);
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
        this.shiftY = -8;
        this.moving = MoveState.UP;
    }

    moveDown(){
        this.shiftY = +8;
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
            this.y = Math.min((box.height - this.height) + 50, this.y + this.shiftY);
        }
    }

    collisionWith(saucer) {
        let a1_X = this.x;
        let a1_Y = this.y;

        let a1_prime_X = saucer.getX();
        let a1_prime_Y = saucer.getY();

        let p1_X = Math.max(a1_X, a1_prime_X);
        let p1_Y = Math.max(a1_Y, a1_prime_Y);

        let a2_X = this.x + STARSHIP_HEIGHT;
        let a2_Y = this.y + STARSHIP_WIDTH;

        let a2_prime_X = saucer.getX() + saucer.width;
        let a2_prime_Y = saucer.getY() + saucer.height;

        let p2_X = Math.min(a2_X, a2_prime_X);
        let p2_Y = Math.min(a2_Y, a2_prime_Y);

        if (p1_X < p2_X && p1_Y < p2_Y) {
            return true;
        }
    }

    draw(ctx){
        ctx.drawImage(this.image, this.x, this.y);
    }
}
