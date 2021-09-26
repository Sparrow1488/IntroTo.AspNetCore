# The-basis-of-jQuery

### Вступление

Это небольшой справочник по такому JS-фреймворку как **jQuery**. Здесь я намерен записывать различные функции, команды и прочее, что есть в этом фрейме. Короче погнали.

## Выборка элементов

### Фильтры
```js
var evenElems = $("tr:even"); // even - четные элементы
```

| Filter                | Description                                                  |
| :-------------------- | ------------------------------------------------------------ |
| **:eq(n)**            | Выбирает n-й элемент выборки (нумерация начинается с нуля)   |
| **:even**             | Выбирает элементы с четными номерами                         |
| **:odd**              | Выбирает элементы с нечетными номерами                       |
| **:first**            | Выбирает первый элемент выборки                              |
| **:last**             | Выбирает последний элемент выборки                           |
| **:gt(n)**            | Выбирает все элементы с номером, большим n                   |
| **:lt(n)**            | Выбирает все элементы с номером, меньшим n                   |
| **:header**           | Выбирает все заголовки (h1, h2, h3)                          |
| **:not(селектор)**    | Выбирает все элементы, которые не соответствуют селектору, указанному в скобках. Например, выражение `$("tr:not(.even)")` выберет все строки, у которых атрибут class не равен even. |
| **:contains('text')** | Получает все элементы, которые содержат текст `text.`.       |
| **:has('селектор')**  | Получает все элементы, которые содержат хотя бы один дочерний элемент, соответствующий селектору |

Таблица взята с [этого](https://metanit.com/web/jquery/2.2.php#:~:text=%D0%BD%D0%B0%D0%B1%D0%BE%D1%80%20%D0%B1%D0%B0%D0%B7%D0%BE%D0%B2%D1%8B%D1%85%20%D1%84%D0%B8%D0%BB%D1%8C%D1%82%D1%80%D0%BE%D0%B2%3A-,%D0%A4%D0%B8%D0%BB%D1%8C%D1%82%D1%80,%D0%9E%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5,-%3Aeq(n)) сайта.

И также можно комбинировать фильтры выборки:
```js
$('#results:odd:has('img')')
```

### Работа с выборкой

**[Метод add](https://metanit.com/web/jquery/2.3.php#:~:text=%D0%9C%D0%B5%D1%82%D0%BE%D0%B4%20add%20%D0%B8%20%D0%B4%D0%BE%D0%B1%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%BD%D0%BE%D0%B2%D1%8B%D1%85%20%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82%D0%BE%D0%B2)**

Если элемент удовлетворяет условию - он добавляется.

```js
$(function(){
    var array = $("tr:even").add("tr:odd:first");
    //данное выражение эквивалентно следующему
    // var array = $("tr:even, tr:odd:first");
});
```

[**Метод not**](https://metanit.com/web/jquery/2.4.php#:~:text=%D1%82%D0%BE%20%D0%B2%D0%BE%D0%B7%D0%B2%D1%80%D0%B0%D1%89%D0%B0%D0%B5%D0%BC%20true.-,%D0%9C%D0%B5%D1%82%D0%BE%D0%B4%20not,-%D0%9F%D1%80%D0%BE%D1%82%D0%B8%D0%B2%D0%BE%D0%BF%D0%BE%D0%BB%D0%BE%D0%B6%D0%BD%D1%8B%D0%BC%20%D0%BF%D0%BE%20%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D1%8E)

Если элемент удовлетворяет условию - он исключается.

```js
$(function(){
    var array = $("tr").not(function(){
        if($(this).hasClass("header")) { return true;}
        else {return false;}
    });
    array.css('background-color', 'silver');
});
```

**Метод find**

```js
$(function(){
    var array0 = $('ul').find('.submenu');
    array0.css('background-color', 'silver');
});
```

**Метод children**
```js
var lists = $('li').children('');
	lists.each(function(index, elem){
	console.log(elem.innerHTML);
});
```

**Метод closest**

Возвращает ближайшего родителя:

```js
$(function(){
    var list = $('li').closest('ul.submenu');
    list.each(function(index, elem){
    console.log(elem.innerHTML);
});
```

**Метод siblings**

Получает все элементы на одном уровне с текущим элементом

```js
var lists = $('.punkt2').siblings();
```

## Манипуляция элементами из jQuery

### [Атрибуты и свойства элементов](https://metanit.com/web/jquery/3.1.php)

**Метод prop**

Изменяет значение свойства атрибута:

```js
$('a').first().prop('href','33.html');
```

**Метод removeProp**

Удаляет свойство и устанавливает значение undefined:

```js
$('a').first().removeProp('href');
```

**Метод attr**

Первым параметром принимает название атрибута, вторым - новое значение:

```js
$('a').first().attr('href','33.html');
```

**Метод removeAttr**
```js
$('a').first().removeAttr('href');
```

### Пользовательские атрибуты HTML5

С приходом html5 была добавлена возможность использовать пользовательские аттрибуты в html. Для этого перед название пользовательского атрибута нужно дописать приставку **data-**. Например:

```html
<div class="custom-attr" data-user-login="Sparrow">
	<p>Посмотри на пользовательский атрибут родителя!</p>
</div>
```

Для манипуляции данными атрибутами в jQuery имеется крутейший метод **data("prop")**

Извлечем же свойство нашего атрибута:

```js
let prop = $("div.custom-attr").data("user-login");
console.log(prop);
```

Или так:

```js
console.log($('div.custom-attr').data().userLogin);
```

Либо же изменим свойство:

```js
$('div.custom-attr').data("user-login", "NewUser");
// либо же целый объект
$('div.custom-attr').data("user-login", { 
    login: "NewUser", 
    years: "11" 
});
```

А для удаления есть метод **removeData**

```js
$('div.custom-attr').removeData('year');
```

### Работа с каскадными таблицами CSS

Получение стилей:

```js
$('div.panel').css('font-size');
```

Изменение стиля с условием

```js
$("a").css("color", function(index, oldValue){
	bool result = "green";
    if(oldValue != "rgb(0, 0, 238)")
    	result = "green";
    return result;
});
```

### Использование классов

**Метод addClass**

```js
$("div").first().addClass("black visible");
```

**Метод removeClass**

```js
$('div').first().removeClass("black visible");
```

**Метод hasClass**

```js
if($('ul').first().hasClass("redStyle")){
    console.log('Список содержит класс redStyle');
}
```

**Метод toggleClass - переключение классов**

```js
$(function(){
        $('button').click(function(){
            $(this).toggleClass("redStyle");
        }
    });
});
```

### Работа с разметкой html

Получение разметки:

```js
var html = $('li.punkt2').html();
```

Изменение разметки

```js
$('div').html("<p>Новый контент!!!</p>")
```

Добавление новой разметки к старой

```js
var oldHtml = $('div.header').html();
$('div.header').html(oldHtml+"<p>Новый контент!!!</p>")
```