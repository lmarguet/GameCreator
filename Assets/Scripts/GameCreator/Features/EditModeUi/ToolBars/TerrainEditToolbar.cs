using GameCreator.Features.TerrainEdit;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameCreator.Features.EditModeUi.ToolBars
{
    public class TerrainEditToolbar : AToolBarView
    {
        public override ToolBarType Type => ToolBarType.TerrainEdit;

        [Inject] SetTerrainEditModeCommand setTerrainEditModeCommand;

        [SerializeField] Toggle raiseToggle;
        [SerializeField] Toggle loweToggle;
        [SerializeField] ToggleGroup toggleGroup;

        void Start()
        {
            raiseToggle.isOn = true;
            setTerrainEditModeCommand.Execute(TerrainEditMode.Raise);

            raiseToggle.onValueChanged.AddListener(HandleRaiseToggle);
            loweToggle.onValueChanged.AddListener(HandleLowerToggle);
        }

        void HandleRaiseToggle(bool selected)
        {
            if (selected)
            {
                setTerrainEditModeCommand.Execute(TerrainEditMode.Raise);
            }
        }

        void HandleLowerToggle(bool selected)
        {
            if (selected)
            {
                setTerrainEditModeCommand.Execute(TerrainEditMode.Lower);
            }
        }
    }
}