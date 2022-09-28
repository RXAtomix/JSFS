import Mobile from "./mobile";
import SaucerImage from "../assets/images/flyingSaucer-petit.png";
import Game from './game.js';

// Valeurs par défaut pour la taille des soucoupes
const SAUCER_WIDTH = 48;
const SAUCER_HEIGHT = 36;

// Valeurs de déplacement des soucoupes
const DELTA_X = -3;
const DELTA_Y = 0;

export default class Saucer extends Mobile {

    constructor (x, y){
        super(x, y, SaucerImage, SAUCER_WIDTH, SAUCER_HEIGHT, DELTA_X, DELTA_Y);
        this.falling = false;
    }

    getX(){
        return this.x;
    }

    getY(){
        return this.y;
    }

    move(game){
        if (this.x + this.deltaX <= -100) {     // -100 pour donner l'illusion que la soucoupe continue son chemin
            game.removeSaucer(this.cpt_saucer);
            game.downScore(1000);
            document.getElementById("score").textContent = game.getScore();
        }

        
        if (this.y + this.deltaY >= 400){
            game.removeSaucer(this.cpt_saucer);
        }
        

        else {
            this.x += this.deltaX;
            this.y += this.deltaY;

        }
    }

    fall(){

        this.deltaX = 0;
        this.deltaY = 3;
        this.falling = true;
    }
}
