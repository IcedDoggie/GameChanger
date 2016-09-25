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
using System.Timers;

namespace Game_Changer__NEW_
{
    class Controlpoint : Component, IUpdatable
    {

        public string controlPointID; // ID determines who owns the control point
        public string factionName;
        public int militaryPower;
        public int gold;
        public int luxuryPoint;
        
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
        public const float updateInterval = 250;
        public Timer statsTimer;
        public string luxuryExist;
        public int cphp;

        


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
            
            if(mousePoint == entityLocation && flagForComponent == false)
            {
                //System.Diagnostics.Debug.WriteLine("CP Found");
                var tempEntity = this.entity.getComponent<Controlpoint>();
                this.factionName = tempEntity.factionName;
                System.Diagnostics.Debug.WriteLine(this.factionName);
                statsText = new Text(Graphics.instance.bitmapFont, this.factionName, new Vector2(tiledX, tiledY), Color.LightGoldenrodYellow);
                hpText = new Text(Graphics.instance.bitmapFont, this.cphp.ToString(), new Vector2(tiledX, tiledY+30), Color.LightGoldenrodYellow);
                luxuryText = new Text(Graphics.instance.bitmapFont, this.luxuryExist, new Vector2(tiledX, tiledY + 60), Color.LightGoldenrodYellow);
                cpEntity.addComponent(statsText);
                cpEntity.addComponent(hpText);
                cpEntity.addComponent(luxuryText);
                flagForComponent = true;
                
            }
            else if(mousePoint != entityLocation && flagForComponent == true )
            {
                flagForComponent = false;
                cpEntity.removeComponent(statsText);
                cpEntity.removeComponent(hpText);
                cpEntity.removeComponent(luxuryText);
            }
           
        }

    }
}
