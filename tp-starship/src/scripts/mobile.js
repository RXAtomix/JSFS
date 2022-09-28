import MobileImage from '../images/ciel-nocturne.png';

// Pas de déplacement pour un objet Mobile
const DELTA_X = 0; // 0 par défaut
const DELTA_Y = 0; // 0 par défaut

// Taille du mobile par défaut
const MobileImg_Width = 40;

export default class Mobile {

	constructor (x, y, src, width, height, deltaX = DELTA_X, deltaY = DELTA_Y){
		this.x = x;
		this.y = y;
		this.src = src;
		this.height = height;
		this.width = width;
		this.deltaX = deltaX;
		this.deltaY = deltaY;
		this.image = this.createImage(width, src);
	}


	/** Draw an image with in the context.
	 * @param {context} context a context.
	 */
	draw(context){
			context.drawImage(this.image,this.x,this.y);
	}


	/** Create an image with a width, and a source image.
	 * 	@Return {Image} an image.
	 */
	createImage(width, src){
		const mobileImg = new Image();
		mobileImg.width = width;
		mobileImg.src = src;
		return mobileImg;
	}

	/** Move an object in the canvas.
	 * @param {canvas} the canvas.
	 */
	move(canvas){
		this.x -= this.deltaX;
		this.y += this.deltaY;
	}
}