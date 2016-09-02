using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Nez.Textures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez.TextureAtlases;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace Game_Changer__NEW_
{

    class Army : Component, IUpdatable
    {
        TiledMap tiledmap;
        Point location;
        float pointX, pointY;

        public float speed = 100f;

        //Variables for spawning
        private int numberOfClicks = 0;
        private float originPointX, originPointY;
        private Entity armyEntity;
        private SpriteAnimation armyAnim;

        public Army(TiledMap ref_tiledmap, Entity armyEnt, SpriteAnimation anim)
        {   
            tiledmap = ref_tiledmap;
            var layer = tiledmap.getLayer<TiledTileLayer>("maplayer");
            armyEntity = armyEnt;
            armyAnim = anim;
        }

        public void update()
        {
            Vector2 moveDir = Vector2.Zero;
            var armyAnimation = new Sprite<Animation>(Animation.FlyRight, armyAnim);
            // This code is to direct which coordinate the bird goes
            if (Input.leftMouseButtonReleased && numberOfClicks == 0)
            {
                numberOfClicks += 1;
                location = tiledmap.worldToTilePosition(Input.mousePosition);
                //System.Diagnostics.Debug.WriteLine(location.X);
                //System.Diagnostics.Debug.WriteLine(location.Y);
                //origin
                originPointX = location.X * 900 / 29;
                originPointY = location.Y * 512 / 15;
                //System.Diagnostics.Debug.WriteLine(tiledmap.widthInPixels);
            }

            else if (Input.leftMouseButtonReleased && numberOfClicks == 1)
            {
                //numberOfClicks = 0;
                location = tiledmap.worldToTilePosition(Input.mousePosition);
                armyEntity.addComponent(armyAnimation);

                armyEntity.transform.position = new Vector2(originPointX, originPointY);
                //destination
                pointX = location.X * 900 / 29;
                pointY = location.Y * 512 / 15;
            }
            // This code is to maneuver the bird.
            if (originPointX < pointX)
            {
                moveDir.X = 1f;
                originPointX += moveDir.X;
                System.Diagnostics.Debug.WriteLine("pong!");
            }

            else if (originPointX > pointX)
            {
                moveDir.X = -1f;
                originPointX += moveDir.X;
                System.Diagnostics.Debug.WriteLine("ping!");
            }

            if (originPointY < pointY)
            {
                moveDir.Y = 1f;
                originPointY += moveDir.Y;
            }

            else if (originPointY > pointY)
            {
                moveDir.Y = -1f;
                originPointY += moveDir.Y;
            }

            //System.Diagnostics.Debug.WriteLine(originPointX);
            //System.Diagnostics.Debug.WriteLine(pointX);
            // This code is to remove the bird once it reaches destination
            if (  originPointX == pointX && originPointY == pointY && numberOfClicks == 1 )
            {
                numberOfClicks = 0;
                armyEntity.removeComponent(armyAnimation);
                //originPointX = 0;
                //originPointY = 0;
            }

            //System.Diagnostics.Debug.Write(originPointX);
            //System.Diagnostics.Debug.Write(" ");
            //System.Diagnostics.Debug.Write(pointX);
            //System.Diagnostics.Debug.Write(" ");

            //System.Diagnostics.Debug.Write(originPointY);
            //System.Diagnostics.Debug.Write(" ");
            //System.Diagnostics.Debug.Write(pointY);
            //System.Diagnostics.Debug.Write(" ");            

            armyEntity.transform.position += moveDir * speed * Time.deltaTime;
        }
    }                
}
        


