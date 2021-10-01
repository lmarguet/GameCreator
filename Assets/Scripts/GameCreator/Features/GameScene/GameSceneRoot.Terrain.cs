using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        bool isTerrainPressed;
        
        void OnTerrainPress(Vector3 hitPoint)
        {
            if (!isTerrainPressed)
            {
                OnTerrainMouseDown(hitPoint);
            }

            isTerrainPressed = true;
        }

        void OnTerrainMouseDown(Vector3 hitPoint)
        {
            if (!string.IsNullOrEmpty(selectedCharacter))
            {
                AddCharacter(selectedCharacter, hitPoint);
            }
        }
    }
}