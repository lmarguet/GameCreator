using GameCreator.Config;
using GameCreator.Features.Characters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.EditModeUi.ToolBars
{
    public class CharactersToolBar : AToolBarView
    {
        [Inject] CharactersConfig charactersConfig;
        [Inject] StartCharacterPlacementCommand startCharacterPlacementCommand;
        [Inject] StopCharacterPlacementCommand stopCharacterPlacementCommand;

        [SerializeField] Transform buttonsContainer;
        [SerializeField] ToggleGroup toggleGroup;
        [SerializeField] CharacterButton characterButtonPrefab; 

        public override ToolBarType Type => ToolBarType.Characters;
        
        void Start()
        {
            InitButtons();
        }

        void InitButtons()
        {
            for (var i = 0; i < charactersConfig.NumCharacters; i++)
            {
                var characterConfig = charactersConfig.GetCharacterConfig(i);
                var characterButton = Instantiate(characterButtonPrefab, buttonsContainer);
                characterButton.SetToggleGroup(toggleGroup);
                characterButton.SetCharacter(characterConfig);
                characterButton.OnSelect.AddListener(HandleCharacterSelect);
                characterButton.OnDesselect.AddListener(HandleCharacterDeselect);
            }
        }
        
        void HandleCharacterSelect(string characterId)
        {
            startCharacterPlacementCommand.Execute(characterId);
        }

        void HandleCharacterDeselect(string characterId)
        {
            stopCharacterPlacementCommand.Execute();
        }

        protected override void DoCloseInternal()
        {
            UnToggle();
        }

        public void UnToggle()
        {
            toggleGroup.SetAllTogglesOff();
        }
    }
}