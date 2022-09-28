const UP = Symbol('UP');
const DOWN = Symbol('DOWN');
const LEFT = Symbol('LEFT');
const RIGHT = Symbol("RIGHT");

export default class MoveState{

    static get UP() {return UP;}
    static get DOWN() {return DOWN;}
    static get LEFT() {return LEFT;}
    static get RIGHT() {return RIGHT;}

}