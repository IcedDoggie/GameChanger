using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Nez.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Game_Changer__NEW_.Spawning
{
    class Bird : Component
    {
        TiledMap tiledmap;
        Point location;
        float pointX, pointY;

        public float speed = 100f;
        
    }
}
