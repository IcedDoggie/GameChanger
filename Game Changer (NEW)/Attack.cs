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
        int playerHp;
        //bool playerTerritory;
        string playerName="";

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
            Debug.log(abc.Capacity);
        }

        void IUpdatable.update()
        {
            //location = tiledmap.worldToTilePosition(cpEntity.transform.position);
            mousePoint = tiledmap.worldToTilePosition(Input.mousePosition);
            
            if (Input.leftMouseButtonPressed)
            {
                foreach (var i in cpList)
                {
                    if (mousePoint == tiledmap.worldToTilePosition(i.transform.position))
                    {
                        if (i.controlPointID != playerName && i.playerTerritory == true)
                        {
                            playerName = i.controlPointID;
                            playerHp = i.cphp;
                        } else if (i.controlPointID != playerName && i.playerTerritory == false && playerName != "")
                        {
                            if (i.cphp > 0)
                            {
                                i.cphp -= 5;
                                playerName = "";
                            }
                            if (i.cphp <= 0)
                            {
                                i.playerTerritory = true;
                            }
                            
                        }
                    }
                }
            }

        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }

   
}
