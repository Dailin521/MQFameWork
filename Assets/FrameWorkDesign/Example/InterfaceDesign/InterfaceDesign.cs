using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class InterfaceDesign : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ICustomScript myScript = new MyClass();
            myScript.Start1();
            myScript.Update1();

        }


    }
    interface ICustomScript
    {
        void Start1();
        void Update1();
    }
    public abstract class CustomScript : ICustomScript
    {
        void ICustomScript.Start1()
        {
            OnStart();
        }

        void ICustomScript.Update1()
        {
            OnUpdate();
        }
        protected abstract void OnStart();
        protected abstract void OnUpdate();
    }
    public class MyClass : CustomScript
    {
        protected override void OnStart()
        {
            Debug.Log("start");

        }

        protected override void OnUpdate()
        {
            Debug.Log("update");
        }
    }
}
