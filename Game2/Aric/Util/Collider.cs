using Gaming.Aric.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric.Util
{
    class Collider
    {

        public static bool CollideByBox(IActor actor1, IActor actor2)
        {
            return actor1.BoundingBox.Intersects(actor2.BoundingBox);
        }
    }
}
