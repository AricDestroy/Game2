using Gaming.Aric.Actor;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric.Scene
{
    public abstract class Scene
    {
        protected MainGame game;
        protected List<IActor> actors;


        public Scene(MainGame game)
        {
            this.game = game;
            this.actors = new List<IActor>();
        }

        public virtual void Load() { }
        public virtual void UnLoad() { }
        public virtual void Update(GameTime gameTime)
        {
            foreach(IActor item in actors)
            {
                item.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime) {
            foreach(IActor item in actors)
            {
                item.Draw(game.spriteBatch);
            }
        }


    }
}
