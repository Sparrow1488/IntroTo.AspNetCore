// Hello world
let word = "Hello Джава-скрипт ебаный";
console.log(word);

// Работа с html
let element = document.getElementById("id-num");
element.hidden = true;
let btn = document.getElementById("send-data-btn");
btn.addEventListener("click", () => {
    alert("[Server]: Data received");
});

// Объекты
const man = {
    name: "Man",
    age: 28,
    sex: "Male"
}
console.log(man);

//  Работа со строками
let row = "Just string";
console.log(`Input row: ${row}`);

// Работа с числами
const stringParse = "2";
const parsedString = Number.parseInt(stringParse);
console.log("Parsed string to Int: " + parsedString);
let numArray = [ 12, 14, 18, 22, 24, 35, 99 ];
let maxNum = Math.max(numArray);
console.log(`The large num of ${numArray} is ${maxNum}`); // ДЖАБА СКРИПТ СОСЕТ МОЮ БОЛЬШУЮ БИБУ


