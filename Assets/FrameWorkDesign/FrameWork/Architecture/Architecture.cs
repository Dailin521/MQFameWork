namespace FrameWorkDesign
{
    public abstract class Architecture<T> where T : Architecture<T>, new()
    {
        private static T mArchitecture;
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
            }
        }
        protected abstract void Init();
        IOCContainer container = new();
        public static G Get<G>() where G : class
        {
            MakeSureArchitecture();

            return mArchitecture.container.Get<G>();
        }
        public static void Register<R>(R instance) where R : class
        {
            MakeSureArchitecture();
            mArchitecture.container.Register<R>(instance);
        }
    }
}
