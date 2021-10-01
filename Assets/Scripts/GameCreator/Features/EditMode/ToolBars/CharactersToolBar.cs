using GameCreator.Config;
using GameCreator.Features.GameScene;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.EditMode.ToolBars
{
    public class CharactersToolBar : AToolBarView
    {
        [Inject] CharactersConfig charactersConfig;
        [Inject] SelectedCharacterCommand selectedCharacterCommand;
        [Inject] DeselectCharacterCommand deselectCharacterCommand;

        [SerializeField] Transform buttonsContainer;
        [SerializeField] ToggleGroup toggleGroup;
        [SerializeField] CharacterButton characterButtonPrefab; 

        public override ToolBarType Type => ToolBarType.Charcters;
        
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
            selectedCharacterCommand.Execute(characterId);
        }

        void HandleCharacterDeselect(string characterId)
        {
            deselectCharacterCommand.Execute();
        }

        protected override void DoCloseInternal()
        {
            toggleGroup.SetAllTogglesOff();
        }

    }
}