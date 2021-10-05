using GameCreator.Features.Characters;
using GameCreator.Features.EditModeUi;
using GameCreator.Features.TimeSettings;
using GameCreator.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.PlayMode
{
    public class PlayModeUiRoot : ASceneRoot
    {
        [Inject] LoadEditModeUiCommand loadEditModeUiCommand;
        [Inject] NavigationManager navigationManager;
        [Inject] GetCityDataCommand getCityDataCommand;

        [SerializeField] Button editModeButton;
        [SerializeField] Joystick joystick;
        [SerializeField] GameObject cityWidget;
        [SerializeField] TextMeshProUGUI cityNameLabel;
        [SerializeField] TextMeshProUGUI cityTimeLabel;
        [SerializeField] TextMeshProUGUI cityWeatherLabel;

        bool showJoytsick;

        void Awake()
        {
            editModeButton.onClick.AddListener(HandlePlaysButtonClick);
            joystick.gameObject.SetActive(false);
            cityWidget.SetActive(false);
        }

        void Start()
        {
            Debug.Log("[PlayModeUiRoot] Start");
        }

        async void HandlePlaysButtonClick()
        {
            await loadEditModeUiCommand.Run();
            navigationManager.CloseScene(SceneId.PlayModeUi);
        }

        void Update()
        {
            if (showJoytsick)
            {
                JoystickInput.Horizontal = joystick.Horizontal;
                JoystickInput.Vertical = joystick.Vertical;
            }
        }

        public void ShowJoystick(bool show)
        {
            joystick.gameObject.SetActive(show);
            showJoytsick = show;
        }

        public void SetCityData(CityData cityData)
        {
            cityNameLabel.text = cityData.Name;
            cityTimeLabel.text = cityData.LocalTime.ToString("HH:mm");

            var cityWeatherData = cityData.Weather;
            var temperature = GetTemperature(cityWeatherData);
            cityWeatherLabel.text = $"{temperature} - {cityWeatherData.summary.description}";
            
            
            cityWidget.SetActive(true);
        }
        
        static int GetTemperature(Weather cityWeatherData)
        {
            var kelvinTemperature = float.Parse(cityWeatherData.temperature.actual);
            return MathsUtil.ConvertKelvinToCelsius(kelvinTemperature);
        }
    }
}