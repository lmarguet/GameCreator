using GameCreator.Features.Characters;

namespace GameCreator.Features.GameScene.States
{
    public class CharacterDragEditState : AGameSceneState
    {
        CharacterView selectedCharacter;

        protected override void OnEnable()
        {
            gameSceneRoot.OnGlobalMouseUp.AddListener(HandleMouseUp);
            gameSceneRoot.OnCharacterDrag.AddListener(HandleCharacterDrag);

            gameSceneRoot.SetCameraControlsEnabled(false);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.OnGlobalMouseUp.RemoveListener(HandleMouseUp);
            gameSceneRoot.OnCharacterDrag.RemoveListener(HandleCharacterDrag);
        }

        void HandleCharacterDrag(CharacterView obj)
        {
            if (gameSceneRoot.DoTerrainMouseRaycast(out var hit))
            {
                selectedCharacter.transform.position = hit.point;
            }
        }

        void HandleMouseUp()
        {
            gameSceneRoot.SetCameraControlsEnabled(true);
            gameSceneRoot.SelectCharacter(selectedCharacter);
        }

        public void SetCharacter(CharacterView character)
        {
            selectedCharacter = character;
        }
    }
}