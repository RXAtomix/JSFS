import ResponseBuilder from "./responseBuilder.js";

export default class JsonBuilder extends ResponseBuilder {

    constructor(request, response, url) {
        super(request, response,url);
    }

    buildHeader() {
        this.response.statusCode = 200;
        this.response.setHeader('Content-Type', 'application/json');
    }

    buildBody() {
        let searchParams = this.url.searchParams;
        var toPrint = {};
        for (let p of searchParams.keys()) {
            toPrint[p] = searchParams.get(p);
        }
        var deat = new Date();
        toPrint.date = deat.toJSON();
        this.response.write(JSON.stringify(toPrint));
    }

}