using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric
{
    public class GameState
    {

        public enum SceneType
        {
            Menu,
            GamePlay,
            GameOver
        }


        public MainGame mainGame;
        public Scene.Scene CurrentScene { get; set; }

        public GameState(MainGame mainGame)
        {
            this.mainGame = mainGame;
        }

        public void ChangeScene(SceneType sceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.UnLoad();
                CurrentScene = null;
            }

            switch (sceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new Scene.SceneMenu(mainGame);
                    break;
                case SceneType.GamePlay:
                    CurrentScene = new Scene.SceneGamePlay(mainGame);
                    break;
                case SceneType.GameOver:
                    CurrentScene = new Scene.SceneGameOver(mainGame);
                    break;
                default:
                    break;
            }
            CurrentScene.Load();
        }
    }
}
