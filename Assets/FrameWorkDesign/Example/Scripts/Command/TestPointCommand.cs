
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public struct TestPointCommand1 : ICommand1
    {
        public void Execute()
        {
            Debug.Log("shuchu1");
        }
    }
    public struct TestPointCommand2 : ICommand1
    {
        public void Execute()
        {
            Debug.Log("shuchu2");
        }
    }
    public interface ICommand1
    {
        void Execute();
    }
}
