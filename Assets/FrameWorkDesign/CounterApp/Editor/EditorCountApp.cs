using CounterApp;
using UnityEditor;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class EditorCountApp : EditorWindow
    {
        [MenuItem("EditorCountApp/Open")]
        static void Open()
        {
            var window = GetWindow<EditorCountApp>();
            window.position = new Rect(100, 100, 300, 500);
            window.titleContent = new GUIContent(nameof(EditorCountApp));
            window.Show();
        }
        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                new AddCountCommand().Excute();
            }
            GUILayout.Label(CountModel.Instance.Count.Value.ToString());//GUI是实时渲染的
            if (GUILayout.Button("-"))
            {
                new SubCountCommand().Excute();
            }
        }
    }
}
