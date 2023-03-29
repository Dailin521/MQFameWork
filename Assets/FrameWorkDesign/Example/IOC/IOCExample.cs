using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        IOCContainer container = new();
        void Start()
        {
            container.Register<IBluetoothManager>(new BluetoothManager());
            container.Register<IBluetoothManager>(new BluetoothManagerB());
            var blutoothManager = container.Get<IBluetoothManager>();
            blutoothManager.Connect();
        }
        interface IBluetoothManager
        {
            void Connect();
        }
        class BluetoothManager : IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("连接成功A");
            }
        }
        class BluetoothManagerB : IBluetoothManager
        {
            public void Connect()
            {
                Debug.Log("连接成功B");
            }
        }
    }
}
