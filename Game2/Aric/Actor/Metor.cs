using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaming.Aric.Util;
using Microsoft.Xna.Framework.Graphics;

namespace Gaming.Aric.Actor
{
    class Meteor : Sprite
    {
        public Meteor(Texture2D texture) : base(texture)
        {
            do
            {
                vX = (float)Randomizer.GetInt(-3, 3) / 5;
            } while (vX == 0);
            do
            {
                vY = (float)Randomizer.GetInt(-3, 3) / 5;
            } while (vY == 0);

        }

        public override void TouchedBy(IActor actor)
        {
            base.TouchedBy(actor);
            vX = -vX;
        }
    }
}
