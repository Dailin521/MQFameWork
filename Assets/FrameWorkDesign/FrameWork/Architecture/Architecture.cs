using System;
using System.Collections.Generic;
using UnityEngine.Rendering.VirtualTexturing;

namespace FrameWorkDesign
{
    public interface IArchitecture
    {
        T GetUtility<T>() where T : class, IUtility;
        T GetModel<T>() where T : class, IModel;
        void RegisterUtility<T>(T utility) where T : IUtility;
        void RegisterModel<T>(T instance) where T : IModel;
        void RegisterSystem<T>(T system) where T : ISystem;
        void SendCommand<T>() where T : ICommand, new();
        void SendCommand<T>(T command) where T : ICommand;
    }
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        //Model初始化
        private bool mInited = false;
        //model注册列表
        List<ISystem> mSystems = new();
        List<IModel> models = new();
        private static T mArchitecture;
        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }
                return mArchitecture;
            }
        }
        //增加注册
        public static Action<T> OnRegisterPatch = p => { };
        //单例初始化
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
                //补丁
                OnRegisterPatch?.Invoke(mArchitecture);
                //模块初始化
                foreach (var model in mArchitecture.models)
                {
                    model.Init();
                }
                mArchitecture.models.Clear();
                foreach (var system in mArchitecture.mSystems)
                {
                    system.Init();
                }
                mArchitecture.mSystems.Clear();
                mArchitecture.mInited = true;
            }
        }
        //模块注册，子类实现
        protected abstract void Init();
        IOCContainer mContainer = new();
        public static G Get<G>() where G : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<G>();
        }
        public static void Register<R>(R instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<R>(instance);
        }
        public void RegisterModel<T2>(T2 model) where T2 : IModel
        {
            model.SetArchitecture(this);
            mContainer.Register<T2>(model);
            if (!mInited)
            {
                models.Add(model);
            }
            else
            {
                model.Init();
            }
        }
        public void RegisterSystem<T1>(T1 system) where T1 : ISystem
        {
            system.SetArchitecture(this);
            mContainer.Register<T1>(system);
            if (!mInited)
            {
                mSystems.Add(system);
            }
            else
            {
                system.Init();
            }
        }
        public T1 GetUtility<T1>() where T1 : class, IUtility
        {
            return mContainer.Get<T1>();
        }

        public void RegisterUtility<T1>(T1 utility) where T1 : IUtility
        {
            mContainer.Register<T1>(utility);
        }
        public static void OnDestroy()
        {
            mArchitecture = null;
        }

        public T1 GetModel<T1>() where T1 : class, IModel
        {
            return mContainer.Get<T1>();
        }

        public void SendCommand<T1>() where T1 : ICommand, new()
        {
            var command = new T1();
            command.SetArchitecture(this);
            command.Excute();
        }

        public void SendCommand<T1>(T1 command) where T1 : ICommand
        {
            command.SetArchitecture(this);
            command.Excute();
        }
    }
}
