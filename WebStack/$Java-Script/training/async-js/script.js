"use strict"

// Асинхронность в js реализована на основе Event Loop
// выполняется один раз после указанной задержки
const timeOut = setTimeout(() => {
    console.log("After timeout");
}, 1000);
clearTimeout(timeOut);

let intervalCounter = 0;
const interval = setInterval(() => {
    if(intervalCounter === 3){
        clearInterval(interval);
    }
    console.log("Inteval " + intervalCounter++);
}, 1000);
clearInterval(interval);



// ПРОМИСЫ - PROMISE
const delayAsync = (wait = 1000) => {
    const promise = new Promise((resolve, reject) => {
        // setInterval(reject("СМЭРТЬ ПРОЕКТУ!!!!!! (о ш и б к а)"), wait); // - генерируем ошибкинс
        setInterval(resolve(), wait); // выполняем все чикибрики-асинхронно
    });
    return promise;
}
const delay = (wait = 1000) => new Promise(resolve => {
    setTimeout(resolve(), wait);
});

// delayAsync()
//     .then(    ()    => console.log("Задержка")  )
//     .catch(   (err) => console.log("Error: " + err) )
//     .finally( ()    => console.log("Конец задержки")  );

const getUsers = () => new Promise(resolve => resolve(["Sparrow", "Grishka", "Gokhlia"]));
// getUsers().then(user => console.log(user));




// ASYNC - AWAIT
async function asyncTask (){
    try{
        await delay(4000);
        const users = await getUsers();
        const usersType = typeof(users);
        if(usersType != string)
            throw new Error("Возникла ошибка при получении пользователей!");
        else{
            console.log(users);
        }
    }
    catch(err){
        console.log("Что-то пошло не так! Ошибка: " + err);
    }
}
asyncTask();

async function foo() {
    let promise = new Promise((resolve) => {
        setTimeout(() => resolve("Ready!"), 3000)
    });
    let result = await promise;
    console.log(result);
}
foo();



// РАБОТА С DOM ДЕРЕВОМ
const customizeElement = (headingClass, bgColor = "white") => {
    const heading = document.querySelector(`.${headingClass}`);
    heading.style.color = "#fff234";
    heading.style.fontFamily = "Arial";
    heading.style.background = bgColor;
    heading.style.padding = "10px";
    heading.style.margin = "-50 0 0 0";
}
const dynamicCustomizeElement = (htmlClass, delay = 1000, isBgCustom = false) => {
    setTimeout(() => {
        let customColor = "";
        if(isBgCustom === true){
            customColor = "black";
        }
        customizeElement(htmlClass, customColor);
    }, delay);
}

dynamicCustomizeElement("heading-1", 100);
dynamicCustomizeElement("heading-2", 200);
dynamicCustomizeElement("heading-3", 300);

dynamicCustomizeElement("heading-1", 700, true);
dynamicCustomizeElement("heading-2", 800, true);
dynamicCustomizeElement("heading-3", 900, true);


const element = document.getElementById("main-title");
console.log(element.innerHTML);
console.log(element.baseURI);