
using FrameWorkDesign;
using System;
using UnityEditor;
using UnityEngine;

namespace CounterApp
{
    public class EditorCountApp : EditorWindow, IController
    {
        public BindableProperty<int> Count => throw new NotImplementedException();

        [MenuItem("EditorCountApp/Open")]
        static void Open()
        {
            CounterApp.OnRegisterPatch += app =>
            {
                app.RegisterUtility<IStorage>(new EditorPrefsStorage());
            };
            var window = GetWindow<EditorCountApp>();
            window.position = new Rect(100, 100, 300, 500);
            window.titleContent = new GUIContent(nameof(EditorCountApp));
            window.Show();
        }



        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                GetArchitecture().SendCommand<AddCountCommand>();
            }
            GUILayout.Label(CounterApp.Get<ICountModel>().Count.Value.ToString());//GUI是实时渲染的
            if (GUILayout.Button("-"))
            {
                GetArchitecture().SendCommand(new SubCountCommand());
            }
        }
        private void OnDestroy()
        {
            CounterApp.OnDestroy();
        }

        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }
}
