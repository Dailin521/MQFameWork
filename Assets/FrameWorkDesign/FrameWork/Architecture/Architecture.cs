using System;
using System.Collections.Generic;

namespace FrameWorkDesign
{
    public interface IArchitecture
    {
        T GetUtility<T>() where T : class;
        void RegisterUtility<T>(T utility);
        void RegisterModel<T>(T instance) where T : IModel;

    }
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        //Model初始化
        private bool mInited = false;
        //model注册列表
        List<IModel> models = new();
        private static T mArchitecture;
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
            model.Architecture = this;
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
        public T1 GetUtility<T1>() where T1 : class
        {
            return mContainer.Get<T1>();
        }

        public void RegisterUtility<T1>(T1 utility)
        {
            mContainer.Register<T1>(utility);
        }
        public static void OnDestroy()
        {
            mArchitecture = null;
        }
    }
}
