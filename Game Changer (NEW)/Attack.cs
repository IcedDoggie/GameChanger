using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Changer__NEW_
{
    class Attack : Component, IUpdatable
    {
        int hp;
        bool territory;
        string name="";
        public Entity cpEntity;
        List<Controlpoint> cpList;

        TiledMap tiledmap;
        Point location;
        Point mousePoint;

        public Attack(TiledMap ref_tiledmap, List<Controlpoint> abc)
        {
            location = new Point(0, 0);
            tiledmap = ref_tiledmap;
            mousePoint = new Point(0, 0);
            cpList = abc;
            
        }

        void IUpdatable.update()
        {
            location = tiledmap.worldToTilePosition(cpEntity.transform.position);
            mousePoint = tiledmap.worldToTilePosition(Input.mousePosition);
            Debug.log("abc");
            if (Input.leftMouseButtonPressed)
            {
                foreach (var i in cpList)
                {
                    if (mousePoint == tiledmap.worldToTilePosition(i.transform.position))
                    {
                        
                        i.cphp -= 5;
                    }
                }
            }

        }

        

        
    }

   
}
