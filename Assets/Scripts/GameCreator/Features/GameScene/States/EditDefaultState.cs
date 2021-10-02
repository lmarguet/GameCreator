using UnityEngine;

namespace GameCreator.Features.GameScene.States
{
    public class EditDefaultState : AGameSceneState
    {
        protected override void OnEnable()
        {
            gameSceneRoot.StopAllCharactersAnimations();
            gameSceneRoot.HideCharacterUi();
            
            gameSceneRoot.OnCharacterMouseDown.AddListener(HandleCharacterMouseDown);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.OnCharacterMouseDown.RemoveListener(HandleCharacterMouseDown);
        }

        void HandleCharacterMouseDown(RaycastHit hit)
        {
            gameSceneRoot.SelectCharacter(hit.transform.gameObject);
        }
    }
}