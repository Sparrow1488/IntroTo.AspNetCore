# Это база

### Конвейер обработки запроса и middleware

Обработка запроса в ASP.NET Core устроена по принципу конвейера. Сначала данные запроса получает первый компонент в конвейере. После обработки он передает данные HTTP-запроса второму компоненту и так далее. Эти компоненты конвейера, которые отвечают за обработку запроса, называются middleware. 
Компоненты middleware конфигурируются с помощью методов расширений `Run`, `Map` и `Use` объекта `IApplicationBuilder`, который передается в метод `Configure()` класса `Startup`

```c#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // если приложение в разработке, то выводим такую то инфу
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    // добавляем возможности маршрутизации (и производим все настройки для этого)
    app.UseRouting();

    // устанавливаем адреса, которые будут обрабатываться
    app.UseEndpoints(endpoints =>
		{
            // указывает, что при обращении по запросу "/" (корневой папке) ...
            endpoints.MapGet("/", async context =>
		{
		// будет выводиться следующее:
		await context.Response.WriteAsync("Hello ASP.NET Core 5!");
	});
	endpoints.MapGet("/about", async context =>
	{
		await context.Response.WriteAsync($"Application use : 			{_environment.ApplicationName}");
		});
	});

	// обработает все запросы, которые не были обработаны ранее (но о нем далее)
	app.Run(async context =>
	{
		await context.Response.WriteAsync("We can't processing your request!!!!!!!");
	});
}
```

Все вызовы типа `app.UseXXX` как раз и представляют собой добавление компонентов middleware для обработки запроса.

### Жизненный цикл middleware

Метод `Configure` выполняется один раз при создании объекта класса `Startup`, и компоненты middleware создаются один раз и живут в течение всего жизненного цикла приложения. То есть для последующей обработки запросов используются одни и те же компоненты.

### Методы Use, Run

Для конфигурации конвейера обработки запроса применяются методы `Run`, `Map` и `Use`.

**Run**

Метод `Run` представляет собой простейший способ для добавления компонентов middleware в конвейер. Однако компоненты, определенные через метод `Run`, не вызывают никакие другие компоненты и дальше обработку запроса не передают. Причем, так как данный метод не передает обработку запроса далее по конвейеру, то его следует помещать в самом конце.

**Use**

Метод Use в качестве параметров принимает контекст запроса - объект `HttpContext` и делегат `Func<Task>`, который представляет собой ссылку на следующий в конвейере компонент middleware.
Метод `app.Use` реализует простейшую задачу - умножение двух чисел и затем передает обработку запроса следующим компонентам middleware в конвейере.
То есть при вызове `await next.Invoke()` обработка запроса перейдет к тому компоненту, который установлен в методе `app.Run()`

```c#
int x = 1000;
// как и метод Run() добавляет компонент в конвеер, но при этом
// вызывает следующий по списку компонент middleware
// первый конвеер middleware
app.Use(async (context, next) =>
{
    // logic 1...
    x -= 7;
    await next.Invoke();
});
// второй конвеер middleware
app.Run(async context =>
{
    // logic 2...
    await context.Response.WriteAsync("RESPONSE : " + x);
});
```

При использовании метода `Use` и передаче выполнения следующему делегату следует учитывать, что не рекомендуется вызывать метод `next.Invoke` после метода `Response.WriteAsync()`. Как и то, что только один компонент middleware должен отправлять ответ клиенту. Он должен либо генерировать ответ с помощью `Response.WriteAsync()`, либо вызывать следующий делегат посредством `next.Invoke`, но не выполнять оба этих действия одновременно (может поломаться протокол и могут прийти лишние байты, что то не туда запишется и тд).

**ПЛОХОЙ КОД**

```c#
public void Configure(IApplicationBuilder app)
{
  app.Use(async (context, next) =>
  {
    await context.Response.WriteAsync("<p>Hello world!</p>");
    await next.Invoke();
  });
      
  app.Run(async (context) =>
  {
    // await Task.Delay(10000); можно поставить задержку
    await context.Response.WriteAsync("<p>Good bye, World...</p>");
  });
}
```

### Методы Map и MapWhen

**Map**

Метод `Map` применяется для сопоставления пути запроса с определенным делегатом-обработчиком. Все, что не будет обработано этими методами, пролетит в блок `app.Run`, который находится в конце метода `Configure`.

