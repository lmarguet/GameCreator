using GameCreator.Features.Characters;

namespace GameCreator.Features.GameScene.States
{
    public class EditDefaultState : AGameSceneState
    {
        protected override void OnEnable()
        {
            gameSceneRoot.StopAllCharactersAnimations();
            gameSceneRoot.HideCharacterUi();
            gameSceneRoot.ResetCamera();
            gameSceneRoot.HideTerrainProjector();

            gameSceneRoot.OnCharacterMouseDown.AddListener(HandleCharacterMouseDown);
            gameSceneRoot.OnCharacterPlacementSelected.AddListener(HandleStartPlacingCharacter);
        }

        void HandleStartPlacingCharacter(string character)
        {
            gameSceneRoot.StartCharacterPlacement(character);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.OnCharacterMouseDown.RemoveListener(HandleCharacterMouseDown);
            gameSceneRoot.OnCharacterPlacementSelected.RemoveListener(HandleStartPlacingCharacter);
        }

        void HandleCharacterMouseDown(CharacterView characterView)
        {
            gameSceneRoot.SelectCharacter(characterView);
        }
    }
}