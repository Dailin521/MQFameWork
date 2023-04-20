using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class InterfaceExample : MonoBehaviour, Say
    {
        //接口的隐式实现
        public void SayHello() { 

        }

        public int SayHelloint()
        {
            throw new System.NotImplementedException();
        }

        public Ib11 B11()
        {
            return new B();
        }

        /// <summary>
        /// 接口的显示实现
        /// </summary>
        void Say.SayOther()
        {
           
        }

        
        void Start()
        {
            this.SayHello();//隐式实现可以直接调用，
            SayHelloint();
            this.B11().Sayb2();
        }
        public class B : Ib11
        {
            public void Sayb1()
            {
                
            }

            public void Sayb2()
            {
               
            }
        }
    }
   
    interface Say
    {
       void SayHello();
       int SayHelloint();
        public void SayOther();
        public Ib11 B11();
    }
  public  interface Ib11
    {
        void Sayb1();
        void Sayb2();
    }

}
