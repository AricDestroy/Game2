using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming.Aric.Assets
{
    class AssetManager
    {
        public static SpriteFont MainFont { get; set; }
        public static Texture2D ShipTexture { get; set; }

        public static void Load(ContentManager content) {
            MainFont = content.Load<SpriteFont>("mainfont");
            ShipTexture = content.Load<Texture2D>("ship");
        }
    }
}
