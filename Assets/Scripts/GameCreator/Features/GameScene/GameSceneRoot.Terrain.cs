using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public readonly Signal<Vector3> OnTerrainMouseDown = new Signal<Vector3>();
        public readonly Signal<Vector3> OnTerrainPress = new Signal<Vector3>();

        bool isTerrainPressed;

        void HandleTerrainPress(Vector3 hitPoint)
        {
            if (!isTerrainPressed)
            {
                OnTerrainMouseDown.Dispatch(hitPoint);
                if (isCharacterSelected)
                {
                    DeselectCharacter();
                }
            }

            OnTerrainPress.Dispatch(hitPoint);
            isTerrainPressed = true;
        }
    }
}