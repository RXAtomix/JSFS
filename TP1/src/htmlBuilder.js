import ResponseBuilder from "./responseBuilder.js";

export default class HtmlBuilder extends ResponseBuilder {

    constructor(request, response,url) {
        super(request, response,url);
    }

    buildHeader() {
        this.response.setHeader('Content-Type', 'text/html');
        this.response.write('<html><head><link href="./public/style/style.css" rel="stylesheet" type="text/css"></head><body>');
    }

    buildBody() {

    }

    buildFooter() {
        const date = new Date();
        this.response.write('<footer>');
        this.response.write(date.toJSON());
        this.response.write('</footer></body></html>');
    }

}