```c#
public void Configure(IApplicationBuilder app)
{
    app.Map("/index", Index);
    app.Map("/about", About);
 
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Page Not Found");
    });
}
```

Также у метода `Map` могут быть под-маршруты. Таким образом:

```c#
app.Map("/home", home =>
{
    home.Map("/index", Index);
    home.Map("/about", About);
});
```

Переходя по адресу `/home`, мы также можем перейти по его вложенным адресам `/index` и `/about.`

**MapWhen**

Метод принимает в качестве параметров функцию, принимающая в себя `HttpContext` и возвращающая bool и делегат, который выполнится, если результатом функции было true.

```c#
app.MapWhen(context => {
    return context.Request.Query.ContainsKey("id") && 
        context.Request.Query["id"] == "5";
}, HandleId);
```

Выглядеть верный запрос должен следующим образом:

`localhost:55232/?id=5`

<u>Стоит также учесть, что методы Run, Map и MapWhen являются конечными в конвейере, т.е. дальше себя они не могут "протолкнуть" запрос для обработки.</u>

### Создание компонентов middleware

За место методов `Map`, `Use`, `Run` мы можем использовать нами созданный компонент middleware и использовать его для обработки, вызвав в конфигурационном методе `UseMiddleware().` Для этого нужно создать класс, конструктор которого будет принимать `RequestDelegate`, а также будет иметь метод `Invoke`, либо `InvokeAsync`, возвращающие новую задачу `Task` и принимающие `HttpConext`.

```c#
public class AuthorizationMiddleware
{
    public AuthorizationMiddleware(RequestDelegate nextDelegate)
    {
        _next += nextDelegate;
        SetRegisteredPeople();
    }
    private List<string> _registeredPeople = new List<string>();
    public readonly RequestDelegate _next;

    public async Task InvokeAsync(HttpContext context)
    {
        if(_registeredPeople.Contains(context.Request.Query["name"]))
        {
            await context.Response.WriteAsync("Success authorizated emae!!!! All       registrated people count: " + _registeredPeople.Count);
        }
        else
        {
            _next?.Invoke(context);
        }
    }
    private void SetRegisteredPeople()
    {
        _registeredPeople = new List<string>()
        {
            "sparrow",
            "gokhlia",
            "kayote"
        };
    }
}
```

`app.UseMiddliware<AuthorizationMiddliware>();`

И мы можем вынести использование авторизации в метод расширения для интерфейса `IApplicationBuilder`.

```c#
public static class AuthorizationExtension
{
    public static IApplicationBuilder UseAuthorization(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AuthorizationMiddleware>();
    }
}
```

Наш конфигурационный метод выглядит следующим образом

```c#
public void Configure(IApplicationBuilder app)
{
    app.UseRouting();
    app.UseAuthorization();

    app.Run(async context =>
	{
        await context.Response.WriteAsync("Mda chelik. i fill cringe......");
	});
}
```

### Конвейер обработки запроса

