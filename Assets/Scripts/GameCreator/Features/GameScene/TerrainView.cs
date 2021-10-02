using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public class TerrainView : MonoBehaviour
    {
        readonly public Signal MouseUp = new Signal();
        readonly public Signal MouseDown = new Signal();
        readonly public Signal MouseDrag = new Signal();
        
        void OnMouseUp()
        {
            MouseUp.Dispatch();
        }
        
        void OnMouseDown()
        {
            MouseDown.Dispatch();
        }
        
        void OnMouseDrag()
        {
            MouseDrag.Dispatch();
        }
    }
}