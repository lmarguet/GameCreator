using System.Collections.Generic;
using System.Linq;
using GameCreator.Config;
using GameCreator.Features.GameScene;
using GameCreator.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.TimeSettings
{
    public class TimeEditPopupRoot : ASceneRoot
    {
        [Inject] NavigationManager navigationManager;
        [Inject] TimeSettingsConfig timeSettingsConfig;
        [Inject] SetSceneTimeDataCommand setSceneTimeDataCommand;

        [SerializeField] Button closeButton;
        [SerializeField] TMP_Dropdown dropdown;

        List<TMP_Dropdown.OptionData> optionsList;

        void Awake()
        {
            closeButton.onClick.AddListener(HandleCloseClick);
        }

        void Start()
        {
            optionsList = CreateOptionsList();
            dropdown.options = optionsList;
        }

        public void SetCurrenTimeData(GameSceneRoot.SceneTimeData data)
        {
            if (!string.IsNullOrEmpty(data.Name))
            {
                if (optionsList.Any(x => x.text == data.Name))
                {
                    var index = optionsList.FindIndex(x => x.text == data.Name);
                    dropdown.value = index;
                }
            }
        }

        List<TMP_Dropdown.OptionData> CreateOptionsList()
        {
            var options = new List<TMP_Dropdown.OptionData>
            {
                new TMP_Dropdown.OptionData { text = "Day" },
                new TMP_Dropdown.OptionData { text = "Morning" },
                new TMP_Dropdown.OptionData { text = "Evening" },
                new TMP_Dropdown.OptionData { text = "Night" }
            };

            options.AddRange(timeSettingsConfig.Cities.Select(city => new TMP_Dropdown.OptionData { text = city }));

            return options;
        }

        void HandleCloseClick()
        {
            var selectedIndex = dropdown.value;
            var optionText = optionsList[selectedIndex].text;
            var isCity = timeSettingsConfig.Cities.Contains(optionText);

            setSceneTimeDataCommand.Execute(new GameSceneRoot.SceneTimeData
            {
                Name = optionText,
                IsCity = isCity
            });

            navigationManager.CloseScene<TimeEditPopupRoot>();
        }
    }
}