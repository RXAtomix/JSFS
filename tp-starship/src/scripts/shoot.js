import Mobile from './mobile';
import ShootImage from '../assets/images/tir.png';
import Saucer from './saucer';

// Déplacement des tirs
const DELTA_X = 8;
const DELTA_Y = 0;

const SHOOT_HEGHT = 8;
const SHOOT_WIDTH = 32;

export default class Shoot extends Mobile {

    constructor(x, y){
        super(x,y, ShootImage, SHOOT_WIDTH, SHOOT_HEGHT, DELTA_X, DELTA_Y);
    }

    collisionWithAll(saucers, game){
        saucers.forEach(elt => {
                if (this.collisionWith(elt) && !(elt.falling)){
                elt.fall();
                game.removeShoot(this.cpt_shoot);
                game.upScore(200);
                document.getElementById("score").textContent = game.getScore();
            };
        });
    }

    collisionWith(saucer) {
        let p1_X = Math.max(this.x, saucer.x);
        let p1_Y = Math.max(this.y, saucer.y);

        let p2_X = Math.min(this.x + SHOOT_WIDTH, saucer.x + saucer.width);
        let p2_Y = Math.min(this.y + SHOOT_WIDTH, saucer.y + saucer.height);

        return p1_X < p2_X && p1_Y < p2_Y;
    }

     move(game){
        if (this.x + this.deltaX >= 1000) {
            game.removeShoot(this.cpt_shoot);
        }
        else {
            this.x += this.deltaX;
        }
    }
}