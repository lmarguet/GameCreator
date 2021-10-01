using System.Collections.Generic;
using System.Linq;
using GameCreator.Features.EditMode.ToolBars;
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

        [SerializeField] AToolBarView[] toolBarViews;

        void Awake()
        {
            settingsButton.onClick.AddListener(HandleSettingsButtonClick);
            playModeButton.onClick.AddListener(HandlePlaysButtonClick);
            charactersButton.onClick.AddListener(HandleCharactersButtonClick);
            terrainEdioButton.onClick.AddListener(HandleTerrainEditButtonClick);
            locationEditButton.onClick.AddListener(HandleLocationButtonClick);

            HideToolBarContainer();
            InitToolBars();
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

        void HandleTerrainEditButtonClick()
        {
            ShowToolBar(ToolBarType.TerrainEdit);
        }

        void HandleCharactersButtonClick()
        {
            ShowToolBar(ToolBarType.Charcters);
        }

        void HandleLocationButtonClick()
        {
            ShowToolBar(ToolBarType.LocationEdit);
        }

        void InitToolBars()
        {
            foreach (var toolBarView in toolBarViews)
            {
                toolBarView.Hide();
                toolBarView.OnClose.AddListener(OnToolBarClose);
            }
        }

        void OnToolBarClose()
        {
            HideToolBarContainer();
        }

        void ShowToolBar(ToolBarType toolBarType)
        {
            var toolBarView = toolBarViews.First(x => x.Type == toolBarType);
            toolBarView.Show();
            ShowToolBarContainer();
        }

        void ShowToolBarContainer()
        {
            HideBottomMenu();
            toolbarContainer.gameObject.SetActive(true);
            toolbarContainer.alpha = 1;
        }

        void HideToolBarContainer()
        {
            ShowBottomMenu();
            toolbarContainer.gameObject.SetActive(false);
            toolbarContainer.alpha = 0;
        }

        void HideBottomMenu()
        {
            bottomMenu.alpha = 0;
            bottomMenu.gameObject.SetActive(false);
        }

        void ShowBottomMenu()
        {
            bottomMenu.alpha = 1;
            bottomMenu.gameObject.SetActive(true);
        }
    }
}