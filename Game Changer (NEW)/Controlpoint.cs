using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace Game_Changer__NEW_
{
    class Controlpoint : Component, IUpdatable
    {

        public string controlPointID; // ID determines who owns the control point
        public int militaryPower;
        public int gold;
        public int luxuryPoint;
        public Entity cpEntity;
        TiledMap tiledmap;
        Point entityLocation;
        Point mousePoint;

        public Controlpoint(Entity CP, TiledMap ref_tiledmap)
        {
            cpEntity = CP;
            controlPointID = CP.name;
           
            entityLocation = new Point(0, 0);
            mousePoint = new Point(0, 0);
            tiledmap = ref_tiledmap;

        }
        void IUpdatable.update()
        {
            entityLocation = tiledmap.worldToTilePosition(cpEntity.transform.position);
            mousePoint = tiledmap.worldToTilePosition(Input.mousePosition);
            if(mousePoint == entityLocation)
            {
                System.Diagnostics.Debug.WriteLine("aaa");
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine(entityLocation);
            }
        }
    }
}
