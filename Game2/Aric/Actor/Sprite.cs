using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gaming.Aric.Actor
{
    public class Sprite : IActor
    {
        public Vector2 Position { get; set; }
        public float vX;
        public float vY;

        public Rectangle BoundingBox { get; set; }

        public Texture2D Texture { get; }

        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Move(float x, float y)
        {
            Position = new Vector2(Position.X + x, Position.Y + y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {

            Move(vX, vY);

            BoundingBox = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                Texture.Width,
                Texture.Height);
        }

        public virtual void TouchedBy(IActor actor)
        {
            
        }
    }
}
