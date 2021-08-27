// HELLO WORLD
let word = "Hello Джава-скрипт ебаный";
console.log(word);



// РАБОТА С HTML
let element = document.getElementById("id-num");
element.hidden = true;
let btn = document.getElementById("send-data-btn");
btn.addEventListener("click", () => {
    alert("[Server]: Data received");
});



// ОБЪЕКТЫ
const man = {
    name: "Man",
    age: 28,
    sex: "Male"
}
console.log(man);



//  РАБОТА СО СТРОКАМИ
let row = "Just string";
console.log(`Input row: ${row}`);



// РАБОТА С ЧИСЛАМИ
const stringParse = "2";
const parsedString = Number.parseInt(stringParse);
console.log("Parsed string to Int: " + parsedString);
let numArray = [ 12, 14, 18, 22, 24, 35, 99 ];
let maxNum = Math.max(numArray);
console.log(`The large num of ${numArray} is ${maxNum}`); // ДЖАБА СКРИПТ СОСЕТ МОЮ БОЛЬШУЮ БИБУ



// ФУНКЦИИ - FUNCTIONS
// 8====o=- Function Declaration -=o====8
function rideBikeDeclaration(){
    console.log("Я катаюсь на велосипеде");
}

// 8====o=- Function Expression -=o====8
const rideCarExpression = function() {
    console.log("Я катаюсь на машине");
}
rideBikeDeclaration();
rideCarExpression();

// 8====o=- Arrow Function - стрелочная функция -=o====8
let powNum = 2;
const pow2 = num => num ** 2;
console.log(`Pow num is ${powNum}; Result is ${pow2(powNum)}`);

// 8====o=- Значения по умолчанию -=o====8
function rnd(coeff = 1) {
    return 1488 * coeff;
} 

// 8====o=- Closure - замыкания -=o====8
function authorizate(password){
    return function(repeatPass){
        let wasAuth = false;
        if(password === repeatPass){
            wasAuth = true;
        }
        return wasAuth;
    }
}
const inputPassword = "1234";
const repeatPassword = "12345";
const tryAuthorizate = authorizate(inputPassword);
console.log(`Try authorizate. Input: ${inputPassword}, 
            repeat: ${repeatPassword}; 
            Auth success: ${tryAuthorizate(repeatPassword)}`);


