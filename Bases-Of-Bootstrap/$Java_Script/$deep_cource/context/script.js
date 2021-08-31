// "use strict"  -  удивительно, не работает контекст

// контекст в js понятие динамическое
// вот он конекст window
function hello() {
    console.log("Hello by ", this);
}
hello();

// и вот он, уже контекст person
const person = {
    name: "Jojo",
    sayHello: hello,
    sayHelloContext: hello.bind(window),  // привязываем конкретный контекст
    // sayHelloWindow: hello.bind(this)
    printInfo: function(job = "бомжует", hobby = "отсутствует") {
        console.group(`${this.name} info`);
        console.log(`Имя: ${this.name}`);
        console.log(`Возраст: ${this.age}`);
        console.log(`Работа: ${job}`);
        console.log(`Возраст: ${hobby}`);
        console.groupEnd();
    }
}
person.sayHello();
person.sayHelloContext();

const arina = {
    name: "Arina",
    age: 19
}

const arinaPrintInfo = person.printInfo.bind(arina);
arinaPrintInfo("BackEnd", "Swimming");

// CALL; BIND; APPLY - отличие лишь в передаче параметров в функцию

// person.printInfo.bind(arina)("BackEnd", "Swimming");
// person.printInfo.call(arina, "BackEnd", "Swimming");
person.printInfo.apply(arina, ["BackEnd", "Swimming"]);





Array.prototype.multBy = function(n = 1){
    return this.map(function(num) {
        return num * n;
    });
}
const arr = [1, 2, 3, 4, 5];
console.log(arr.multBy(50));