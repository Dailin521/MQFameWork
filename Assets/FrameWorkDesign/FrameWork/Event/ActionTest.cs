using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class ActionTest : MonoBehaviour
    {
        //一般情况
        private void Start()
        {
            //默认情况下只允许单个类之间的转换    子类引用->父类引用 （类型安全）

            Func<A, B> f = OnAction; //Func返回值是B 父类，      A->B ,子类转父类。（类型安全）协变out
                                     //Func 传参数是A，子类      B->A,父类转子类。  调用时，形参更广  逆变in
            f.Invoke(new A());
        }
        private A OnAction(B b)
        {
            return b as A ?? new A();
        }
        public class B { }
        public class A : B { }

    }
}
