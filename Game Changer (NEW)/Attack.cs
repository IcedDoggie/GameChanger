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
        public int playerLuxuryCount = 0; //use to track player luxury
        public int enemyLuxuryCount = 0; //use to track enemy luxury

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

            //to track luxury for gold purpose
            foreach (var i in cpList)
            {
                if (i.luxuryExist == true && i.playerTerritory == true)
                {
                    playerLuxuryCount++;
                }
                else if (i.luxuryExist == true && i.playerTerritory == true)
                {
                    enemyLuxuryCount++;
                }
            }
            if (playerLuxuryCount > 0)
            {
                Controlpoint.playerLuxury = true;
            }
            else
            {
                Controlpoint.playerLuxury = true;
            }

            if (enemyLuxuryCount > 0)
            {
                Controlpoint.playerLuxury = true;
            }
            else
            {
                Controlpoint.playerLuxury = true;
            }
            //luxury function ends here

            //attack functions and gold functions start here

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
                                Controlpoint.playerGold -= 5;
                                playerName = "";
                            }
                            if (i.cphp <= 0)
                            {
                                Debug.log(Controlpoint.playerGold);
                                i.playerTerritory = true;
                                if(Controlpoint.playerLuxury==true)
                                {
                                    Controlpoint.playerGold += Convert.ToInt32(50 * 1.5);
                                }else
                                {
                                    Controlpoint.playerGold += 50;
                                }
                                
                                Controlpoint.enemyGold -= 20;
                                Debug.log(Controlpoint.playerGold);
                            }
                            
                        }
                    }
                }
            }
            //end here
           
        }

        
    }

   
}
