using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    /// <summary>
    /// 编辑器上方用于更改命名空间的窗口
    /// </summary>
    public class SetNamespaceWindow : EditorWindow
    {
        private static string Namespace;

        public static bool Enable { get; private set; }

        [MenuItem("Tools/Namespace/SetNamespace")]
        public static void ShowWindow()
        {
            GetWindowWithRect(typeof(SetNamespaceWindow), new Rect(500, 500, 500, 300));    //创建一个窗口

            StreamReader reader = new StreamReader("Assets\\Editor\\AddNamespace\\NamespaceData.txt");
            string input = reader.ReadLine();                       //读取数据文件里的第一行，存储的是命名空间的名字

            if (string.IsNullOrEmpty(input) == true) Namespace = "Please input namespace";
            else Namespace = input;

            Enable = reader.ReadLine() == "True" ? true : false;            //读取第二行，存储的是是否启用此脚本
            reader.Close();
        }

        private void OnGUI()
        {
            GUILayout.Label("Set Namespace", EditorStyles.boldLabel);
            Namespace = EditorGUILayout.TextField("Namespace", Namespace);
            Enable = EditorGUILayout.Toggle("Change Enable", Enable);

            //如果点击按钮，把自己设置的命名空间写进文本文件中，使用时从里面读取
            if (GUILayout.Button("OK"))
            {
                StreamWriter streamWriter = new StreamWriter("Assets\\Editor\\AddNamespace\\NamespaceData.txt");
                streamWriter.WriteLine(Namespace);
                streamWriter.WriteLine(Enable.ToString());
                Debug.Log("命名空间修改成功");
                streamWriter.Close();
            }
        }
    }
}
