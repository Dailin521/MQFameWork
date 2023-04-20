using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class hashtabkletest1 : MonoBehaviour
    {
        public ParticleSystem _particleSystem;
        public UnityEngine.Color color;
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
               ChangeColor();
            }
        }
        void ChangeColor()
        {
            //ÐÞ¸ÄÑÕÉ«
            _particleSystem.gameObject.SetActive(false);
            ParticleSystem.MainModule mainModule = _particleSystem.main;
            mainModule.startColor = new ParticleSystem.MinMaxGradient(color);
            _particleSystem.gameObject.SetActive(true);
        }
    }
}
