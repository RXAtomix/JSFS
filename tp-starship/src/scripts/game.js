import MobileImage from '../images/ciel-nocturne.png';

import Saucer from "./saucer";
import Starship from "./starship";
import Shoot from "./shoot";

export default class Game {

    constructor(canvas) {
        this.canvas = canvas;
        this.ctx = this.canvas.getContext("2d");
        this.starship = new Starship(canvas, 40, (this.canvas.height / 2)); // Le vaisseau doit être à 40px de la gauche et centré verticalement
        this.saucer = [];                                                   // Le tableau des soucoupes Saucer est initialement vide.
        this.shoot = [];
        this.score = 0;
        this.cpt_shoot = 0;
        this.cpt_saucer = 0;
        this.raf = window.requestAnimationFrame(this.moveAndDraw.bind(this));
    }

    shoot_one(){
        let y = this.starship.y + 10;
        let x = this.starship.x + 30;
        this.shoot.push(new Shoot(x, y));
        this.cpt_shoot += 1;
    }

    keyDownActionHandler(event){
        switch (event.key){
            case "ArrowUp":
                this.starship.moveUp();
                break;
            case "Up":
                this.starship.moveUp();
                break;
            case "ArrowDown":
                this.starship.moveDown();
                break;
            case "Down":
                this.starship.moveDown();
                break;
            case " ":
                this.shoot_one();
                break;
            default:
                return;
        }
        event.preventDefault();
    }

    keyUpActionHandler(event) {
        switch (event.key) {
            case "ArrowUp":
                this.starship.stopMoving();
                break;
            case "ArrowDown":
                this.starship.stopMoving();
                break;
            default: return;
        }
        event.preventDefault();
    }

    moveAndDraw() {
        // Suppression de l'image
        this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);

        // Re-définition de la soucupe du joueur
        this.starship.draw(this.ctx);

        // Déplacement de la soucoupe du joueur
        this.starship.move(this.canvas);

        // Déplacement des soucoupes
        this.saucer.forEach(elt => elt.move(this));
        this.saucer = this.saucer.filter(elt => !this.starship.collisionWith(elt));
        this.saucer.forEach(elt => elt.draw(this.ctx));

        this.shoot.forEach(elt => elt.move(this));
        this.shoot.forEach(elt => elt.collisionWithAll(this.saucer, this));
        this.shoot.forEach(elt => elt.draw(this.ctx));

        // Demander un rafraichissement d'image
        this.raf = window.requestAnimationFrame(this.moveAndDraw.bind(this));

    }

    alea(a, b){
        const min = Math.ceil(a);
        const max = Math.floor(b);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    addSaucer() {
        console.log(this.saucer);
        const x = 1000;
        const y = this.alea(0, this.canvas.height - 48);
        this.saucer.push(new Saucer(x, y));
        this.cpt_saucer += 1;
        //console.log("Soucoupe ajoutée !", this.cpt);
    }

    removeSaucer(cpt) {
        //console.log(this.saucer);
        this.saucer.splice(cpt, 1);
        this.cpt_saucer -= 1;
        //console.log("Soucoupe supprimée !", this.saucer);
    }

    removeShoot(cpt){
        this.shoot.splice(cpt, 1);
        this.cpt_shoot -= 1;
        //console.log(this.shoot);
    }

    downScore(points){
        this.score -= points;
        console.log(this.score);
    }

    upScore(points){
        this.score += points;
        console.log(this.score);
    }

    getScore (){
        return this.score;
    }
    // modifyScore(this.score); TODO
}
