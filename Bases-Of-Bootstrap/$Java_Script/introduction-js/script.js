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


        
// РАБОТА С МАССИВАМИ
const baseArray = ["TheFirst", "TheSecond", "TheThird"];
const array = ["TheFirst", "TheSecond", "TheThird"];
const firstItem = array.shift(); // удаляет первый элемет массива и возвращает его
const lastItem = array.pop(); // удаляет последний элемент и возвращает его
console.log(`Было: '${baseArray}'; Стало: '${array}'`);

const hiRow = "Всем хааааааааййй!!!!!!!"; 
const reverseRow = hiRow.split("").reverse().join("");
console.log(reverseRow);

const baseOfPeople = 
[
    {name:"Valentosik", bucks: 300},
    {name:"Gokhlia", bucks: 450},
    {name:"Yuri", bucks: 1488},
]
const foundHuman = baseOfPeople.find(zyabl => { // используем лямбду
    return zyabl.bucks > 400;
});
console.log("Human which has more than 400 bucks: " + foundHuman.name);



// ОБЪЕКТЫ 2
const women = {
    name: "Arina",
    "serial number": 123456789,
    ["special_key_" + (2 + 2)]: 12,
    age: 17,
    boys: ["Tomir", "Arturchik", "Uzir", "Kalima", "Mikle"],
    printBoys(){
        boysString = `${this.name} boys are `;
        for (const boy of this.boys) {
            boysString += boy + ", ";
        }
        console.log(boysString);
    }
}
console.log(`Name: ${women.name}\nNumber: ${women["serial number"]}\nAge: ${women["special_key_4"]}`);
women.printBoys();

// дальше идет полный пиписоздец 
console.log(women); 
delete women['special_key_4']; // удаление свойств объекта
console.log(women); 

// деструктуризация
// this        ∙↓↓↓∙
// const serialNumber = women["serial number"];
// const age = women.age;
// equals this ∙↓↓↓∙        ∙ - 249
const {name = "", age = 0} = women; // с заданными значениями по умолчанию (если из women прилетело undefined)
const printNameAndAge = `${name} ${age}`;
console.log(printNameAndAge);

// this        ↓
for (const key in women) {  // → → → ПРО FOREIN СТОИТ ПОЧИТАТЬ ДЛЯ СОБЕСА ← ← ← 
    if (women.hasOwnProperty(key)){
        console.log(`KEY: ${key};\t VALUE: ${women[key]}`);
    }
}
// equals this ↓
const keys = Object.keys(women);
keys.forEach(key => {
    console.log(`KEY: ${key};\t VALUE: ${women[key]}`);
});