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
        public int cphp;
        public Entity cpEntity;
        TiledMap tiledmap;
        Point entityLocation;
        Point mousePoint;
        public int tiledX;
        public int tiledY;
        public bool flagForComponent = false;
        

        //for text update
        public Text statsText;
        public const float updateInterval = 250;
        public Timer statsTimer;


        public Controlpoint(Entity CP, TiledMap ref_tiledmap)
        {
            cpEntity = CP;
            controlPointID = CP.name;
            cphp = 20;

            entityLocation = new Point(0, 0);
            mousePoint = new Point(0, 0);
            tiledmap = ref_tiledmap;

            tiledX = tiledmap.tileWidth;
            tiledY = tiledmap.tileHeight;

            tiledX = tiledX - tiledmap.tileWidth;
            tiledY = tiledY - tiledmap.tileHeight;
        }
        void IUpdatable.update()
        {
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
                cpEntity.addComponent(statsText);     
                flagForComponent = true;
            }
            else if(mousePoint != entityLocation && flagForComponent == true )
            {
                flagForComponent = false;
                cpEntity.removeComponent(statsText);   
                //cpEntity.removeComponent(statsText);
                //this.factionName = "";
                //System.Diagnostics.Debug.WriteLine("CP Not Found");
            }
            
        }

        //void statsUpdate()
        //{
        //    statsTimer = new Timer(updateInterval);
        //    statsTimer.Elapsed += statsTimer_el
        //}
    }
}
