// приколямбикс замыкания в том, что все аргументы, которые мы передаем в первую функцию
// как бы замыкаются во второй
// от сюда и пошло такое название
function archiveUserInfo(info) {
    const archiveDate = Date.now();              // сохраняется
    const archiveInfo = Object.assign({}, info); // копируем объект
    return function(){
        console.log(archiveDate + " - Задокументированная информация о пользователе", archiveInfo);
    }
}
const user = {
    login: "Sparrow",
    password: "123456",
    hobby: "Hiking"
}
const printInfo = archiveUserInfo(user);

setTimeout(() => {
    console.log(Date.now());
    printInfo();
    user.hobby = "Athletic";    // убеждаемся, что archive info about user было сохранено и не подлежит изменению
}, 1000);
setTimeout(() => {
    console.log(Date.now());
    printInfo();
}, 1500);



function urlGenerator(root = "http://localhost:5050/"){
    return function(domain){
        return root + domain
    }
}
const pathGenerator = urlGenerator("http://mysite.ru/")
console.log(pathGenerator("home"));
console.log(pathGenerator("profile"));




// ПРАКТИЧЕСКОЕ ЗАДАНИЕ
function logUser(){
    console.log(`Login: ${this.login}; Password: ${this.password}; Hobby: ${this.hobby}`);
}
// logUser.bind(user); // ЗАДАЧА - НАПИСАТЬ СВОЙ BIND

function myBind(context, action){
    return function(){
        action.apply(context, Object.keys(context));
    }
}
function bindSpread(context, action){
    return function(...args){
        action.apply(context, args);
    }
}
const readyFunc = myBind(user, logUser);
const readyFunc2 = bindSpread(user, logUser);
readyFunc();
readyFunc2();