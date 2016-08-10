using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game_Changer__NEW_
{
    class Controlpoint : Obj
    {

        public int controlPointID; // ID determines who owns the control point
        public int militaryPower;
        public int gold;
        public int luxuryPoint;

        public Controlpoint(Vector2 pos) : base(pos)
        {

        }
    }
}
