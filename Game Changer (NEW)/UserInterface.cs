using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game_Changer__NEW_
{
    class UserInterface : Component, IUpdatable
    {
        public UICanvas canvas;

        public void update()
        {
            throw new NotImplementedException();
        }

        void createUI()
        {
            var uiCanvas = entity.scene.createEntity("sprite-light-ui").addComponent( new UICanvas() );
            var table = uiCanvas.stage.addElement(new Table());
            //table.setFillParent(true).left().top().padLeft(10).padTop(30);

            table.row().setPadTop(20).setAlign(Align.left);

           
        }
    }
}
