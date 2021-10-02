using GameCreator.Features.Characters;

namespace GameCreator.Features.GameScene.States
{
    public class CharacterSelectedEditState : AGameSceneState
    {
        CharacterView selectedCharacter;

        public void Select(CharacterView character)
        {
            selectedCharacter = character;
            gameSceneRoot.ShowCharacterUi(selectedCharacter);
            selectedCharacter.IsSelected = true;
        }

        protected override void OnEnable()
        {
            gameSceneRoot.TerrainView.MouseDown.AddListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterMouseDown.AddListener(HandleCharacterMouseDown);
            gameSceneRoot.SetCameraControllsEnabled(false);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.TerrainView.MouseDown.RemoveListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterMouseDown.RemoveListener(HandleCharacterMouseDown);
            selectedCharacter.IsSelected = false;
            selectedCharacter = null;
            gameSceneRoot.SetCameraControllsEnabled(true);
        }

        void HandleCharacterMouseDown(CharacterView characterView)
        {
            if (characterView == selectedCharacter)
            {
                return;
            }

            gameSceneRoot.SelectCharacter(characterView);
        }

        void HandleTerrainMouseDown()
        {
            gameSceneRoot.SetDefaultEditState();
        }
    }
}