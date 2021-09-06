class HtmlComponent{
    constructor(info){
        this.query = info.query;
        this.color = info.color;
        this.height = info.height;
        this.width = info.width;
        this.#initComponent();
    }
    #initComponent(){
        const component = this.#getComponentByQuery(this.query);
        component.style.background = this.color;
        component.style.height = this.height;
        component.style.width = this.width;
        this.component = component;
    }
    #getComponentByQuery(){
        return document.querySelector(this.query);
    }
    show(){
        const comp = this.#getComponentByQuery();
        comp.style.display = "block";
    }
    hide(){
        const comp = this.#getComponentByQuery();
        comp.style.display = "none";
    }
}

class Card extends HtmlComponent{
    constructor(info){
        super(info);
        this.header = info.header;
        this.text = info.text;
    }
    #initComponent(){
    }
}

function createHtmlTemplate(_query, _color = "gray", _height = "120px", _width = "120px"){
    const baseTemplate = {
        query: _query,
        color: _color,
        height: _height,
        width: _width
    }
    return baseTemplate;
}

function getContentBody(){
    return document.querySelector(".body-content");
}
function setRowDisplay(comp){
    comp.style.display = "Flex";
}

const body = getContentBody();
setRowDisplay(body);

const grayTemplate = createHtmlTemplate("#comp-1");
const firstComponent = new HtmlComponent(grayTemplate);
firstComponent.show();

const blackTemplate = createHtmlTemplate("#comp-2", "black", "250px", "280px");
const secondComponent = new HtmlComponent(blackTemplate);
secondComponent.show();

const cardTemplate = createHtmlTemplate("#comp-3", "lightGray");
cardTemplate.height = "450px";
cardTemplate.width = "320px";
const card = new Card(cardTemplate);
card.show();
