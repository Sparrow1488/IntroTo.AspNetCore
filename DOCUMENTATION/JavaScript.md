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

### Разница между var, let и const. Область видимости переменных.

[Источник знаний.](https://metanit.com/web/javascript/3.2.php)

Для определения локальной области видимости в JavaScript используются фигурные скобки `{ }`, которые создают блок кода

``` JavaScript
{
  var a = 5;
  let b = 8;
  const c = 9;
}
```

**var** - определяет локальные переменные **уровня функции.**

**let** - определяет локальные переменные **уровня блока кода.**

**const** - определяет константы **уровня блока кода**.

Однако в этом случае поведение переменной зависит от способа ее определения (через `var`, `const`или через `let`).

##### var

Итак, `var` имеет большую область видимости: мы можем объявить ее в обособленном (локальном участке кода) и обращаться к ней без проблем. Однако, если блок кода, в котором переменная `var` не будет проинициализированна, при дальнейшем обращении к ней будет выдаваться значение `undefined`.  

```javascript
// условие
if(false){
  var b = 6;
}
console.log("b = ", b); // b = undefined
```

```javascript
// цикл
for(var i = 1; i < 0; i++){
  var c = 7;
}
console.log("c = ", c); // c = undefined
```

**Примечание**: если объявить переменную `var` глобально и локально, используя при этом одно имя, то в локальном блоке кода будет использоваться *локальная переменная*. 

##### let и const

Что происходит у `let` и `const`?

```javascript
{
  let a = 5;
}
console.log("a = ", a); // Uncaught ReferenceError: a is not defined
```

Получается, что использование `let` и `const` в качестве объявления переменных более безопасно, так как предотвращает множество возможных ошибок. 

