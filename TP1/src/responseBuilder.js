export default class ResponseBuilder {

    #request;
    #response;
    #url;

    constructor(request, response, url) {
        this.#request = request;
        this.#response = response;
        this.#url = url;
    }

    get response() {
        return this.#response;
    }

    get request() {
        return this.#request;
    }

    get url() {
        return this.#url;
    }

    buildHeader() {
        
    }

    buildBody() {

    }

    buildFooter() {
        
    }

    buildResponse() {
        this.buildHeader();
        this.buildBody();
        this.buildFooter();
        this.#response.end();
    }

}