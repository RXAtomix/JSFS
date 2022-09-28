import JsonBuilder from "./jsonBuilder.js";

export default class RandomBuilder extends JsonBuilder {

    constructor(request, response, url) {
        super(request, response,url);
    }

    buildBody() {
        var toPrint = { "randomValue" : Math.floor(Math.random() * 100) };
        var deat = new Date();
        toPrint.date = deat.toJSON();
        this.response.write(JSON.stringify(toPrint));
    }

}