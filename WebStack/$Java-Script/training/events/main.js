"use strict"

const block = document.getElementsByClassName("block");
console.dir(block[0]);

const onClick = () => {
    console.log("Произошел кликандос");
}
block[0].addEventListener("dblclick", () => {
    console.log("Произошел двойной кликандос");
});
block[0].addEventListener("click", onClick);
block[0].addEventListener("mouseover", () => {
    console.log("ПОДОШЕЛ");
});
block[0].addEventListener("mouseleave", () => {
    console.log("ОТОШЕЛ");
});

const link = document.querySelector("a");
link.addEventListener("click", (event) => {
    event.preventDefault(); // ссылка схавала и не работает
    console.log("АГА, УЙТИ ЗАХОТЕЛ? СЮДА: " + event.target.getAttribute("href"));
    console.log("УЧИ СОБЫТИЯ, ШКОЛЬНИК");
    setTimeout(() => {
        const url = event.target.getAttribute("href");
        window.location = "https://developer.mozilla.org/ru/docs/Web/Events";
    }, 1200);
});


setTimeout(() => {
    block[0].style.width = "150px";
    block[0].style.height = "150px";
    block[0].style.backgroundColor = "#fff234";
}, 1000);
setTimeout(() => {
    block[0].style.width = "250px";
    block[0].style.height = "250px";
    block[0].style.backgroundColor = "black";
}, 1350);


