using GameCreator.Config;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.EditMode.ToolBars
{
    public class CharactersToolBar : AToolBarView
    {
        [Inject] CharactersConfig charactersConfig;

        [SerializeField] Transform buttonsContainer;
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
                var button = Instantiate(characterButtonPrefab, buttonsContainer);
                button.SetCharacter(characterConfig);
            }
        }
    }
}