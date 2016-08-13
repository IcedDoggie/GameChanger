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
    class army : Component, IUpdatable
    {
        TiledMap tiledmap;
        Point location;
        int pointX, pointY;

        public float speed = 100f;

        public army(TiledMap ref_tiledmap)
        {
            location = new Point(100,100);
            tiledmap = ref_tiledmap;
            var layer = tiledmap.getLayer<TiledTileLayer>("maplayer");
            
        }

        public void update()
        {
            Vector2 moveDir = Vector2.Zero;
            /*if (Input.isKeyDown(Keys.Left))
                moveDir.X = -1f;
            else if (Input.isKeyDown(Keys.Right))
                moveDir.X = 1f;

            if (Input.isKeyDown(Keys.Up))
                moveDir.Y = -1f;
            else if (Input.isKeyDown(Keys.Down))
                moveDir.Y = 1f;
            entity.transform.position += moveDir * speed * Time.deltaTime;*/
            if (Input.leftMouseButtonPressed)
            {
                location = tiledmap.worldToTilePosition(Input.mousePosition);
                pointX = location.X;
                pointY = location.Y;

                System.Diagnostics.Debug.WriteLine(location);
                if (entity.transform.position.X < pointX)
                    moveDir.X = 1f;
                else if (entity.transform.position.X > pointX)
                    moveDir.X = -1f;
                if (entity.transform.position.Y < location.Y)
                    moveDir.Y = 1f;
                else if (entity.transform.position.Y > location.Y)
                    moveDir.Y = -1f;
                entity.transform.position += moveDir * speed * Time.deltaTime;
            }
                
        }
        
    }
}
