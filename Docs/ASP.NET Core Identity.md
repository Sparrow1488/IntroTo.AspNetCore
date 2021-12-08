# ASP.NET Core Identity

## Порядок внедрения авторизации в проект

1. ### **Устанавливаем необходимые пакеты**
   
   * Microsoft.AspNetCore.Identity
   * Microsoft.AspNetCore.Identity.EntityFramework (работа описана именно с ним)
   
2. ### **Настроим контекст данных пользователя**

```C#
public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public ApplicationDbContext([NotNull] DbContextOptions options) : base(options) { }
}
```

`IdentityDbContext` это изначально настроенный контекст для работы с данными пользователя, используя EF. Первым в Generic параметр передаем класс пользователя `AppUser` , роль `AppRole` и тип свойства, используемый в качестве ключа. Это может быть как `Integer`, `String`, так `Guid`, что предпочтительнее использовать в большом проекте.

Сущность пользователя также необходимо унаследовать от `IdentityUser<Key>`:

```C#
public class AppUser : IdentityUser<Guid>
{
}
```

Очевидно, что тип ключа, передаваемый в Generic параметр классу `IdentityDbContext` и `IdentityUser` должны совпадать.

Таким же образом происходит и настройка `AppRole` в проекте, наследуясь от заранее подготовленного класса `IdentityRole<Key>`:

```C#
public class AppRole : IdentityRole<Guid>
{
}
```

3. ### **Добавим сервисы авторизации в методе ConfigureServices**

```C#
services.AddDbContext<ApplicationDbContext>(config => config.UseInMemoryDatabase("Auth-Memory-Db"))
    .AddIdentity<AppUser, AppRole>(config =>
    {
        config.Password.RequireDigit = false;
        config.Password.RequireLowercase = false;
        config.Password.RequireUppercase = false;
        config.Password.RequiredLength = 3;
        config.Password.RequireNonAlphanumeric = false;
    })
.AddEntityFrameworkStores<ApplicationDbContext>();
```

> **Примечание**: в этом тестовом проекте используется хранилище InMemory для EF (т.е. пакета Microsoft.EntityFrameworkCore.InMemory). Для использования (для кого то) привычной SQL БД следует установить Microsoft.EntityFrameworkCore.SqlServer. Конфигурация в данном решении различается лишь методом `UseSqlServer`.

Также в лямде метода, используя конфиг `IdentityOptions`, мы можем настроить некоторые параметры паролей, пользователей и тд. Не хочу это описывать в данном мануале.

4. ### **Добавим политики авторизации и роли**

Ниже, следующим методом, будет метод добавления непосредственно авторизации.

```C#
services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", config => config.RequireClaim(ClaimTypes.Role, "Administrator"));
    options.AddPolicy("Manager", config =>
        config.RequireAssertion(handler =>
            handler.User.HasClaim(ClaimTypes.Role, "Administrator") ||
            handler.User.HasClaim(ClaimTypes.Role, "Manager")));
});
```

Таким образом мы настроим "приоритетность" ролей, что позволит разграничить доступ к различным функциональным частям программы. Немного поясню данный код следующим комментарием:

> Добавим политику "Administrator" и разрешим использовать ее в случае, если роль пользователя эквивалентна записи "Administrator". Еще добавим политику "Manager" и разрешим использовать ее в случае, если роль пользователя эквивалента записи "Administrator" или "Manager". Следовательно, пользователь с правами доступа "Manager" имеет преимущества над "Administrator".

Короче объясняю я как туземец, но постарайтесь (я мне это говорю) допереть это сами.

> **Дополнение**: добавим еще одну конфигурацию, для переадресации пользователей при различных критических ситуациях по определенным маршрутам

```C#
services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Admin/Login";
    config.AccessDeniedPath = "/Home/AccessDenied";
});
```

5. ### **Добавим в проект все то, что мы конфигурировали в пунктах с 1 по 4**

Метод Configure располнел еще на два вложенных метода:

```C#
app.UseAuthentication();
app.UseAuthorization();
```

6. ### **Если я не полный кретин, то мы в шоколаде**

Теперь, для лицезрения всей мощи функционала ASP.NET Core Identity, нам остается лишь "атрибутить" контроллеры и методы определенными атрибутами. 

Создадим же контроллер AdminController и накинем ему атрибут `[Authorize]`. Теперь, только авторизованные пользователи, прошедшие аутентификацию в системе, могут использовать методы в данном контроллере. Если мы хотим распределить доступ к определенным методам по ролям, то добавим атрибут `[Authorize(Policy = <rolename>)]`. Должно быть понятно, что он делает. 

7. ### Авторизация и регистрация в системе

Добавим метод `Login` в том же контроллере с атрибутом `[AllowAnonymous]`, что позволит использовать его неавторизованным пользователям. С помощью механизма DI объявим поля через конструктор с типами `UserManager<AppUser>` и `SignInManager<AppUser>`. Также изменим код в Login следующим образом:

```C#
[HttpPost]
[AllowAnonymous]
public async Task<IActionResult> Login(LoginViewModel vm)
{
    IActionResult requestResult = View(vm);
    if (ModelState.IsValid)
    {
        var user = await _userManager.FindByNameAsync(vm.UserName);
        if(user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password , false, false);
            if(result.Succeeded)
                requestResult = Redirect(vm.ReturnUrl);
        }
        else 
        	ModelState.AddModelError("Login", "User not found!");
    }
    return requestResult;
}
```

`LoginViewModel` выглядит следующим образом:

```C#
 public class LoginViewModel
 {
     [Required]
     public string UserName { get; set; }
     [Required]
     public string Password { get; set; }
     [Required]
     public string ReturnUrl { get; set; }
 }
```

Прочитав код, можно понять каким образом происходит аутентификация пользователя.

Не откладывая в долгий ящик, добавим метод для выхода из учетной записи:

```C#
public async Task<IActionResult> SignOut()
{
    await _signInManager.SignOutAsync();
    return Redirect("/Home/Index");
}
```

И создадим метод для регистрации (в моем случае я создаю пользователей при запуске приложение, но код создания выглядит следующим образом):

```C#
public static void Init(IServiceProvider provider)
{
    var userManager = (UserManager<AppUser>)provider.GetService(typeof(UserManager<AppUser>));
    var user = new AppUser() { UserName = "asd" };
    var result = userManager.CreateAsync(user, "1234").GetAwaiter().GetResult();
    if (result.Succeeded)
    	userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator"));
    else throw new Exception("Не удалось создать пользователя");
}
```

### Итоги

Вроде как это все, бандиты.