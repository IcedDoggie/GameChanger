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
    class UserInterface : Scene, IFinalRenderDelegate
    {
        public UICanvas canvas;
        public Scene scene
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void handleFinalRender(Color letterboxColor, RenderTarget2D source, Rectangle finalRenderDestinationRect, SamplerState samplerState)
        {
            throw new NotImplementedException();
        }

        public void onAddedToScene()
        {
            throw new NotImplementedException();
        }

        public void onSceneBackBufferSizeChanged(int newWidth, int newHeight)
        {
            throw new NotImplementedException();
        }
    }
}
