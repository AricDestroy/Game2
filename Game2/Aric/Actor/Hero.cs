using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Gaming.Aric.Actor
{
    class Hero : Sprite
    {
        public float Energy;
        public Hero(Texture2D texture) : base(texture)
        {
            Energy = 100;
        }


        public override void TouchedBy(IActor actor)
        { 
            base.TouchedBy(actor);
            if(actor is Meteor)
            {
                Energy -= 0.01f;
            }
        }
    }
}
