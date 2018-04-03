using Gaming.Aric.Actor;
using Gaming.Aric.Assets;
using Gaming.Aric.Util;
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
    class SceneGamePlay: Gaming.Aric.Scene.Scene
    {
        Hero MyShip;

        public SceneGamePlay(MainGame mainGame) : base(mainGame)
        {
        }

        public override void Load()
        {
            Rectangle Screen = game.Window.ClientBounds;

            MyShip = new Hero(AssetManager.ShipTexture);
            MyShip.Position = new Vector2(
                Screen.Width / 2 - MyShip.Texture.Width / 2,
                Screen.Height / 2 - MyShip.Texture.Height / 2);

            actors.Add(MyShip);

            for (int i = 0; i < 10; i++)
            {
                Meteor m = new Meteor(game.Content.Load<Texture2D>("meteor"));
                m.Position = new Vector2(
                Randomizer.GetInt(1, Screen.Width - m.Texture.Width),
                Randomizer.GetInt(1, Screen.Height - m.Texture.Height)
                );

                actors.Add(m);

            }
            
            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle Screen = game.Window.ClientBounds;

            foreach(IActor Actor in actors)
            {
                if (Actor is Meteor m)
                {
                    if (m.Position.X < 0)
                    {
                        m.vX = -m.vX;
                        m.Position = new Vector2(0, m.Position.Y);
                    }else if(m.Position.X + m.Texture.Width > Screen.Width){
                        m.vX = -m.vX;
                        m.Position = new Vector2(Screen.Width - m.BoundingBox.Width, m.Position.Y);
                    }

                    if (m.Position.Y < 0)
                    {
                        m.vY = -m.vY;
                        m.Position = new Vector2(m.Position.X, 0);
                    }
                    else if (m.Position.Y + m.Texture.Height > Screen.Height)
                    {
                        m.vY = -m.vY;
                        m.Position = new Vector2(m.Position.X, Screen.Height - m.BoundingBox.Height);
                    }

                    if (Collider.CollideByBox(m, MyShip))
                    {
                        MyShip.TouchedBy(m);
                        m.TouchedBy(MyShip);

                        if (MyShip.Energy <= 0)
                        {
                            game.gameState.ChangeScene(GameState.SceneType.GameOver);
                     
                        }
                    }
                }
            }







            PadManagement();

            KeyManagement();
            //Mouse information
            MouseState mouseState = Mouse.GetState();
            //Debug.Write(mouseState.X + "," + mouseState.Y + "," + mouseState.LeftButton);

            base.Update(gameTime);
        }

        private void PadManagement()
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);


            //Check is gamepad is connected
            if (capabilities.IsConnected)
            {
                //get all information about gamepad
                GamePadState PadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);

                if (PadState.IsButtonDown(Buttons.A))
                {
                    Debug.WriteLine("GamePad button A is down");
                }



                if (PadState.IsButtonDown(Buttons.DPadUp))
                {
                    MyShip.Move(0, -1);
                }
                if (PadState.IsButtonDown(Buttons.DPadDown))
                {
                    MyShip.Move(0, 1);
                }
                if (PadState.IsButtonDown(Buttons.DPadLeft))
                {
                    MyShip.Move(-1, 0);
                }
                if (PadState.IsButtonDown(Buttons.DPadRight))
                {
                    MyShip.Move(1, 0);
                }
            }
        }

        private void KeyManagement()
        {
            //Detect if a key is down
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("Fire !");
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                MyShip.Move(0, -1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MyShip.Move(0, 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MyShip.Move(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MyShip.Move(1, 0);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.DrawString(AssetManager.MainFont,
                "This is the gameplay",
                new Vector2(1, 1),
                Color.White);

            game.spriteBatch.DrawString(AssetManager.MainFont,
                MyShip.Energy.ToString(),
               new Vector2(MyShip.Position.X, 1),
               Color.White);

            base.Draw(gameTime);
        }
    }
}
