# The-(not)basis-of-JavaScript

### Асинхронность (Asynchrony)

[Сайт](http://latentflip.com/loupe/) или [видос](https://www.youtube.com/watch?v=vIZs5tH-HGQ&list=PLqKQF2ojwm3l4oPjsB9chrJmlhZ-zOzWT&index=4) для демонстрации наглядной работы асинхронности в JavaScript. 

**Асинхронность** в программировании — выполнение процесса в неблокирующем режиме системного вызова, что позволяет потоку программы продолжить обработку.

В JavaScript для понимания работы асинхронности необходимо разобраться в следующих механизмах:

**Call Stack** - это механизм для интерпретаторов (таких как интерпретатор JavaScript в веб-браузере) для отслеживания текущего местонахождения интерпретатора в скрипте, который вызывает несколько функций типа functions. Проще говоря, это обычный стек вызовов ничем не отличающийся от других ЯП.

**Web API** — конструкции, встроенные в браузер, построенные на основе языка JavaScript, предназначенные для облегчения разработки функциональности.

**Callback Queue** ([очередь обратного вызова](https://developer.mozilla.org/ru/docs/Web/JavaScript/EventLoop)) - is **a queue**. Hence, functions added to it are processed in a first-in-first-out order. When the event loop in JavaScript is fired, it first checks the call stack to see if it's non-empty. If so, it executes the function at the top of the stack.

**Event Loop** - цикл, которой пробегается по очерди (callback queue) и *в порядке очереди* выполняет функции.

```JavaScript
console.log("Start timeout function");

setTimeout(function () {
  console.log("Inside timeout function");
}, 5000);

console.log("End timeout function");
```

Например, `setTimeout` является функцией самого браузера и ее выполнение за рамками браузера не возможно. В коде данная функция вызывается просто `setTimeout` , но полная запись выглядит так как `window.setTimeout`. Функция является асинхронной и вот как она работает:

Сначала выполняется метод `console.log("Start timeout function")`. Затем, JavaScript передает функцию  `setTimeout` самому браузеру (**Web API**), который  отсчитывает 5 секунд (в примере). В это время код продолжает выполняться, а именно функция   `console.log("End timeout function")` - она попадает в **call stack**, как и функция до нее. Когда 5 секунд проходит, браузер скидывает нашу функцию, находящуюся внутри функции `setTimeout` в некую **Callback queue** (очередь). В данной очереди отробатывает **Event loop**, который пробегается по всем ожидающим функциям и закидывает их в **Call stack**. 

Кстати, есть еще такая штука, которая может пригодиться на собеседовании, называется `setTimeout 0`, т.е.

```JavaScript
console.log("Start");
setTimeout(function() {
    console.log("Anonymous inside function"); // отработает в самом КОНЦЕ
}, 0); 
console.log("End");
```

Вот, собственно, и все.

