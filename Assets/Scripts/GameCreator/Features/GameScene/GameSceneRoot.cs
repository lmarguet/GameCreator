using GameCreator.Config;
using GameCreator.SceneManagement;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public class GameSceneRoot : ASceneRoot
    {
        [Inject] CharactersConfig charactersConfig;
        [Inject] DeselectCharacterCommand deselectCharacterCommand;
        
        [SerializeField] Camera sceneCamera;
        [SerializeField] LayerMask terrainLayer;
        [SerializeField] Transform charactersContainer;

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
                var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
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
            if (!string.IsNullOrEmpty(selectedCharacter))
            {
                AddCharacter(selectedCharacter, hitPoint);
                
            }
        }

        void AddCharacter(string character, Vector3 hitPoint)
        {
            deselectCharacterCommand.Execute();
            
            var config = charactersConfig.GetCharacterConfig(character);
            var characterView = Instantiate(config.Prefab, hitPoint, Quaternion.Euler(0, 180, 0));
            characterView.transform.parent = charactersContainer;
        }
    }
}