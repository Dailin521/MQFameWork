using System;
namespace FrameWorkDesign
{
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue = default;
        public T Value
        {
            get => mValue;
            set
            {
                if (!value.Equals(mValue))
                {
                    mValue = value;
                    mOnValueChanged?.Invoke(mValue);
                }
            }
        }
        private Action<T> mOnValueChanged = (v) => { };

        public IUnRegister Register(Action<T> onValueChanged)
        {
            mOnValueChanged += onValueChanged;
            return new BindablePropertyUnRegister<T>()
            {
                BindableProperty = this,
                OnValueChanged = onValueChanged
            };
        }

        public IUnRegister RegisterWithInitValue(Action<T> onValueChanged)
        {
            onValueChanged(mValue);
            return Register(onValueChanged);
        }
        public void UnRegisterOnValueChanged(Action<T> onValueChanged)
        {
            mOnValueChanged -= onValueChanged;
        }

    }
    public class BindablePropertyUnRegister<T> : IUnRegister where T : IEquatable<T>
    {
        public BindableProperty<T> BindableProperty { get; set; }

        public Action<T> OnValueChanged { get; set; }

        public void UnRegister()
        {
            BindableProperty.UnRegisterOnValueChanged(OnValueChanged);
            BindableProperty = null;
            OnValueChanged = null;
        }
    }
}
