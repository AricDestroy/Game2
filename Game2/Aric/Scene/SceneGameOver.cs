using Gaming.Aric.Assets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric.Scene
{
    class SceneGameOver: Gaming.Aric.Scene.Scene
    {

        public SceneGameOver(MainGame mainGame) : base(mainGame)
        {
        }

        public override void Load()
        {
            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.DrawString(AssetManager.MainFont,
                "This is the game over",
                new Vector2(1, 1),
                Color.White);


            base.Draw(gameTime);
        }
    }
}
