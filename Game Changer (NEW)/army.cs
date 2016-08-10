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

namespace Game_Changer__NEW_
{
    class Army : Entity
    {
        
        Sprite<Animation> _animation;
        Mover _mover;
        float _moveSpeed = 100f;

        //public override void onAddedToEntity()
        //{
        //   load up our character texture atlas. we have different characters in 1 - 6.png for variety
        //   var characterPng = Nez.Random.range(1, 7);
        //   var texture = entity.scene.content.Load<Texture2D>("army_png/Frame-1");
        //   var subtextures = Subtexture.subtexturesFromAtlas(texture, 16, 16);




        //}

        public Army()
        {

        }


        public enum Animation
        {
            Walk
        }

        private void setupAnimation(TextureAtlas atlas)
        {
 
            _animation.addAnimation(Animation.Walk, atlas.getSpriteAnimation("arm_png"));
           
        }

        public void playAnimation(Animation anim)
        {
            
                _animation.play(anim);
         
        }

        public override void onAddedToScene()
        {
            playAnimation(Animation.Walk);

            
            base.onAddedToScene();
        }
    }
}
