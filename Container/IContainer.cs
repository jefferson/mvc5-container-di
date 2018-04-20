using System;

namespace Container
{
    public interface IContainer
    {
        void Register<T, TConcrete>();
        void Register<T, TConcrete>(LifeCycle lifeCycle);
        T Resolve<T>();
        object Resolve(Type typeResolve);
    }
}
