using System;

namespace Official.Framework.Core
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        void Release();
    }
}
