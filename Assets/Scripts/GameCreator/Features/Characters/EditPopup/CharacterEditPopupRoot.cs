using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.Characters.EditPopup
{
    public class CharacterEditPopupRoot : ASceneRoot
    {
        [Inject] NavigationManager navigationManager;
        [Inject] DeleteCharacterCommand deleteCharacterCommand;

        [SerializeField] Button closeButton;
        [SerializeField] Button deleteButton;
        
        CharacterView character;

        void Awake()
        {
            closeButton.onClick.AddListener(HandleCloseClick);
            deleteButton.onClick.AddListener(HandleDeleteClick);
        }

        public void SetCharacter(CharacterView character)
        {
            this.character = character;
        }

        void HandleCloseClick()
        {
            navigationManager.CloseScene<CharacterEditPopupRoot>();
        }

        void HandleDeleteClick()
        {
            deleteCharacterCommand.Execute(character);
            navigationManager.CloseScene<CharacterEditPopupRoot>();
        }
    }
}