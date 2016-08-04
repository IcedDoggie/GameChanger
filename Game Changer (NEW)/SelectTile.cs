using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Nez.AI.Pathfinding;

namespace Game_Changer__NEW_
{
    public class SelectTile : Component, IUpdatable
    {
        TiledMap tiledmap;
        Point location;



        public SelectTile(TiledMap ref_tiledmap)
        {
            location = new Point(0,0);
            tiledmap = ref_tiledmap;
            var layer = tiledmap.getLayer<TiledTileLayer>("maplayer");

        }



        void IUpdatable.update()
        {
            if (Input.leftMouseButtonPressed)
            {
                location = tiledmap.worldToTilePosition(Input.mousePosition);
                System.Diagnostics.Debug.WriteLine(location);
            }

        }

    }
}
