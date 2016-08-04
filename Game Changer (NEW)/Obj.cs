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
    class Obj
    {
        protected Vector2 position;
        protected Texture2D spriteIndex;
        protected int state;     // A flag that checks the owner of the control point
        protected string spriteName;
        protected float speed = 0.0f;
        protected float scale = 1.0f;
        protected float rotation = 0.0f;

        public Obj(Vector2 pos)
        {
            position = pos;
        }

        public virtual void LoadContent(ContentManager content)
        {
            spriteIndex = content.Load<Texture2D>(this.spriteName);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);
            spriteBatch.Draw(spriteIndex, position, null, Color.White, rotation, center,
                scale, SpriteEffects.None, 0);
        }

        public virtual void Update()
        {
            pushTo(speed, rotation);
        }

        public void pushTo(float pix, float dir)
        {
            float newX = -(float)Math.Cos(dir);
            float newY = -(float)Math.Sin(dir);
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
        }
    }
}
