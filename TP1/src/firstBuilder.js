import HtmlBuilder from "./htmlBuilder.js";

export default class FirstBuilder extends HtmlBuilder {

    constructor(request, response,url) {
        super(request,response,url);
    }

    buildHeader() {
        this.response.statusCode = 200;
        super.buildHeader();
    }

    buildBody() {
        this.response.write('<p>Bonjour, vous vous trouvez bien sur la page <em class="ok">first</em></p>');
        this.response.write('<p><img src="./public/img/timoleon_oceanie.jpg" alt="timoleon bien sur"></p>');
    }

}