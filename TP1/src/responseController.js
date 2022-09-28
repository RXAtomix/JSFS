import { URL } from 'url';
import JsonBuilder from './jsonBuilder.js';
import RandomBuilder from './randomBuilder.js';
import FirstBuilder from './firstBuilder.js';
import SecondBuilder from './secondBuilder.js';
import ErrorBuilder from './errorBuilder.js';
import PublicBuilder from './publicBuilder.js';

export default class ResponseController {

    #request;
    #response;
    #url;

    constructor(request, response) {
        this.#request = request;
        this.#response = response;
        this.#url = new URL(request.url, 'http:${request.headers.host}');
    }

    get response() {
        return this.#response;
    }

    buildResponse() {
        if (this.#url.pathname.startsWith('/first')) {
            new FirstBuilder(this.#request, this.#response, this.#url).buildResponse();
        } else if (this.#url.pathname.startsWith('/second')) {
            new SecondBuilder(this.#request, this.#response, this.#url).buildResponse();
        } else if (this.#url.pathname.startsWith('/json')) {
            new JsonBuilder(this.#request, this.#response, this.#url).buildResponse();
        } else if (this.#url.pathname.startsWith('/random')) {
            new RandomBuilder(this.#request, this.#response, this.#url).buildResponse();
        } else if (this.#url.pathname.startsWith('/public')) {
            new PublicBuilder(this.#request, this.#response, this.#url).buildResponse();
        } else {
            new ErrorBuilder(this.#request, this.#response, this.#url).buildResponse();
        }
    }

}