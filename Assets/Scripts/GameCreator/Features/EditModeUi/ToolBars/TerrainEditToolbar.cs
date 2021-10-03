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
        [Inject] SetTerrainBrushDiameterCommand setTerrainBrushDiameterCommand;
        [Inject] ClearLatestTerrainModifications clearLatestTerrainModifications;

        [SerializeField] Toggle raiseToggle;
        [SerializeField] Toggle loweToggle;
        [SerializeField] Slider diameterSlider;
        [SerializeField] Button clearButton;

        void Start()
        {
            raiseToggle.onValueChanged.AddListener(HandleRaiseToggle);
            loweToggle.onValueChanged.AddListener(HandleLowerToggle);
            diameterSlider.onValueChanged.AddListener(HandleDiameterChange);
            clearButton.onClick.AddListener(HandleClearClick);
        }

        void HandleClearClick()
        {
            clearLatestTerrainModifications.Execute();
            Close();
        }

        protected override void OnShow()
        {
            var editMode = raiseToggle.isOn ? TerrainEditMode.Raise : TerrainEditMode.Lower;
            setTerrainEditModeCommand.Execute(editMode);
            setTerrainBrushDiameterCommand.Execute(diameterSlider.value);
        }

        void HandleDiameterChange(float value)
        {
            value = Mathf.Max(value, 0.05f);
            setTerrainBrushDiameterCommand.Execute(value);
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