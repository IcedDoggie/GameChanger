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

        public float speed = 50f;

        //Variables for spawning
        private int numberOfClicks = 0;
        private float originPointX, originPointY;
        private Entity armyEntity;
        private SpriteAnimation armyAnim;
        private bool entityDestroyFlag;
        private Game1 tempScene;
        private Entity tempArmyEntity;
        public bool tempFlag = false;


        public Army(TiledMap ref_tiledmap, Entity armyEnt, SpriteAnimation anim)
        {   
            tiledmap = ref_tiledmap;
            var layer = tiledmap.getLayer<TiledTileLayer>("maplayer");
            armyEntity = armyEnt;
            tempArmyEntity = armyEntity; 
            armyAnim = anim;
            
        }

 

        public void update()
        {
            Vector2 moveDir = Vector2.Zero;
            var armyAnimation = new Sprite<Animation>(Animation.FlyRight, armyAnim);
            #region MouseInput
            // This code is to direct which coordinate the bird goes
            if (Input.leftMouseButtonReleased && numberOfClicks == 0)
            {          
                numberOfClicks = 1;
                location = tiledmap.worldToTilePosition(Input.mousePosition);
                //System.Diagnostics.Debug.WriteLine("tempLoc is here");
                var tempLoc = tiledmap.tileToWorldPosition(location);
                //System.Diagnostics.Debug.WriteLine(tempLoc);
                //System.Diagnostics.Debug.WriteLine(location.X);
                //System.Diagnostics.Debug.WriteLine(location.Y);
                //System.Diagnostics.Debug.WriteLine("1");
                //origin
                originPointX = location.X * 900 / 29;
                originPointY = location.Y * 512 / 15;
                //System.Diagnostics.Debug.WriteLine(tiledmap.widthInPixels);

            }
                
            else if ( Input.leftMouseButtonReleased && numberOfClicks == 1 )
            {
                
                location = tiledmap.worldToTilePosition(Input.mousePosition);

                //System.Diagnostics.Debug.WriteLine("tempLoc2 is here");
                var tempLoc = tiledmap.tileToWorldPosition(location);
                //System.Diagnostics.Debug.WriteLine(tempLoc);

                //armyEntity.addComponent(armyAnimation);
                //System.Diagnostics.Debug.WriteLine("2");
                var tempVec = new Vector2(originPointX, originPointY);
                //destination
                pointX = location.X * 900 / 29;
                pointY = location.Y * 512 / 15;
                
                //armyEntity = createProjectiles(tiledmap, armyAnim);
                //var animationDummy = armyEntity.addComponent(new Sprite<Animation>(Animation.FlyRight, armyAnim));
                //var armyComponent = armyEntity.addComponent(new Army(tiledmap, armyEntity, armyAnim));
                //System.Diagnostics.Debug.WriteLine("item created");
                var armyComponent = createProjectiles(tempVec, tiledmap, armyAnim);
                armyEntity.addComponent<Component>(armyComponent);

            }
            #endregion
            #region Bird Maneuver
            // This code is to maneuver the bird.
            if (originPointX < pointX)
            {
                moveDir.X = 1f;
                originPointX += moveDir.X;
                //System.Diagnostics.Debug.WriteLine("3");
            }

            else if (originPointX > pointX)
            {
                moveDir.X = -1f;
                originPointX += moveDir.X;
                //System.Diagnostics.Debug.WriteLine("4");
            }

            if (originPointY < pointY)
            {
                moveDir.Y = 1f;
                originPointY += moveDir.Y;
                //System.Diagnostics.Debug.WriteLine("5");
            }

            else if (originPointY > pointY)
            {
                moveDir.Y = -1f;
                originPointY += moveDir.Y;
                //System.Diagnostics.Debug.WriteLine("6");
            }
            #endregion
            // This code is to remove the bird once it reaches destination
            if (  originPointX == pointX && originPointY == pointY && numberOfClicks == 1 )
            {
                numberOfClicks = 0;
                entityDestroyFlag = true;
                //System.Diagnostics.Debug.WriteLine("item removed");
                //originPointX = 0;
                //originPointY = 0;
                //pointX = 0;
                //pointY = 0;
                //armyEntity.removeComponent<Component>();
                armyEntity.removeComponent<Component>();
            }
  

            if (entityDestroyFlag == true)
            {
                //var animationDummy = armyEntity.addComponent(new Sprite<Animation>(Animation.FlyRight, armyAnim));
                //var armyComponent = armyEntity.addComponent(new Army(tiledmap, armyEntity, armyAnim));
                //armyComponent.transform.position = new Vector2(-100, -100);
                entityDestroyFlag = false;
                var tempVec = new Vector2(0, 0);
                createProjectiles(tempVec, tiledmap, armyAnim);
            }
            armyEntity.transform.position += moveDir * speed * Time.deltaTime;
            
        }

        public Component createProjectiles(Vector2 position, TiledMap tempTiledMap, SpriteAnimation tempAnim)
        {
            var armyComponent = armyEntity.addComponent(new Army(tempTiledMap, armyEntity, tempAnim));
            armyComponent.transform.position = position;
            return armyComponent;
        }

    }                
}
        


