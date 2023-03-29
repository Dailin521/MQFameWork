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
            container.Register(new BluetoothManager());
            var blutoothManager = container.Get<BluetoothManager>();
            blutoothManager.Connect();
        }

        class BluetoothManager
        {
            public void Connect()
            {
                Debug.Log("连接成功");
            }
        }
    }
}
