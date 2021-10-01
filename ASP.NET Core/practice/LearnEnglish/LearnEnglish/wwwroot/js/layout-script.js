function getLogin(){
    const cookies = document.cookie;
    const findKey = "Login";
    let result = null;
    if(cookies.includes(findKey)){
        cookies.split(";").forEach(element => {
            if(element.includes(findKey)){
                element = element.replace(findKey, " ").replace("=", " ").trim();
                result = element;
            }
        });
    }
    return result;
}

$(document).ready(function () {
    const loginMenu = $(".header__login nav");
    const cookieLogin = getLogin();
    if(cookieLogin){
        let helloUserBlock = $(`<h3>Hello, ${cookieLogin}!</h3>`);
        helloUserBlock.toggleClass("title");
        helloUserBlock.css({ color: "white" });
        loginMenu.html(helloUserBlock);
    }
});