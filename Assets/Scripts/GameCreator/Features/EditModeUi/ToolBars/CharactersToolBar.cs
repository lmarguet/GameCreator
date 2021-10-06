using System.Linq;
using GameCreator.Config;
using GameCreator.Features.Characters;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.EditModeUi.ToolBars
{
    public class CharactersToolBar : AToolBarView
    {
        [Inject] CharactersConfig charactersConfig;
        [Inject] StartCharacterPlacementCommand startCharacterPlacementCommand;
        [Inject] StopCharacterPlacementCommand stopCharacterPlacementCommand;

        [SerializeField] Transform buttonsContainer;
        [SerializeField] CharacterButton characterButtonPrefab;

        CharacterButton[] buttons;

        public override ToolBarType Type => ToolBarType.Characters;

        void Start()
        {
            InitButtons();
        }

        void InitButtons()
        {
            buttons = new CharacterButton[charactersConfig.NumCharacters];

            for (var i = 0; i < charactersConfig.NumCharacters; i++)
            {
                var characterConfig = charactersConfig.GetCharacterConfig(i);
                var characterButton = Instantiate(characterButtonPrefab, buttonsContainer);
                characterButton.SetCharacter(characterConfig);
                characterButton.OnSelect.AddListener(HandleCharacterSelect);
                characterButton.OnDesselect.AddListener(HandleCharacterDeselect);
                buttons[i] = characterButton;
            }
        }

        void HandleCharacterSelect(string characterId)
        {
            DeselectAllBut(characterId);
            startCharacterPlacementCommand.Execute(characterId);
        }

        void HandleCharacterDeselect(string characterId)
        {
            if(!buttons.Any(x => x.Toggle.isOn))
            {
                stopCharacterPlacementCommand.Execute();
            }
            
        }

        protected override void DoCloseInternal()
        {
            DeselectAll();
        }

        void DeselectAllBut(string characterId)
        {
            foreach (var button in buttons)
            {
                if (button.CharacterId != characterId)
                {
                    button.Toggle.isOn = false;
                }
            }
        }

        public void DeselectAll()
        {
            foreach (var button in buttons)
            {
                button.Toggle.isOn = false;
            }
        }
    }
}