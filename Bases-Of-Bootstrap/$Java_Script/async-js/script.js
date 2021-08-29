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
    alert(result);
}
foo();