Как правило, для обработки запроса применяется не один, а несколько компонентов middleware. И в этом случае большую роль может играть порядок их помещения в конвейер обработки запроса, а также то, как они взаимодействуют с другими компонентами.
Кроме того, каждый компонент middleware может обрабатывать запрос до и после последующих в конвейере компонентов. Данное обстоятельство позволяет предыдущим компонентам корректировать результат обработки последующих компонентов. (см. [4[Repeat]ConveyotOfRequestProcessing](https://github.com/Sparrow1488/The-basis-of-ASP.NET/tree/main/ASP.NET%20Core/BaseCource/4%5BRepeat%5D.ConveyorOfRequestProcessing)).

![Конвейер](https://metanit.com/sharp/aspnet5/pics/2.20.png)

### IWebHostEnvironment и окружение

Для взаимодействия со средой, в которой запущено приложение, применяются объекты, реализующие интерфейс `IHostingEnvironment`. Производные классы от данного интерфейса позволяют взаимодействовать со средой разработки (например, получать имя проекта, состояния: в разработке/продакшене или же указывать свои состояния). Примеры можно найти в проекте [5.IWebHostEnvironmentAndOther](https://github.com/Sparrow1488/The-basis-of-ASP.NET/tree/main/ASP.NET%20Core/BaseCource/5.IWebHostEnvironment).

### Static files

Статические файлы в проекте asp net хранятся в папке `wwwroot`, которая не создается по умолчанию в Empty проекте. Тут все просто.
Так же мы можем использовать статические страницы как стандартные, т.е. находясь на `http://localhost:xxxx/` ему будет высвечиваться страница по умолчанию. Для этого нужно создать в папке wwwroot файл с названием: `default.htm(l)` / `index.htm(l)`. В случае, когда файл по умолчанию имеет уникальное имя, то его нужно указать в следующем коде:

```c#
public void Configure(IApplicationBuilder app)
{
    DefaultFilesOptions options = new DefaultFilesOptions();
    options.DefaultFileNames.Clear(); // очищаем, чтобы index and default файлы не 		 воспринимались
    options.DefaultFileNames.Add("uniqueName.html");

    app.UseDefaultFiles(options);
    app.UseStaticFiles();
}
```

### Метод UseDirectoryBrowser

С помощью этого метода можно реализовать стандартную навигацию в вывод клиенту всех файлов из директории со статик файлами

```c#
public void Configure(IApplicationBuilder app)
{
    app.UseDirectoryBrowser();
    app.UseStaticFiles();
    app.Run(async (context) =>
    {
    	await context.Response.WriteAsync("Hello World");
    });
}
```

![](https://metanit.com/sharp/aspnet5/pics/UseDirectoryBrowser.png)

### Обработка ошибок

Имеется возможность обрабатывать ошибки в двух случаях: когда приложение в стадии разработки и когда работает в режиме прожакшена. Из этих двух статусов вытекает способ обработки исключений.
Если приложение находится в разработке, то при возникновении исключения на экране высвечивается максимально подробная информация об ошибке: где зачем и как. Выглядит это следующим образом (на примере деления на ноль):

![](https://metanit.com/sharp/aspnet5/pics/17.1.png)

Для того, чтобы включить обработку ошибок в режиме разработчика, код в `Startup` должен содержать следующее:

```C#
if(env.IsDevelopment()) // (конструкция if не обязательна)
{
	app.UseDeveloperExceptionPage();
}
```

Но в продакшене использовать такой <u>стыд</u> непозволительно, и для этого воспользуемся методом из следующего пункта.

### UseExceptionHandler

Чтобы по-своему обработать ошибку, можно воспользоваться методом `UseExceptionHandler` и в параметре указать путь, по которому будет вызван делегат-обработчик. Обработчиком, в данном примере, будет являться делегат метода `Map`. 

```c#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    env.EnvironmentName = "Production";

    if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
    else
        app.UseExceptionHandler("/error");

    app.Map("/error", ap => ap.Run(async context =>
	{
		await context.Response.WriteAsync("DivideByZeroException occured!");
	}));

    app.Run(async (context) =>
	{
        int x = 0;
        int y = 8 / x;
        await context.Response.WriteAsync($"Result = {y}");
	});
}
```

*Теперь код выглядит таким образом.*

### Обработка ошибок Http

В отличие от исключений стандартный функционал проекта ASP.NET Core почти никак не обрабатывает ошибки HTTP, например, в случае если ресурс не найден. При обращении к несуществующему ресурсу мы увидим в браузере пустую страницу, и только через консоль веб-браузера мы сможем увидеть статусный код. Но с помощью компонента `StatusCodePagesMiddleware` можно добавить в проект отправку информации о статусном коде. Для этого добавим в метод `Configure()` класса `Startup` вызов `app.UseStatusCodePages().`

```c#
app.UseStatusCodePagesWithReExecute("/error", "?code={0}");
```

Первым параметром указывается MIME-тип (опр: Медиа тип, является стандартом, который описывает природу и формат документа, файла или набора байтов), а вторым - текст ошибки. В сообщение мы можем передать код ошибки через placeholder"{0}".
И, как не странно, мы увидим это в браузере:

`Error. Status code : 404`

А еще можно использовать такой обработчик

` pp.UseStatusCodePagesRedirects("/error/?code={0}");`

Но лучше такой:

```c#
public void Configure(IApplicationBuilder app)
{
	app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

	app.Map("/error", (builder) => builder.Run(async (context) =>
	{
        if(context.Request.Query["code"] == "404")
        	await context.Response.WriteAsync("Well... sorry, page not found");
	}));
}
```

В этом методе, первым параметром передается путь перенаправления, а вторым - параметры строки.

# Сервисы и Dependency Injection

**Dependency Injection (DI)** - это механизм, позволяющий сделать объекты в приложении слабосвязанными через абстракции, интерфейсы, что позволяет сделать систему гибкой и расширяемой.
Часто для внедрения зависимостей используются эдаке IoC контейнеры
(Inversion of Control). В ASP.NET 4 и раньше приходилось использовать внешние контейнеры (Ninject, Autofac, Unity, Windsor Castle, StructureMap), но в ASP.NET Core появился стандартный IoC контейнер - `IServiceProvider`, представляющий из себя интерфейс. А сами контейнеры стали называться **сервисами**. В итоге получается, что контейнеры это **провайдеры сервисов**. 
Для просмотра всех сервисов можно воспользоваться объектов `IServiceCollection`. 

### Информация о сервисах

Описание сервиса предоставляет объект `ServiceDescriptor`.
Важными его свойствами являются:
**ServiceType** - тип сервиса
**ImplementationType** - тип реализации сервиса
**Lifetime** - жизненный цикл

### Создание собственных сервисов

Чтобы создавать собственные сервисы, нам необходимо лишь создать обобщающий интерфейс и реализующие его классы. После чего добавить эти сервисы в методе `ConfigureServices`, используя параметр типа `IServiceCollection` и его метод `AddTransient`. 

```c#
public void ConfigureServices(IServiceCollection services)
{
    // Transient - временный
    services.AddTransient<IHomeBuilder, OneFloorHomeBuilder>();
}
public void Configure(IApplicationBuilder app, IHomeBuilder builder)
{
    app.Run(async context =>
	{
		await context.Response.WriteAsync(builder.GetHomeInfo());
	});
}
```

Не стоит забывать указать наш сервис в параметре метода `Configure`. После всех манипуляций мы можем использовать свой собственный сервис.
А еще можно воспользоваться [методом расширения](https://metanit.com/sharp/aspnet5/2.19.php#:~:text=%D0%A0%D0%B0%D1%81%D1%88%D0%B8%D1%80%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%B4%D0%BB%D1%8F%20%D0%B4%D0%BE%D0%B1%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F%20%D1%81%D0%B5%D1%80%D0%B2%D0%B8%D1%81%D0%BE%D0%B2), чтобы можно было удобнее внедрять свой сервис через метод расширения для интерфейса `IServiceCollection`.

### Передача зависимостей

Из пункта выше можно понять, что передавать сервисы можно в метод `Startup`, но вопрос: можно ли то же самое сделать и со своими классами? Использовать сервисы там, где захочется. И ответ очевиден: да (пи=да).
Для передачи сервисом можно воспользоваться следующими методами:

* через конструктор класса

* через параметр метода `Configure`
* через параметр метода `Invoke` компонента Middleware
* через св-во `RequestServices` контекста запроса `HttpContext` в middleware
* через св-во `ApplicationServices` объекта `IApllicationBuilder` в классе `Startup`

С параметром метода `Configure` все понятно, идем дальше.
Создадим свой класс, использующий сервис `IHomeBuilder`.

А также напишем такой код, чтобы передать в конструктор класса HomeBuilderService сервис.

```c#
public class HomeBuilderService
{
    private IHomeBuilder _builderService;

    public HomeBuilderService(IHomeBuilder builderService)
    {
        _builderService = builderService;
    }
    public string GetInfo()
    {
        return _builderService.GetHomeInfo();
    }
}
```

```c#
public void ConfigureServices(IServiceCollection services)
{
    // Transient - временный
    services.AddTransient<IHomeBuilder, OneFloorHomeBuilder>();
    services.AddTransient<HomeBuilderService>();
}
public void Configure(IApplicationBuilder app, HomeBuilderService service)
{
    app.Run(async context =>
	{
		await context.Response.WriteAsync(service.GetInfo());
	});
}
```

В данном случае мы подключаем в методе `ConfigureService` класс `HomeBuilderService`, так как этот класс использует непосредственно сервисы. Ну и магией asp net все это дело само создается и чудом передается, инициализируется, короче тупа В-А-У, рэально, честно, не обманываю.
Вот еще один крутой способ передачи использования и передачи сервисов.

### HttpContext.RequestServices

[HttpContext.RequestServices](https://metanit.com/sharp/aspnet5/6.4.php#:~:text=%D0%9D%D0%B0%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80%2C%20%D0%B8%D0%B7%D0%BC%D0%B5%D0%BD%D0%B8%D0%BC%20%D0%BA%D0%BB%D0%B0%D1%81%D1%81%20Startup) предоставляет доступ ко всем внедренным зависимостям в методе `ConfigureServices`.

И если не будет найден сервис, тогда вылетит исключение (`StupidProgrammerMoment`).
Кста, еще эта реализация является реализацией паттерна **Service locator**, который не рекомендуется использовать, однако это продолжают делать.

### ApplicationServices

Этот способ очень поход на предыдущий, но выполняется с помощью объекта **[IApplicationBuilder](https://metanit.com/sharp/aspnet5/6.4.php#:~:text=%7D-,ApplicationServices,-%D0%95%D1%89%D0%B5%20%D0%BE%D0%B4%D0%B8%D0%BD%20%D0%BF%D0%BE%D1%85%D0%BE%D0%B6%D0%B8%D0%B9)**.

### Метод Invoke/InvokeAsync компонентов middleware

Ну и конечно же, самое главное место, где мы [можем использовать сервисы - это в middleware](https://metanit.com/sharp/aspnet5/6.4.php#:~:text=%D0%9C%D0%B5%D1%82%D0%BE%D0%B4%20Invoke/InvokeAsync%20%D0%BA%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%B5%D0%BD%D1%82%D0%BE%D0%B2%20middleware). 

### Жизненный цикл зависимостей

Короче будем круты и будем сами указывать какой сервис как будет существовать и вообще...
Короче бывает 3 гендера жизненных циклов:
**Transient** - временный, т.е. <u>при каждом запросе</u> создается новый объект сервиса. Во время одного запроса может быть множественное обращение к сервису, но каждый раз будет создаваться новый объект.
**Scoped** - ограниченный, т.е. <u>при обработке одного запроса</u> будет храниться и использоваться один объект сервиса.
**Singelton** - ну получается, что <u>на протяжении всего срока существования приложения</u> будет использоваться один объект.
Чтобы указывать в конфигурационном методе кто и сколько должен жить, нужно воспользоваться методами `Add*Lifetime*<service...>();`

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<ICounter, RandomCounter>();
}

public void Configure(IApplicationBuilder app)
{
    app.UseMiddleware<CounterMiddleware>();
}
```

```c#
public class CounterMiddleware
{
    private int _requestCounter = 0;
    private RequestDelegate _next;

    public CounterMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, ICounter counter)
    {
		_requestCounter++;
		string responseText = string.Format("Request num: {0}; Random value {1}", _requestCounter, counter.Value());
		await context.Response.WriteAsync(responseText);
	}
}
```

### Использование сервисов в кастомных Middleware

Мы знаем, что можем создавать собственные сервисы, а также передавать их пользовательские компоненты middleware. Сделать это мы можем, например, через  конструктор middleware, либо метод `Invoke/InvokeAsync`. Стоит учесть, что при компиляции проекта, все компоненты middleware создаются один раз. Поэтому, какой бы жизненный цикл сервиса мы не использовали, попав в middleware через конструктор - останется там навсегда (как `Singleton`). Однако, мы можем использовать передачу через параметры метода `Invoke`, что сохранит изначально-указанный lifetime нашего сервиса, и он сможет использоваться как `Singleton`, так и `Transient` или Scoped.  
```C#
	public class TimeMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly TimeService _timeService;
		// либо через ctor
        public TimeMiddleware(RequestDelegate next, TimeService timeService)
        {
            _next = next;
            _timeService = timeService;
        }
        // либо через параметр метода
        // public async Task InvokeAsync(HttpContext context, TimeService service)
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.ToLower() == "/time")
                await context.Response.WriteAsync("Actual time : " + _timeService.GetActualTime());
            else
                await _next?.Invoke(context);
        }
    }
```

```C#
public class TimeService
{
    private DateTime _actualTime = DateTime.Now;
    public DateTime GetActualTime() => _actualTime;
}
```

```C#
public void Configure(IApplicationBuilder app)
{
    app.UseMiddleware<TimeMiddleware>();
    app.UseMiddleware<CounterMiddleware>();
    app.Run(async context => {
    await context.Response.WriteAsync("Hello World!");
    });
}
```

**ВНИМАНИЕ**: **Мы не можем по умолчанию передавать в конструктор singleton-объекта scoped-сервис**

```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IWatch, Watch>();
    services.AddSingleton<TimeService>(); // System.AggregateException: 'Some services are not able to be constructed
}
```

Мы можем использовать объекты `Transient` и `Singleton` в качестве аргумента для конструктора сервиса, однако `Scoped` в этом плане пролетает.

# Конфигурация ASP.NET Core приложения

### О конфигурации приложения

Конфигурация определяет базовые настройки приложения. Проект ASP.NET Core по умолчанию имеет базовую конфигурацию, просмотреть которую можно указав в параметре конструктора класса Startup объект IConfiguration.
```C#
public IConfiguration AppConfiguration { get; }
public Startup(IConfiguration config)
{
	AppConfiguration = config;
}     
```

Приложение ASP.NET Core может получать конфигурационные настройки из следующих источников:

* Аргументы командной строки
* Переменные среды окружения
* Объекты .NET в памяти
* Файлы (json, xml, ini)
* Azure
* Можно использовать свои кастомные источники и под них создавать провайдеры конфигурации

Более подробно в [статье](https://metanit.com/sharp/aspnet5/2.6.php) на сайте Metanit.

### Использование кастомной конфигурации приложения

```C#
public Startup()
{
    var builder = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string>
    {
        {"firstname", "Sparrow"},
        {"age", "17"}
    });
    AppConfiguration = builder.Build();
}
public IConfiguration AppConfiguration { get; set; }
public void Configure(IApplicationBuilder app)
{
	app.Run(async (context) =>
		await context.Response.WriteAsync(AppConfiguration["firstname"]));
}
```

### Нефайловые провайдеры конфигурации

**Провайдер CommandLineConfigurationProvider**

Обеспечивает передачу аргументов командной строки в конфигурацию приложения. Добавить новые ключ/значение можно следующим образом:

1. Через свойства проекта, указав пары key/value разделе Debug.

![](https://metanit.com/sharp/aspnet5/pics/config2.png)

2. Через параметры при запуске приложения

   ![](https://metanit.com/sharp/aspnet5/pics/config4.png)

3. Используя метод AddCommandLine

   ```C#
   public Startup()
    {
        string[] args = { "name=Alice", "age=29"};  // псевдопараметры командной строки
        var builder = new ConfigurationBuilder().AddCommandLine(args);
        AppConfiguration = builder.Build();
    }
   ```

**Провайдер EnvironmentVariablesConfigurationProvider**

```C#
AppConfiguration = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();
```

**Провайдер MemoryConfigurationProvider** (хранение конфигурации в памяти)

```C#
var builder = new ConfigurationBuilder()
.AddInMemoryCollection(new Dictionary<string, string>
{
    {"color", "blue"},
    {"text", "Hello ASP.NET 5"}
});
AppConfiguration = builder.Build();
```

### Файловые провайдеры конфигурации

**Провайдер JsonConfigurationProvider**

```C#
var builder = new ConfigurationBuilder()
.AddJsonFile("config.json");
AppConfiguration = builder.Build();
```

Позволяет использовать большую вложенность, что позволяет вытворять следующие махинации:
```json
// файл - config.json
{
    "author": {
        "name": "Sparrow",
        "rating": "10",
        "status": "creator"
    },
    "application": {
        "title": "11.Configuration",
        "version": "1.0.0",
        "status": "develop"
    },
    "dateCreate":  "15.09.2021"
}
```

Обращение к значениям осуществляется через перечисление вложенных ключей, указывая перед ключем следующей вложенности знак двоеточия:
<p>Author: {AppConfiguration["author:name"]}</p>
<p>Rating: {AppConfiguration["author:rating"]}</p>

В проекте можно использовать множество конфигурационных json файлов, главное - чтобы не повторялись ключи.

**Провайдер** **XmlConfigurationProvider** 

Здесь проще прочитать [первоисточник](https://metanit.com/sharp/aspnet5/2.12.php#:~:text=text%20%3D%20AppConfiguration%5B%22namespace%3Aclass%3Amethod%22%5D%3B-,%D0%9A%D0%BE%D0%BD%D1%84%D0%B8%D0%B3%D1%83%D1%80%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B2%20XML,-%D0%97%D0%B0%20%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5%20%D0%BA%D0%BE%D0%BD%D1%84%D0%B8%D0%B3%D1%83%D1%80%D0%B0%D1%86%D0%B8%D0%B8), поскольку уже 12й час и я хочу спать.

Простенький XML конфиг файл выглядит следующим образом

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <color>blue</color>
  <text>Hello ASP.NET</text>
</configuration>
```

Тут главное не забывать указывать в свойствах файла постоянное копирование при компиляции.

![](https://metanit.com/sharp/aspnet5/pics/config6.png)

**Конфигурация в ini-файлах**

Читаем [первоисточник](https://metanit.com/sharp/aspnet5/2.12.php#:~:text=%D0%9A%D0%BE%D0%BD%D1%84%D0%B8%D0%B3%D1%83%D1%80%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B2%20ini-%D1%84%D0%B0%D0%B9%D0%BB%D0%B0%D1%85) (нет)

### Использование конфигурации по-умолчанию

Указывая в билдере конфигурации собственные настройки, тем самым мы вынуждены сбросить конфигурацию по-умолчанию. Чтобы вновь добавить ее в проект и дальше использовать, можно воспользоваться методом `AddConfiguration` config builder'a.
```C#
var builder = new ConfigurationBuilder()
.AddInMemoryCollection(new Dictionary<string, string>
{
    {"color", "blue"},
    {"text", "Hello ASP.NET 5"}
})
.AddJsonFile("config.json")
.AddConfiguration(config); // добавление конфигурации по умолчанию 
AppConfiguration = builder.Build();
```

### Использование конфигурации в пользовательских компонентах Middleware
Создадим наш компонент Middleware
```C#
private readonly RequestDelegate _next;
private readonly IConfiguration _appConfig;
public ConfigMiddleware(RequestDelegate next, IConfiguration config)
{
    _next = next;
    _appConfig = config;
}
```

И зарегистрируем наш конфигурационный объект в методе
```C#
public IConfiguration AppConfiguration { get; set; }
public void ConfigureServices(IServiceCollection services)
{
	services.AddTransient(provider => AppConfiguration);
}
```

Готово, теперь мы можем передавать нашу конфигурацию куда угодно.

### Создание собственных провайдеров конфигурации

Рассмотрим эту интересную тему в данной [статье](https://metanit.com/sharp/aspnet5/2.15.php).

### Проекция конфигурации на классы

Чтобы не вытаскивать каждое значение через индексатору, можно сразу использовать метод объекта IConfiguration `Get<T>()` или `Bind(obj)`. Рассмотрим примеры.

Мы имеем следующий файл конфигурации:

```JSON
{
    "text": "some text",
    "color": "red"
}
```

И мы можем сразу спроецировать пары ключ/значение на объекта класса `TxtSettings`.

Или изначально создав для привязки объект:
```C#
var txtSets = new TextSettings();
_appConfig.Bind(txtSets);
```

Либо использовав метод `Get<T>()` с указанием типа привязки:
```C#
var txtSettings = _appConfig.Get<TextSettings>();
```

### Использование сервисов IOptions<T>

При помощи этого сервиса, а так же возможностей dependency injection, мы можем проецировать конфигурационные настройки в определенный класс и передавать их в любые middleware компоненты. 
```JSON
{
    "name": "Valentin",
    "age": "11",
    "skills": [
        "ASP.NET Core 5 back-end",
        "Web full-stack",
        "Admin of databases"
    ],
    "languages": [
        "English",
        "Russian",
        "Polish"
    ],
    "company": {
        "title": "Amazon",
        "income":  "90000"
    }
}
```
Конструктор Startup:
```C#
var builder = new ConfigurationBuilder()
.AddJsonFile("man.json");
```
Класс Man:

```C#
public class Man
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Languages { get; set; }
    public List<string> Skills { get; set; }
    public Company Company { get; set; } // отдельный класс
}
```

Метод ConfigureServices:

```C#
services.Configure<Man>(AppConfiguration);
services.Configure<Man>(options => options.Age = options.Age < 0 ? 0 : options.Age);
```
Метод Configure:
```C#
app.UseMiddleware<ManMiddleware>();
```
ManMiddleware:
```C#
private readonly RequestDelegate _next;
private readonly IOptions<Man> _man;
public ManMiddleware(RequestDelegate next, IOptions<Man> man)
{
    _next = next;
    _man = man;
}
public async Task InvokeAsync(HttpContext context)
{
    if (context.Request.Path.Value == "/man")
    await context.Response.WriteAsync($"<p>Name{_man.Value.Name}.</p>");
    else await _next.Invoke(context);
}
```

Данный механизм, позволяет нам работать с конфигурацией, не прибегая к декомпозиции ключей с большой вложенностью, а также дает возможность инкапсулировать config файлы, вычленив из них конкретную настройку.

# Хранение и передача данных пользователей (куки, сессии)

### Работа с Cookie файлами

Куки-файлы используются для хранения данных пользователя на компьютере как клиента, так и сервера. **Максимальный размер куки - 4096 байт ~ 4 кб**. Для использования куки-файлов клиента, можно обратиться к коллекции `Request.Cookies` контекста запроса `HttpContext`, которая содержит полезный методы, такие как `ContainsKey(key)` и `TryGetValue(ket, out string)`. Обращаться к cookie можно через индексатор коллекции.

Отправить пользователю куки, можно через коллекцию `HttpContext.Response.Cookies`, передав в метод `Append(key, value)`, пары ключ/значение. Так же возможно удаление cookie через метод `Delete(key)`.

Пример:
```C#
private string _lastVisitor = "";
public void Configure(IApplicationBuilder app)
{
    var rndLogins = new string[] { "Bebra", "Bomba", "Firerer", "Naga" };
    app.Run(async context =>
    {
        string cookieKey = "name";
        if (context.Request.Cookies.ContainsKey(cookieKey))
        	context.Request.Cookies.TryGetValue(cookieKey, out _lastVisitor);
        context.Response.Cookies.Append(cookieKey, rndLogins[new Random().Next(0, rndLogins.Length - 1)]);
        await context.Response.WriteAsync(string.IsNullOrWhiteSpace(_lastVisitor) ? "Hello world!" : "Hello, " + _lastVisitor);
    });
}
```

Посмотреть сохраненные куки-файлы можно через dev-tools любого современного браузера, выбрав раздел `Applications` :

![](https://metanit.com/sharp/aspnet5/pics/2.42.png)

### Работа с сессиями (Session)

Отличительная особенность использования сессий от куки, заключается в ограничении времени хранения. Так, по умолчанию, данные в сессии сохраняются 20 минут. Время хранения, путь, данные и прочее можно свободно изменять, используя объект `Session` в классе `HttpContext`. [Вот некоторые настройки](https://metanit.com/sharp/aspnet5/2.26.php#:~:text=%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%BF%D0%BE%20%D0%BA%D0%BB%D1%8E%D1%87%D1%83-,%D0%9D%D0%B0%D1%81%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B0%20%D1%81%D0%B5%D1%81%D1%81%D0%B8%D0%B8,-%D0%94%D0%BB%D1%8F%20%D1%80%D0%B0%D0%B7%D0%B3%D1%80%D0%B0%D0%BD%D0%B8%D1%87%D0%B5%D0%BD%D0%B8%D1%8F%20%D1%81%D0%B5%D1%81%D1%81%D0%B8%D0%B9), которые доступны у этого объекта.

Пример использования сессий:
```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddSession();                // подключение самих сессий
    services.AddDistributedMemoryCache(); // для хранения сессий в памяти
}

public void Configure(IApplicationBuilder app)
{
    app.UseSession(); // подключаем в конвеер обработки запроса

    app.Run(async context =>
    {
        string sessionKey = "login";
        string login = context.Session.GetString(sessionKey);
        if (string.IsNullOrWhiteSpace(login))
    {
        context.Session.SetString(sessionKey, "User");
        await context.Response.WriteAsync("Hello ASP.NET Core 5");
    }
    else await context.Response.WriteAsync("Hello, " + context.Session.GetString(sessionKey));
    });
}
```

Хочу отметить наличие свойства [IdleTimeout](https://metanit.com/sharp/aspnet5/2.26.php#:~:text=%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B%20%D1%8D%D1%82%D0%BE%D0%B3%D0%BE%20%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-,IdleTimeout,-%3A%20%D0%B2%D1%80%D0%B5%D0%BC%D1%8F%20%D0%B4%D0%B5%D0%B9%D1%81%D1%82%D0%B2%D0%B8%D1%8F%20%D1%81%D0%B5%D1%81%D1%81%D0%B8%D0%B8), которое определяет время хранения данных сессии при неактивности пользователя (афк).
