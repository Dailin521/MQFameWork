using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class InterfaceExample : MonoBehaviour, Say
    {
        //接口的隐式实现
        public void SayHello() { }

        /// <summary>
        /// 接口的显示实现
        /// </summary>
        void Say.SayOther() { }
        void Start()
        {
            this.SayHello();//隐式实现可以直接调用，

        }

    }
    interface Say
    {
        void SayHello();
        void SayOther();
    }

}
