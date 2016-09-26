using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;


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

        //Timer 
        private int start;
        private int end;
        private int now;
        private int tempEnd;
        private bool playerAtkFlag = false;
        DateTime timerStart;

        public Attack(TiledMap ref_tiledmap, List<Controlpoint> abc)
        {
            location = new Point(0, 0);
            tiledmap = ref_tiledmap;
            mousePoint = new Point(0, 0);
            cpList = abc;
            //Debug.log(abc.Capacity);
        }
        


        void IUpdatable.update()
        {
            //location = tiledmap.worldToTilePosition(cpEntity.transform.position);
            mousePoint = tiledmap.worldToTilePosition(Input.mousePosition);
            // timer for atk
            var timerStart = DateTime.Now;
            start = timerStart.Second;
            end = start + 10;
            // to solve the bug of end: it will exceed max of 60 seconds if +10
            if(end > 60)
            {
                end -= 60;
            }

            if (Input.leftMouseButtonPressed || playerAtkFlag == true)
            {
                foreach (var i in cpList)
                {
                    if (mousePoint == tiledmap.worldToTilePosition(i.transform.position))
                    {
                        if (i.controlPointID != playerName && i.playerTerritory == true)
                        {
                            playerName = i.controlPointID;
                            playerHp = i.cphp;
                        } 
                        else if (i.controlPointID != playerName && i.playerTerritory == false && playerName != "")
                        {
                            if (i.cphp > 0)
                            {
                                // activating timer/buffer for atk to happen
                                
                                if(playerAtkFlag == false)
                                {
                                    now = start;
                                    tempEnd = end;
                                    playerAtkFlag = true;
                                }
                                System.Diagnostics.Debug.WriteLine(start);
                                System.Diagnostics.Debug.WriteLine(tempEnd);
                                if(tempEnd==start)
                                {
                                    i.cphp -= 5;
                                    playerName = "";
                                    playerAtkFlag = false;
                                }

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
