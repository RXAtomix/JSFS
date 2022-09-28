import ResponseBuilder from './responseBuilder.js';
import { readFileSync } from 'fs';

export default class PublicBuilder extends ResponseBuilder {

    constructor(request, response,url) {
        super(request, response, url);
    }

    buildHeader() {
        this.response.statusCode = 200;
        this.response.setHeader('Content-Type', 'text/plain');
    }

    buildBody() {
        try {
            this.response.write(readFileSync(`.${this.url.pathname}`));
        } catch(error) {
            this.response.statusCode = 404;
        }
    }

}