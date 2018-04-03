using Gaming.Aric.Actor;
using Gaming.Aric.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric.Scene
{
    class SceneMenu : Gaming.Aric.Scene.Scene
    {
        private Button MyButton;
        KeyboardState oldKBState;
        public SceneMenu(MainGame mainGame) : base(mainGame)
        {
        }

        public override void Load(){
            oldKBState = Keyboard.GetState();

            Rectangle Screen = game.Window.ClientBounds;
            MyButton = new Button(game.Content.Load<Texture2D>("button"));

            MyButton.Position = new Vector2(
            (Screen.Width / 2) - MyButton.Texture.Width /2,
            (Screen.Height / 2) - MyButton.Texture.Height / 2 );

            MyButton.onClick = OnClickPlay;

            actors.Add(MyButton);
            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public void OnClickPlay(Button sender)
        {
            game.gameState.ChangeScene(GameState.SceneType.GamePlay);
        }

        public override void Update(GameTime gameTime)
        {
            //KeyBoard state 
            KeyboardState newKBState = Keyboard.GetState();


            //Pause switch
            if (newKBState.IsKeyDown(Keys.Space) && !oldKBState.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("Space on the menu !");
                game.gameState.ChangeScene(GameState.SceneType.GamePlay);
            }

            oldKBState = Keyboard.GetState();
            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            
            game.spriteBatch.DrawString(AssetManager.MainFont,
                "This is the menu",
                new Vector2(1, 1),
                Color.White);
             

            
            base.Draw(gameTime);
        }
    }
}
