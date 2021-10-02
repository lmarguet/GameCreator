using UnityEngine;

namespace GameCreator.Features.GameScene.States
{
    public class EditCharacterSelectedState : AGameSceneState
    {
        GameObject selectedCharacter;

        public void Init(GameObject character)
        {
            selectedCharacter = character;
        }

        protected override void OnEnable()
        {
            gameSceneRoot.OnTerrainMouseDown.AddListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterMouseDown.AddListener(HandleCharacterMouseDown);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.OnTerrainMouseDown.RemoveListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterMouseDown.RemoveListener(HandleCharacterMouseDown);
            selectedCharacter = null;
        }

        void HandleCharacterMouseDown(RaycastHit hit)
        {
            // TODO check if same character
            // TODO deselect current character
            gameSceneRoot.SelectCharacter(hit.transform.gameObject);
        }

        void HandleTerrainMouseDown(Vector3 position)
        {
            gameSceneRoot.SetDefaultEditState();
        }
    }
}