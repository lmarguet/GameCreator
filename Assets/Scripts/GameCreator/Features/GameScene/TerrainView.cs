using Lean.Touch;
using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public class TerrainView : MonoBehaviour
    {
        public readonly Signal MouseUp = new Signal();
        public readonly Signal MouseDown = new Signal();
        public readonly Signal MouseDrag = new Signal();

        void OnMouseUp()
        {
            ProcessEvent(MouseUp);
        }

        void OnMouseDown()
        {
            ProcessEvent(MouseDown);
        }

        void OnMouseDrag()
        {
            ProcessEvent(MouseDrag);
        }

        void ProcessEvent(Signal signal)
        {
            if (!LeanTouch.PointOverGui(Input.mousePosition))
            {
                signal.Dispatch();
            }
        }
    }
}