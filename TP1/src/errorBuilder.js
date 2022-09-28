import HtmlBuilder from "./htmlBuilder.js";

export default class ErrorBuilder extends HtmlBuilder {

    constructor(request, response, url) {
        super(request,response,url);
    }

    buildHeader() {
        this.response.statusCode = 400;
        super.buildHeader();
    }

    buildBody() {
        this.response.write(`<h1>404 : page ${this.url.pathname} not found</h1>`);
    }

}