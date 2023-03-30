using System;
using System.Collections.Generic;
namespace FrameWorkDesign
{
    public class IOCContainer
    {
        private Dictionary<Type, object> mInstances = new();
        public void Register<T>(T instance)
        {
            var key = typeof(T);
            if (mInstances.ContainsKey(key))
            {
                mInstances[key] = instance;
            }
            else
            {
                mInstances.Add(key, instance);
            }
        }
        public T Get<T>() where T : class
        {
            var key = typeof(T);
            if (mInstances.TryGetValue(key, out object retInstance))
            {
                return retInstance as T;
            }
            return null;
        }
    }
}
