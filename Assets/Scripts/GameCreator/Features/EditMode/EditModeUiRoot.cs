using GameCreator.Features.PlayMode;
using GameCreator.Features.SettingsPopup;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.EditMode
{
    public class EditModeUiRoot : ASceneRoot
    {
        [Inject] LoadSettingsPopupCommand loadSettingsPopupCommand;
        [Inject] LoadPlayModeUiCommand loadPlayModeUiCommand;
        [Inject] CloseSceneCommand closeSceneCommand;

        [SerializeField] Button settingsButton;
        [SerializeField] Button playModeButton;
        
        [Header("Bottom menu")]
        [SerializeField] CanvasGroup bottomMenu;
        [SerializeField] Button charactersButton;
        [SerializeField] Button terrainEdioButton;
        [SerializeField] Button locationEditButton;
        
        
        [Header("Toolbar")]
        [SerializeField] CanvasGroup toolbarContainer;

        void Awake()
        {
            settingsButton.onClick.AddListener(HandleSettingsButtonClick);
            playModeButton.onClick.AddListener(HandlePlaysButtonClick);
            charactersButton.onClick.AddListener(HandleCharactersButtonClick);
            terrainEdioButton.onClick.AddListener(HandleTerrainEditButtonClick);
            locationEditButton.onClick.AddListener(HandleLocationButtonClick);

            HideToolBar();
        }

        void Start()
        {
            Debug.Log("[EditModeUiRoot] Start");
        }

        async void HandlePlaysButtonClick()
        {
            await loadPlayModeUiCommand.Run();
            closeSceneCommand.Execute(SceneId.EditModeUi);
        }

        async void HandleSettingsButtonClick()
        {
            await loadSettingsPopupCommand.Run();
        }

        void HandleLocationButtonClick()
        {
            throw new System.NotImplementedException();
        }

        void HandleTerrainEditButtonClick()
        {
            throw new System.NotImplementedException();
        }

        void HandleCharactersButtonClick()
        {
            // TODO refactor to pass tool bar type
            ShowToolBar();
        }

        void ShowToolBar()
        {
            HideBottomMenu();
            toolbarContainer.gameObject.SetActive(true);
            toolbarContainer.alpha = 1;
        }
        
        void HideToolBar()
        {
            ShowBottomMenu();
            toolbarContainer.gameObject.SetActive(false);
            toolbarContainer.alpha = 0;
        }

        void HideBottomMenu()
        {
            bottomMenu.alpha = 0;
        }

        void ShowBottomMenu()
        {
            bottomMenu.alpha = 1;
        }
    }
}