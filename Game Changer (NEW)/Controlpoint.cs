﻿using System;
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
using System.Timers;

namespace Game_Changer__NEW_
{
    class Controlpoint : Component, IUpdatable
    {

        public static int playerGold=50; //Total gold for player
        public static int enemyGold=50; //total gold for enemy
        public static bool playerLuxury = false; //check whether player have any luxury point
        public static bool enemyLuxury = false; //check whether enemy have any point contain luxury
        public string controlPointID; // ID determines who owns the control point
        public string factionName;
        public int cost; //for the cost purpose in attack.cs
        
        public Entity cpEntity;
        TiledMap tiledmap;
        Point entityLocation;
        Point mousePoint;
        public int tiledX;
        public int tiledY;
        public int tiledTempX;
        public int tiledTempY;
        public bool flagForComponent = false;
        

        //for text update
        public Text statsText;
        public Text hpText;
        public Text luxuryText;
        public Text territoyText;
        public Text goldText;
        public const float updateInterval = 250;
        public Timer statsTimer;
        public bool luxuryExist; //condition for gold purpose
        public string luxuryStr; //string for text purpose
        public int cphp;
        public string territory;

        
        //for timer
        private int start;
        private int end;
        private bool replenishFlag = true;



        
        public bool playerTerritory = false;
        public bool territorySelected = false;


        public Controlpoint(Entity CP, TiledMap ref_tiledmap)
        {
            cpEntity = CP;
            controlPointID = CP.name;
            cphp = 20;

            
            entityLocation = new Point(0, 0);
            mousePoint = new Point(0, 0);
            tiledmap = ref_tiledmap;
            

        }

        void IUpdatable.update()
        {
            #region Check Luxury
            if (luxuryExist == true)
            {
                luxuryStr = "Have luxury";
            }
            else if (luxuryExist == false)
            {
                luxuryStr = "No luxury";
            }
            #endregion
            
            #region CP's hp replenishment

            var timerStart = DateTime.Now;
            start = timerStart.Second;
            if(replenishFlag == true)
            {
                end = start + 5;
                if(end > 60)
                {
                    end -= 60;
                }
                cphp++;
                replenishFlag = false;
                //System.Diagnostics.Debug.WriteLine(end);
            }
            else
            {
                if(start == end)
                {
                    replenishFlag = true;
                }
            }


            #endregion
            #region Text Visualization
            // this code is for shifting the text to top-left corner
            tiledX = tiledmap.widthInPixels;
            tiledY = tiledmap.heightInPixels;
            Vector2 a = cpEntity.transform.position;
            int aTemp = tiledmap.worldToTilePositionX(a.X);
            int bTemp = tiledmap.worldToTilePositionY(a.Y);
            tiledTempX = aTemp * 35;
            tiledTempY = bTemp * 30;
            tiledX = (tiledX - tiledmap.widthInPixels) - tiledTempX + 35;
            tiledY = (tiledY - tiledmap.heightInPixels) - tiledTempY;
            //end

            //code below is for draw text :)
            entityLocation = tiledmap.worldToTilePosition(cpEntity.transform.position);
            mousePoint = tiledmap.worldToTilePosition(Input.mousePosition);
            //System.Diagnostics.Debug.WriteLine(entityLocation);

            if(playerTerritory == true)
            {
                territory = "Player";
            }
            else if(playerTerritory == false)
            {
                territory = "Enemy";
            }
            if (mousePoint == entityLocation && flagForComponent == false)
            {
                //System.Diagnostics.Debug.WriteLine("CP Found");
                var tempEntity = this.entity.getComponent<Controlpoint>();
                this.factionName = tempEntity.factionName;
                //System.Diagnostics.Debug.WriteLine(this.factionName);
                statsText = new Text(Graphics.instance.bitmapFont, this.factionName, new Vector2(tiledX, tiledY), Color.LightGoldenrodYellow);
                hpText = new Text(Graphics.instance.bitmapFont, this.cphp.ToString(), new Vector2(tiledX, tiledY + 30), Color.LightGoldenrodYellow);
                luxuryText = new Text(Graphics.instance.bitmapFont, this.luxuryStr, new Vector2(tiledX, tiledY + 60), Color.LightGoldenrodYellow);
                territoyText = new Text(Graphics.instance.bitmapFont, this.territory, new Vector2(tiledX, tiledY + 90), Color.LightGoldenrodYellow);
                
                cpEntity.addComponent(statsText);
                cpEntity.addComponent(hpText);
                cpEntity.addComponent(luxuryText);
                cpEntity.addComponent(territoyText);
                
                flagForComponent = true;
                //text for gold to shown properly for player and enemy
                if(playerTerritory==true)
                {
                    goldText = new Text(Graphics.instance.bitmapFont, playerGold.ToString(), new Vector2(tiledX, tiledY + 120), Color.LightGoldenrodYellow);
                }
                if(playerTerritory ==false)
                {
                    goldText = new Text(Graphics.instance.bitmapFont, enemyGold.ToString(), new Vector2(tiledX, tiledY + 120), Color.LightGoldenrodYellow);
                }
                cpEntity.addComponent(goldText);

            }
            else if (mousePoint != entityLocation && flagForComponent == true)
            {
                flagForComponent = false;
                cpEntity.removeComponent(statsText);
                cpEntity.removeComponent(hpText);
                cpEntity.removeComponent(luxuryText);
                cpEntity.removeComponent(territoyText);
                cpEntity.removeComponent(goldText);
            }

            #endregion

            #region cost function
            if(cphp<= 10 && luxuryExist==true)
            {
                cost = 0;
            }
            else if(cphp <=10 && luxuryExist == false)
            {
                cost = 1;
            }
            else if(luxuryExist==true && cphp > 10)
            {
                cost = 1;
            }
            else
            {
                cost = 2;
            }
            #endregion
        }

    }
}
