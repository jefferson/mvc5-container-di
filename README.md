# mvc5-container-di
An example container for implementing dependency injection does not MVC5

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

- It is important to note that Control Class, Example HomeController, are automatically register by the containers.
- The purpose of this code is only for study purpose
- This code is based on this article, published in 2010 by Tim Ross: [Creating a Simple IoC Container ](https://timross.wordpress.com/2010/01/21/creating-a-simple-ioc-container/) 
