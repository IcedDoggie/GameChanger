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
        }
        void IUpdatable.update()
        {
            entityLocation = tiledmap.worldToTilePosition(cpEntity.transform.position);
            mousePoint = tiledmap.worldToTilePosition(Input.mousePosition);
            //System.Diagnostics.Debug.WriteLine(entityLocation);
            statsText = new Text(Graphics.instance.bitmapFont, "abc", new Vector2(-160, -100), Color.LightGoldenrodYellow);
            this.entity.addComponent(statsText);
            
            if(mousePoint == entityLocation)
            {
                //System.Diagnostics.Debug.WriteLine("CP Found");
            }
            else
            {
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
