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

        public void StartEditingTerrain()
        {
            SetState(terrainEditState);
        }
        
        public void StopEditingTerrain()
        {
            SetState(editDefaultState);
        }

        public void ModifyTerrain()
        {
            DoTerrainMouseRaycast(out var hit);
            
            Debug.Log(hit.point);
        }
    }
}