using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class TypeEventSystemExample : MonoBehaviour
    {
        public struct EventA { }
        public struct EventB
        {
            public int paramB;
        }
        public interface IEventGroup { }
        public struct EventC : IEventGroup { }
        public struct EventD : IEventGroup { }
        // Start is called before the first frame update
        private TypeEventSystem mTypeEventSystem = new();
        void Start()
        {
            mTypeEventSystem.Register<EventA>(OnEventA);
            mTypeEventSystem.Register<EventB>(b =>
            {
                Debug.Log("OnEventB " + b.paramB);
                Debug.Log("OnEventB " + b);
            }).UnRegisterWhenGameObjDestroyed(gameObject);
            mTypeEventSystem.Register<IEventGroup>(e =>
            {
                Debug.Log("IEventGroup" + e.GetType());
            }).UnRegisterWhenGameObjDestroyed(gameObject);
        }
        private void OnEventA(EventA obj)
        {
            Debug.Log("OnEventA");
        }
        private void OnDestroy()
        {
            mTypeEventSystem.UnRegister<EventA>(OnEventA);
            mTypeEventSystem = null;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }
            if (Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send<EventB>(new EventB { paramB = 123 });
            }
            if (Input.GetMouseButtonDown(2))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }
    }
}
