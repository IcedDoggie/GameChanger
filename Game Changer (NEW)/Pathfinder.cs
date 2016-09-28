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
        UnweightedGridGraph _gridGraph;

        TiledMap _tilemap;
        Point _start, _end;

        public Pathfinder(TiledMap tilemap)
        {
            _tilemap = tilemap;         
            var layer = tilemap.getLayer<TiledTileLayer>("path");
            
            _start = new Point(1, 1);
            _end = new Point(10, 10);

            _gridGraph = new UnweightedGridGraph(layer);
            _astarSearchPath = _gridGraph.search( _start, _end );

            //Debug.drawTextFromBottom = true;

        }

        void IUpdatable.update()
        {
            if (Input.leftMouseButtonPressed)
            {
                _start = _tilemap.worldToTilePosition(Input.mousePosition);
                //System.Diagnostics.Debug.WriteLine(start);
            }
            if (Input.rightMouseButtonPressed)
            {
                _end = _tilemap.worldToTilePosition(Input.mousePosition);
                //System.Diagnostics.Debug.WriteLine(_end);
            }
            if (Input.leftMouseButtonPressed || Input.rightMouseButtonPressed)
            {

                var second = Debug.timeAction(() =>
                {
                    _astarSearchPath = _gridGraph.search(_start, _end);
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
                        
                    //System.Diagnostics.Debug.WriteLine(x);
                    //System.Diagnostics.Debug.WriteLine(y);

                    //graphics.batcher.drawPixel(x - 1, y - 1, Color.Yellow, 4);
                    //System.Diagnostics.Debug.WriteLine(node);
                }
            }
        }
    }
}
