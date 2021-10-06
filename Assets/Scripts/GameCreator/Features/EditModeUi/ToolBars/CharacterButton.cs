using System;
using GameCreator.Config;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Features.EditModeUi.ToolBars
{
    public class CharacterButton : MonoBehaviour
    {
        public readonly Signal<string> OnSelect = new Signal<string>();
        public readonly Signal<string> OnDesselect = new Signal<string>();

        [SerializeField] Image icon;

        bool isSelected;
        string characterId;
        Toggle toggle;

        public Toggle Toggle => toggle ? toggle : toggle = GetComponent<Toggle>();
        public string CharacterId => characterId;

        void Awake()
        {
            Toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        void OnToggleValueChanged(bool selected)
        {
            if (string.IsNullOrEmpty(characterId))
            {
                throw new Exception($"[{name}] {nameof(characterId)} is missing");
            }

            if (selected == isSelected)
            {
                return;
            }

            isSelected = selected;
            if (isSelected)
            {
                OnSelect.Dispatch(characterId);
            }
            else
            {
                OnDesselect.Dispatch(characterId);
            }
        }

        public void SetCharacter(CharactersConfig.CharacterConfig characterConfig)
        {
            characterId = characterConfig.Id;
            icon.sprite = characterConfig.ThumbNail;
        }
    }
}