namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public struct SceneTimeData
        {
            public string Name;
            public bool IsCity;
        }

        public SceneTimeData SceneTime => sceneTimeData;

        public void SetSceneTime(SceneTimeData data)
        {
            sceneTimeData = data;
        }
    }
}