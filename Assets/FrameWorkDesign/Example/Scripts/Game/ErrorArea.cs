using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class ErrorArea : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            Debug.Log("ErrorArea");
            this.SendCommand(new MissCommand());
        }
    }
}
