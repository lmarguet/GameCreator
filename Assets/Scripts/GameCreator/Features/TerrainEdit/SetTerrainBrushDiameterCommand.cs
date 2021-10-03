using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.TerrainEdit
{
    public class SetTerrainBrushDiameterCommand : ACommand<float>
    {
        [Inject] NavigationManager navigationManager;
        
        public override void Execute(float diameter)
        {
            var sceneRoot = navigationManager.GetScene<GameSceneRoot>();
            sceneRoot.SetTerrainBrushDiameter(diameter);
        }
    }
}