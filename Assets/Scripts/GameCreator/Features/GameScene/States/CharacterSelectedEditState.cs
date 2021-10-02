using UnityEngine;

namespace GameCreator.Features.GameScene.States
{
    public class CharacterSelectedEditState : AGameSceneState
    {
        GameObject selectedCharacter;

        public void Select(GameObject character)
        {
            selectedCharacter = character;
            gameSceneRoot.ShowCharacterUi(selectedCharacter);
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
            var newSelectedCharacter = hit.transform.gameObject;
            if (newSelectedCharacter.GetInstanceID() == selectedCharacter.GetInstanceID())
            {
                return;
            }

            gameSceneRoot.SelectCharacter(newSelectedCharacter);
        }

        void HandleTerrainMouseDown(Vector3 position)
        {
            gameSceneRoot.SetDefaultEditState();
        }
    }
}