using System.Linq;
using GameCreator.Features.EditModeUi.ToolBars;
using GameCreator.Features.PlayMode;
using GameCreator.Features.TerrainEdit;
using GameCreator.Features.TimeSettings;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.EditModeUi
{
    public class EditModeUiRoot : ASceneRoot
    {
        [Inject] LoadPlayModeCommand loadPlayModeCommand;
        [Inject] NavigationManager navigationManager;
        [Inject] EnterTerrainEditStateCommand enterTerrainEditStateCommand;
        [Inject] ExitTerrainEditStateCommand exitTerrainEditStateCommand;
        [Inject] OpenTimeEditPopupCommand openTimeEditPopupCommand;

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
            await loadPlayModeCommand.Run();
            navigationManager.CloseScene(SceneId.EditModeUi);
        }

        void HandleTerrainEditButtonClick()
        {
            ShowToolBar(ToolBarType.TerrainEdit);
            enterTerrainEditStateCommand.Execute();
        }

        void HandleCharactersButtonClick()
        {
            ShowToolBar(ToolBarType.Characters);
        }

        async void HandleLocationButtonClick()
        {
            await openTimeEditPopupCommand.Run();
        }

        void InitToolBars()
        {
            foreach (var toolBarView in toolBarViews)
            {
                toolBarView.Hide();
                toolBarView.OnClose.AddListener(HandleToolbarClose);
            }
        }

        void HandleToolbarClose()
        {
            exitTerrainEditStateCommand.Execute();
            CloseToolBar();
        }

        public void CloseToolBar()
        {
            HideToolBarContainer();
        }

        void ShowToolBar(ToolBarType toolBarType)
        {
            var toolBarView = GetToolBarView(toolBarType);
            toolBarView.Show();
            ShowToolBarContainer();
        }

        AToolBarView GetToolBarView(ToolBarType toolBarType)
        {
            return toolBarViews.First(x => x.Type == toolBarType);
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

        public void DeselectCharacters()
        {
            var charactersToolBar = (CharactersToolBar)GetToolBarView(ToolBarType.Characters);
            charactersToolBar.DeselectAll();
        }
    }
}