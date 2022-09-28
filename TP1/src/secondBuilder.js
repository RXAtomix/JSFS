import HtmlBuilder from "./htmlBuilder.js";

export default class SecondBuilder extends HtmlBuilder {

    constructor(request, response) {
        super(request,response);
    }

    buildHeader() {
        this.response.statusCode = 200;
        super.buildHeader();
    }

    buildBody() {
        this.response.write("<p>Hi, you are actually on page <em>second</em></p>");
    }

}