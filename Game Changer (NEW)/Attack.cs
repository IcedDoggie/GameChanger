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
        private bool botAtkFlag = true;
        private int botEnd;
        DateTime timerStart;
        
        //Bot Programming
        private int playerCPCount = 2;
        private int botCPCount = 1;

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
            #region Timer
            // timer for atk
            var timerStart = DateTime.Now;
            start = timerStart.Second;
            end = start + 5;
            // to solve the bug of end: it will exceed max of 60 seconds if +10
            if(end > 60)
            {
                end -= 60;
            }
            #endregion

            #region Player Attack Mode
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
                        } 
                        else if (i.controlPointID != playerName && i.playerTerritory == false && playerName != "")
                        {
                            if (i.cphp > 0)
                            {
                                // activating timer/buffer for atk to happen
                                
                                //if(playerAtkFlag == false)
                                //{
                                //    now = start;
                                //    tempEnd = end;
                                //    playerAtkFlag = true;
                                //}
                                //System.Diagnostics.Debug.WriteLine(start);
                                //System.Diagnostics.Debug.WriteLine(tempEnd);
                                //if(tempEnd == start)
                                //{
                                    i.cphp -= 5;
                                    playerName = "";
                                    //playerAtkFlag = false;
                                //}

                            }
                            if (i.cphp <= 0 && i.playerTerritory == false)
                            {
                                System.Diagnostics.Debug.WriteLine("Tada");
                                i.playerTerritory = true;
                                playerCPCount++;
                                botCPCount--;
                            }
                            if (botCPCount == 0)
                            {
                                break;
                            }
                            
                        }
                    }
                }
            }
            #endregion

            #region Bot Mode
            foreach (var i in cpList)
            {
                // check if still have territory or not
                if (botCPCount != 0)
                {
                    // not attacking
                    if (botAtkFlag == false)
                    {
                        if (botEnd == start)
                            botAtkFlag = true; // change it to true so that bot attacks
                    }
                    // attacking mode
                    else
                    {
                        botEnd = start + 5; // buffer of 5 seconds before next attack
                        if (botEnd > 60)
                        {
                            botEnd -= 60;
                        }
                        if (i.playerTerritory == true && i.luxuryExist == "Luxury!")
                        {
                            i.cphp = i.cphp - 5;
                            botAtkFlag = false;
                        }

                        else if (i.playerTerritory == true && playerCPCount == 1)
                        {
                            i.cphp = i.cphp - 5;
                            botAtkFlag = false;
                        }
                    }

                    // change CP's owner
                    if (i.cphp <= 0 && i.playerTerritory == true)
                    {
                        i.playerTerritory = false;
                        playerCPCount--;
                        botCPCount++;
                        System.Diagnostics.Debug.WriteLine(playerCPCount);
                    }

                    if (playerCPCount == 0)
                    {
                        break;
                    }
                }
            }
            #endregion
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }

   
}
