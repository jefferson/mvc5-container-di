using System;
using System.Collections.Generic;
using System.Linq;

namespace Container
{
    public class IocContainer : IContainer
    {
        private readonly List<RegisteredObject> _services = new List<RegisteredObject>();

        public void Register<T, TConcrete>()
        {
            Register<T, TConcrete>(LifeCycle.Singleton);
        }

        public void Register<T, TConcrete>(LifeCycle lifeCycle)
        {
            _services.Add(new RegisteredObject(typeof(T), typeof(TConcrete), lifeCycle));
        }

        public T Resolve<T>()
        {
            return (T) ResolveObject(typeof(T));
        }      

        public object Resolve(Type typeResolve)
        {
            return ResolveObject(typeResolve);
        }

        private object ResolveObject(Type type)
        {
            var service = _services.FirstOrDefault(x => x.TypeToResolve == type);

            #region auto register System.Web.Mvc.Controller

            if(service == null)
            {
                if(typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                {
                    var controller = new RegisteredObject(type, type, LifeCycle.Transient);

                    service = controller;

                    _services.Add(controller);

                }
            }

            #endregion

            if( service == null)
            {
                throw new TypeNotRegisteredExceoption(string.Format("The type {0} was not found", type));
            }

            return GetInstance(service);
        }

        private object GetInstance(RegisteredObject service)
        {
            if(service.Instance == null || service.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(service);
                service.CreateInstance(parameters.ToArray());
            }

            return service.Instance;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject service)
        {
            var constructorInfo = service.ConcreteType.GetConstructors().First();

            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }
}
