using System.IO;
using System.Text;
using UnityEngine;

namespace CustomTool
{
    /// <summary>
    /// 自动添加命名空间
    /// </summary>
    public class AddNamespace : UnityEditor.AssetModificationProcessor
    {
        //这个函数在每次新建一个资源时会执行，传入的参数是该资源的meta文件的完整路径
        static void OnWillCreateAsset(string asset)
        {
            //从文本文件中读取数据
            StreamReader sr = new StreamReader("Assets\\Editor\\AddNamespace\\NamespaceData.txt");
            sr.ReadLine();                                      //把第一行忽略掉，光标移到第二行
            bool enable = sr.ReadLine() == "True" ? true : false;               //读取存储的数据，决定是否要设置命名空间
            sr.Close();

            if (enable == true)
            {
                //创建任何文件或资源时都会同时创建一个伴随的.meta文件，两者路径是一样的，所以
                //把传入的参数去掉.meta后缀就是我们需要的文件，下面两行都是去掉后缀名，任选其一就行
                //string filePath = asset.Remove(asset.Length - 5);
                string filePath = asset.Replace(".meta", "");

                if (filePath.EndsWith(".cs") == true)   //如果是cs脚本文件才执行后面的
                {
                    //从文本文件中读取到之前设置的命名空间
                    StreamReader reader = new StreamReader("Assets\\Editor\\AddNamespace\\NamespaceData.txt");
                    string nameSpace = reader.ReadLine();
                    if (string.IsNullOrEmpty(nameSpace) == true)
                    {
                        Debug.LogError("需要设置的命名空间为空");
                        reader.Close();
                        return;
                    }
                    reader.Close();

                    StringBuilder stringBuilder = new StringBuilder();
                    StreamReader streamReader = new StreamReader(filePath);
                    for (int i = 0; i < 4; i++)         //这一轮循环是为了把新建的脚本三行的using和后面的一行空行去掉。
                        streamReader.ReadLine();
                    stringBuilder.Append("using UnityEngine;\n");
                    stringBuilder.Append("namespace " + nameSpace + "\n{\n");  //一个namespace，后面跟上我们需要设置的命名空间的名字，换行，括号，再换行

                    string temp = streamReader.ReadLine();  //这一读取的是  public class NewBehaviourScript : MonoBehaviour
                    //temp = temp.Replace(": MonoBehaviour", "");     //把后面的MonoBehaviour去掉，

                    stringBuilder.Append("    " + temp + "\n");     //把刚刚读取到的字符串添加进来，前面空4格是为了对齐，下面两行同理
                    stringBuilder.Append("    {\n\n");
                    stringBuilder.Append("    }\n}");
                    streamReader.Close();

                    StreamWriter streamWriter = new StreamWriter(filePath);     //把上面的stringBuilder写入，并覆盖原有的字符串
                    streamWriter.Write(stringBuilder);
                    streamWriter.Close();
                }
            }
        }
    }
}
