using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.AI.Pathfinding;
using Microsoft.Xna.Framework;

namespace Game_Changer__NEW_
{
    public class Pathfinder : RenderableComponent, IUpdatable
    {
        public override float width { get { return 1000; } }
        public override float height { get { return 1000; } }

        WeightedGridGraph _astarGraph;
        List<Point> _astarSearchPath;

        TiledMap _tilemap;
        Point start, end;

        public Pathfinder(TiledMap tilemap)
        {
            _tilemap = tilemap;
            
            var layer = tilemap.getLayer<TiledTileLayer>("maplayer");
            
            start = new Point(1, 1);
            end = new Point(10, 10);

            _astarGraph = new WeightedGridGraph(layer);
            _astarSearchPath = _astarGraph.search( start, end );
            
        }

        void IUpdatable.update()
        {
            if (Input.leftMouseButtonPressed)
            {
                start = _tilemap.worldToTilePosition(Input.mousePosition);
                System.Diagnostics.Debug.WriteLine(start);
            }
            if (Input.rightMouseButtonPressed)
            {
                end = _tilemap.worldToTilePosition(Input.mousePosition);
                System.Diagnostics.Debug.WriteLine(end);
            }
            if (Input.leftMouseButtonPressed || Input.rightMouseButtonPressed)
            {

                var second = Debug.timeAction(() =>
                {
                    _astarSearchPath = _astarGraph.search(start, end);
                });
            }


        }

        public override void render(Graphics graphics, Camera camera)
        {
            if (_astarSearchPath != null)
            {
                foreach (var node in _astarSearchPath)
                {
                    var x = node.X * _tilemap.tileWidth + _tilemap.tileWidth * 0.5f;
                    var y = node.Y * _tilemap.tileHeight + _tilemap.tileHeight * 0.5f;

                    graphics.batcher.drawPixel(x - 1, y - 1, Color.Blue, 4);
                    System.Diagnostics.Debug.WriteLine(node);
                }
            }

            while (start.X != end.X)
            {
                start.X += 1;
            }
            while (start.Y != end.Y)
            {
                start.Y += 1;
            }

        }
    }
}
