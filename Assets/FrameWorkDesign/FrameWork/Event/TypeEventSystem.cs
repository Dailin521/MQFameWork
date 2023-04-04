using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign
{
    public interface ITypeEventSystem
    {
        void Send<T>() where T : new();
        void Send<T>(T e);
        IUnRegister Register<T>(Action<T> onEvent);
        void UnRegister<T>(Action<T> onEvent);
    }
    public interface IUnRegister
    {
        void UnRegister();
    }
    public struct TypeEventSystemUnRegister<T> : IUnRegister
    {
        public ITypeEventSystem TypeEventSystem;
        public Action<T> OnEvent;
        public void UnRegister()
        {
            TypeEventSystem.UnRegister<T>(OnEvent);
            TypeEventSystem = null;
            OnEvent = null;
        }
    }
    public class UnRegisterOnDestroyTrigger : MonoBehaviour
    {
        private HashSet<IUnRegister> mUnRegister = new();
        public void AddUnRegister(IUnRegister unRegister)
        {
            mUnRegister.Add(unRegister);
        }
        private void OnDestroy()
        {
            foreach (var unRegister in mUnRegister)
            {
                unRegister.UnRegister();
            }
            mUnRegister.Clear();
        }
    }
    public static class UnRegisterExtension
    {
        public static void UnRegisterWhenGameObjDestroyed(this IUnRegister unRegister, GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();
            if (trigger == null)
            {
                trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
            }
            if (trigger)
                trigger.AddUnRegister(unRegister);
        }
    }
    public class TypeEventSystem : ITypeEventSystem
    {
        public interface IRegistrations
        {

        }
        public class Registrations<T> : IRegistrations
        {
            public Action<T> OnEvent = e => { };
        }
        Dictionary<Type, IRegistrations> mEventRegistration = new();
        public void Send<T>() where T : new()
        {
            var e = new T();
            Send<T>(e);
        }

        public void Send<T>(T e)
        {
            var type = typeof(T);
            if (mEventRegistration.TryGetValue(type, out IRegistrations registrations))
            {
                (registrations as Registrations<T>).OnEvent(e);
            }
        }
        public IUnRegister Register<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            if (mEventRegistration.TryGetValue(type, out IRegistrations registrations))
            {

            }
            else
            {
                registrations = new Registrations<T>();
                mEventRegistration.Add(type, registrations);
            }
            (registrations as Registrations<T>).OnEvent += onEvent;
            return new TypeEventSystemUnRegister<T>()
            {
                OnEvent = onEvent,
                TypeEventSystem = this
            };
        }

        public void UnRegister<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            if (mEventRegistration.TryGetValue(type, out IRegistrations registrations))
            {
                (registrations as Registrations<T>).OnEvent -= onEvent;
            }
        }
    }
}
