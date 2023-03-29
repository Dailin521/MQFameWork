using System;
namespace FrameWorkDesign
{
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue = default;
        public Action<T> OnValueChanged;
        public T Value
        {
            get => mValue;
            set
            {
                if (!value.Equals(mValue))
                {
                    mValue = value;
                    OnValueChanged?.Invoke(mValue);
                }
            }
        }
    }
}
