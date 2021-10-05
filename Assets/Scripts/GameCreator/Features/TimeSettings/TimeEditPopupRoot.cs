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
                new TMP_Dropdown.OptionData { text = TimeOfTheDay.Day.ToString() },
                new TMP_Dropdown.OptionData { text = TimeOfTheDay.Morning.ToString() },
                new TMP_Dropdown.OptionData { text = TimeOfTheDay.Evening.ToString() },
                new TMP_Dropdown.OptionData { text = TimeOfTheDay.Night.ToString() }
            };

            options.AddRange(timeSettingsConfig.Cities.Select(city => new TMP_Dropdown.OptionData { text = city.Name }));

            return options;
        }

        void HandleCloseClick()
        {
            var selectedIndex = dropdown.value;
            var optionText = optionsList[selectedIndex].text;
            var isCity = timeSettingsConfig.Cities.Any(x => x.Name == optionText);

            setSceneTimeDataCommand.Execute(new GameSceneRoot.SceneTimeData
            {
                Name = optionText,
                IsCity = isCity
            });

            navigationManager.CloseScene<TimeEditPopupRoot>();
        }
    }
}