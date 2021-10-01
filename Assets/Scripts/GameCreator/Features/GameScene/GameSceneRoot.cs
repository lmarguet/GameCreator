using GameCreator.SceneManagement;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public class GameSceneRoot : ASceneRoot
    {
        [SerializeField] Camera sceneCamera;
        [SerializeField] LayerMask terrainLayer;
        
        string selectedCharacter;
        bool isMousePressed;
        bool isTerrainPressed;

        void Start()
        {
            Debug.Log("[GameSceneRoot] Start");
            isMousePressed = false;
        }

        public void SetSelectedCharacter(string characterId)
        {
            selectedCharacter = characterId;
            Debug.Log(selectedCharacter);
        }

        public void DeselectCharacter()
        {
            selectedCharacter = null;
            Debug.Log("deselect");
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMousePressed = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isMousePressed = false;
            }

            if (isMousePressed)
            {
                var ray = sceneCamera.ScreenPointToRay (Input.mousePosition);

                if (Physics.Raycast (ray, out var hit))
                {
                    var layerMask = 1 << hit.transform.gameObject.layer;
                    if (layerMask == terrainLayer.value)
                    {
                        OnTerrainPress(hit.point);
                    }
                }   
            }
            else
            {
                isTerrainPressed = false;
            }
        }

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
            Debug.Log("Terrain mouse down");
        }
    }
}