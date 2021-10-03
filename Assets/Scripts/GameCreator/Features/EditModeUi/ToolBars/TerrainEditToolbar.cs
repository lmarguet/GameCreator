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

        [SerializeField] Toggle raiseToggle;
        [SerializeField] Toggle loweToggle;
        [SerializeField] Slider diameterSlider;

        protected override void OnShow()
        {
            raiseToggle.isOn = true;
            setTerrainEditModeCommand.Execute(TerrainEditMode.Raise);

            raiseToggle.onValueChanged.AddListener(HandleRaiseToggle);
            loweToggle.onValueChanged.AddListener(HandleLowerToggle);

            diameterSlider.onValueChanged.AddListener(HandleDiameterChange);
            diameterSlider.value = 0.5f;
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