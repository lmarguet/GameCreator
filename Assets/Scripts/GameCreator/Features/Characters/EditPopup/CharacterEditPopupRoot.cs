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
        [Inject] SetCharacterTypeCommand setCharacterTypeCommand;

        [SerializeField] Button closeButton;
        [SerializeField] Button deleteButton;
        [SerializeField] Toggle playerToggle;
        [SerializeField] Toggle npcToggle;

        CharacterView character;

        void Awake()
        {
            closeButton.onClick.AddListener(HandleCloseClick);
            deleteButton.onClick.AddListener(HandleDeleteClick);

            playerToggle.onValueChanged.AddListener(HandlePlayerToggle);
            npcToggle.onValueChanged.AddListener(HandleNpcToggle);

            npcToggle.isOn = true;
        }

        public void SetCharacter(CharacterView character)
        {
            this.character = character;
            
            playerToggle.isOn = character.characterType == CharacterType.Player;
            npcToggle.isOn = character.characterType == CharacterType.NPC;
        }

        void HandlePlayerToggle(bool selected)
        {
            if (selected && character != null)
            {
                setCharacterTypeCommand.Execute(new SetCharacterTypeCommand.Data
                {
                    CharacterView = character,
                    CharacterType = CharacterType.Player
                });
                character.SetType(CharacterType.Player);
            }
        }

        void HandleNpcToggle(bool selected)
        {
            if (selected && character != null)
            {
                setCharacterTypeCommand.Execute(new SetCharacterTypeCommand.Data
                {
                    CharacterView = character,
                    CharacterType = CharacterType.NPC
                });
            }
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