using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gaming.Aric.Actor
{

    public delegate void onClick(Button sender);


    public class Button : Sprite
    {
        public bool IsHover { get; private set; }
        private MouseState oldMouseState;
        public onClick onClick;

        public Button(Texture2D texture) : base(texture)
        {
            IsHover = false;
            oldMouseState = Mouse.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;
            
            if (BoundingBox.Contains(MousePos))
            {
                if (!IsHover)
                {
                    IsHover = true;
                    Debug.WriteLine("Button is now Hover");
                }
            }
            else
            {
                
                IsHover = false;
            }
            
            if (IsHover 
                && newMouseState.LeftButton == ButtonState.Pressed
                && oldMouseState.LeftButton != ButtonState.Pressed)
            {
                Debug.WriteLine("Button is clicked");
                if (onClick != null)
                {
                    onClick(this);
                }
                else
                {
                    Debug.Write("click nuil");
                }

            }
            oldMouseState = newMouseState;
            base.Update(gameTime);
        }

    }
}
