# MVC

### Виды навигации

**Conventional based routing** - общепринятая стандартная навигация (по умолчанию используется в MVC). При использовании данной навигации, URL запроса формируется исходя из названия контроллера и методов (controller and actions); Т.е. Следующим образом : *...[controller]/[method]*, for example: *Blog/article*, where Blog is <u>controller</u> and article is <u>action</u>.

**Dedicated conventional routing** - "выделенная стандартная маршрутизация" - хз че это.
**Attribute based route on action method** - стандартная маршрутизация атрибутами над действующими методами (перевод от меня (bull shit)). Позволяет задавать атрибутом (`Route["name"]`) уникальный адрес URL при обращении к обрабатывающему методу контроллера. 

![]()

### Возвращаемые значения в методах

* Коды результатов (Status code results)
* Объекты (Object results)
* Переадресация (Redirect results)
* Файлы (File results)
* Контент (Content results)

### Параметры запросов

* Параметры в URL
* With Query string
* With Headers
* With Request Body
* In a Form

Вот способ

![]()

![]()

Второй способ, поместив значения в запрос

![]()

![]()

Еще способ, отправив данные через Header (пользуемся приложением **Postman**)
Плюсом этого способа является то, что мы скрываем информацию и различные значения, отправляемые вместе с запросом (например пароль, важную информацию и тд)

![]()

![]()

Можно также отправлять POST запрос, используя Body запроса

![]()

![]()

Ну и конечно же, мы можем отправлять файлы, используя в параметрах атрибут `[FromForm]`. Мы можем передать множество аргументов в метод-обработчик, например сам файл и имя отправителя, обернув процесс загрузки в сто-строчный legacy код!!! (но в данном примере все хорошо)

![]()

![]()

### Различные типы ответов

* Status codes
* Object results
* Redirect results
* File results
* Content results

Created results (status code 201). В Header имеет св-во Location, которое является ссылкой на ресурс.

![]()

![]()

**Status 200**

![]()

**Status 204 - no content**

![]()

![]()

**Status 400 - bad user request**

![]()

**Status 401 - unauthorized**

![]()

**Status 404 - Not found result** 

![]()

**Status 415 - Unsupported media type result**

![]()

### Status codes with Object results

**OK status with object - status 200**

![]()

**Created status with Object - status 201**

![]()

**Bad request status with Object - status 400**

![]()

**Not found status with Object - status 404**

![]()

**Redirect results**

![]()

**Local redirect results**

![]()

![]()

**Action redirect results**

![]()

**File results**

![]()

**Virtual file result (из интернета)**

![]()

Ну и прочие результаты:
`return new View();`
`return new PartialView();`
`return Json();`