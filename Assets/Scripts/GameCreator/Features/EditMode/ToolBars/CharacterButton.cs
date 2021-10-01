using System;
using GameCreator.Config;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameCreator.Features.EditMode.ToolBars
{
    public class CharacterButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public readonly Signal<string> OnSelect = new Signal<string>();
        public readonly Signal<string> OnDesselect = new Signal<string>();

        [SerializeField] Image icon;
        [SerializeField] Image backgroundImage;
        [SerializeField] Sprite normalSprite;
        [SerializeField] Sprite selectedSprite;
        [SerializeField] Sprite pressedSprite;

        string characterId;
        Toggle toggle;

        Toggle Toggle => toggle ? toggle : toggle = GetComponent<Toggle>();

        void Awake()
        {
            Toggle.onValueChanged.AddListener(OnToggleValueChanged);

            ShowNormalState();
        }

        void OnToggleValueChanged(bool selected)
        {
            if (string.IsNullOrEmpty(characterId))
            {
                throw new Exception($"[{name}] {nameof(characterId)} is missing");
            }

            if (selected)
            {
                backgroundImage.sprite = selectedSprite;
                OnSelect.Dispatch(characterId);
            }
            else
            {
                ShowNormalState();
                OnDesselect.Dispatch(characterId);
            }
        }

        void ShowNormalState()
        {
            backgroundImage.sprite = normalSprite;
        }

        public void SetToggleGroup(ToggleGroup toggleGroup)
        {
            Toggle.group = toggleGroup;
        }

        public void SetCharacter(CharactersConfig.CharacterConfig characterConfig)
        {
            characterId = characterConfig.Id;
            icon.sprite = characterConfig.ThumbNail;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            backgroundImage.sprite = pressedSprite;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ShowNormalState();
        }
    }
}