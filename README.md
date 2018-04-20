# A simple implementation os IoC Container for AspNet. MVC5

An example of inversion of control through Dependency Injection(DI)

# How to use

First create your services, example:

```C#
//code omitted for simplicity
 public interface IService
 {
      string TagIsOnline(string tag);
 }
```

```C#
//code omitted for simplicity
public class MyService : IService
{
    public string Myservice(string tag) => $"{tag} is online";
}
```

Now create your container and register services

```C#
//code omitted for simplicity
namespace Containers.Container
{
    public static class Startup
    {
        public static void Configure(IContainer container)
        {

            #region register controllers
            //Is not necessary register Controllers
            //container.Register<HomeController, HomeController>(LifeCycle.Transient);
            #endregion

            container.Register<IService, Service>();

        }
    }
}
```

And initiate and register the container in your Globa.asax

```C#
//code omitted for simplicity
var container = new IocContainer();
Startup.Configure(container);
ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(container));
```

In the last step, now you can use your service into Controller

```C#
//code omitted for simplicity
private IService service;

public HomeController(IService service) => this.service = service;

```

- It is important to note that Control Class, Example HomeController, are automatically register by the containers.
- The purpose of this code is only for study.
- This code is based on this article, published in 2010 by Tim Ross: [Creating a Simple IoC Container ](https://timross.wordpress.com/2010/01/21/creating-a-simple-ioc-container/) 
