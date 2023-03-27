using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class ActionTest : MonoBehaviour
    {


        //一般情况
        char b = new object();// 父类指向子类，可以
        object a = new char(); //子类指向父类，不安全，子类数据可能更多
        public static void NoRetS(string a) { }
        public static void NoRetC(char a) { }
        ////逆变 in
        Action<char> b1 = NoRetS;//子类指向 父类 ，允许。
        Action<char> b2 = NoRetC;  //父类指向子类 报错   


        public static char RetC()
        {
            return new char();
        }
        public static char RetB()
        {
            return new char();
        }
        // 协变out       
        Func<char> f1 = RetB;    //子类指向 父类  报错
        Func<char> f2 = RetC;     //父类指向子类！！！ 没问题


    }
}
