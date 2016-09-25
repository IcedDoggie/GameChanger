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
    public class SelectTile : RenderableComponent, IUpdatable
    {
        TiledMap tiledmap;
        Point location;
        

        public override float width { get { return 1000; } }
        public override float height { get { return 1000; } }

        public SelectTile(TiledMap ref_tiledmap)
        {
            location = new Point(0,0);
            tiledmap = ref_tiledmap;       
        }


        public float speed = 100f;
        void IUpdatable.update()
        {
            var moveDir = Vector2.Zero;
            if (Input.leftMouseButtonPressed)
            {
                
                location = tiledmap.worldToTilePosition(Input.mousePosition);                
                //System.Diagnostics.Debug.WriteLine(location);
                //System.Diagnostics.Debug.WriteLine(location);
            }
            
            

        }

        public override void render(Graphics graphics, Camera camera)
        {
            //throw new NotImplementedException();
        }


    }
}
