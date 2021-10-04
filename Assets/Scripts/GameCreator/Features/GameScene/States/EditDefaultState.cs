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
        }

        protected override void OnDisable()
        {
            gameSceneRoot.OnCharacterMouseDown.RemoveListener(HandleCharacterMouseDown);
        }

        void HandleCharacterMouseDown(CharacterView characterView)
        {
            gameSceneRoot.SelectCharacter(characterView);
        }
    }
}