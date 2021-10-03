using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        
        public bool DoTerrainMouseRaycast(out RaycastHit hit)
        {
            var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer.value);  
        }
    }
}