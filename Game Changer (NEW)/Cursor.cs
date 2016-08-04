using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Game_Changer__NEW_
{

    class Cursor : Obj
    {
        private MouseState mouse;
        public Cursor(Vector2 pos) : base(pos)
        {
            position = pos;
            spriteName = "cursor";
        }

        public override void Update()
        {
            mouse = Mouse.GetState();
            position = new Vector2(mouse.X, mouse.Y);

            base.Update();
        }
    }
}
