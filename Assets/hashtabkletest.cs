using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class hashtabkletest : MonoBehaviour
    {
        // Start is called before the first frame update
      public  Hashtable hashtable = new();
        void Start()
        {
            //hashtable.Add(11, "aaa");
            //hashtable.Add(12, "aaa");
            hashtable.Add(new Person() { Age=80,Name= "成铠甲" }, "科学家");
            hashtable.Add(new Person() { Age = 80, Name = "成铠甲" }, "科学家");

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                foreach (var item in hashtable.Keys)
                {
                    Debug.Log("键："+ item+"  "+hashtable[item]);
                }
            }
        }
    }
}
public class Person 
{
    private string name;
    private int age;

    public Person()
    {
       
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }

    public override bool Equals(System.Object o)
    {
        Person other = o as Person;
        if (name == other.Name && age == other.Age)
        {
            return true;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(name, age);
    }
}
