using UnityEngine;

namespace FrameWorkDesign
{
    public interface ICanSetArchitecture : IBelongToArchitecture
    {
        void SetArchitecture(IArchitecture architecture);
    }
}
