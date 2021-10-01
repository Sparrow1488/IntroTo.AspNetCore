$(document).ready(function () {
    const loginMenu = $(".header__login nav");
    const lowerCookies = document.cookie.toLowerCase();
    if(lowerCookies.includes("login")){
        console.log("Login includes");
        let helloUserBlock = $("<h3>Hello USER!!!!</h3>");
        helloUserBlock.toggleClass("title");
        helloUserBlock.css({ color: "white" });
        loginMenu.html(helloUserBlock);
    }
});