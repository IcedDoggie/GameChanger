using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Tiled;


namespace Game_Changer__NEW_
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public enum Animation
    {
        FlyRight,
        FlyLeft
    }
    public class Game1 : Core
    {
        
        SpriteBatch spriteBatch;
        private Scene myScene;
       

        public Game1() : base()
        {
            Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            myScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);
            myScene.setDesignResolution(960, 512, Scene.SceneResolutionPolicy.ExactFit);
            
            //Loading tilemap
            var tiledEntity = myScene.createEntity("tiled-map");
            var tiledmap = content.Load<TiledMap>("tilemap");
            var tiledMapComponent = tiledEntity.addComponent(new TiledMapComponent(tiledmap));

            //Loading Tile Functionality, like creating coordinates    
            var tileSelect = new SelectTile(tiledmap);
            var selectmap = tiledEntity.addComponent(tileSelect);
            tiledMapComponent.setLayersToRender("maplayer");
            tiledMapComponent.renderLayer = 1;

            var russiaEntity = myScene.createEntity("russiaFact", new Vector2(590,180)); 
            var russiaInMap = content.Load<Texture2D>("russia");
            var russiaComponent = russiaEntity.addComponent(new Sprite(russiaInMap));

            var usaEntity = myScene.createEntity("usaFact", new Vector2(175, 115));
            var usaInMap = content.Load<Texture2D>("usa");
            var usaComponent = usaEntity.addComponent(new Sprite(usaInMap));

            var canadaEntity = myScene.createEntity("canadaFact", new Vector2(232, 171)); //(7,5)
            var canadaInMap = content.Load<Texture2D>("usa");
            var canadaComponent = canadaEntity.addComponent(new Sprite(canadaInMap));

            var susaEntity = myScene.createEntity("susaFact", new Vector2(232, 239));//(7,7)
            var susaInMap = content.Load<Texture2D>("usa");
            var susaComponent = susaEntity.addComponent(new Sprite(susaInMap));

            var greenlandEntity = myScene.createEntity("greenlandFact", new Vector2(397, 102)); //(12,3)
            var greenlandInMap = content.Load<Texture2D>("usa");
            var greenlandComponent = greenlandEntity.addComponent(new Sprite(greenlandInMap));

            var brazilEntity = myScene.createEntity("brazilFact", new Vector2(331, 375)); //(10,11)
            var brazilInMap = content.Load<Texture2D>("usa");
            var brazilComponent = brazilEntity.addComponent(new Sprite(brazilInMap));

            var australiaEntity = myScene.createEntity("australiaFact", new Vector2(794, 410)); //(24,12)
            var australiaInMap = content.Load<Texture2D>("usa");
            var australiaComponent = australiaEntity.addComponent(new Sprite(australiaInMap));

            var chinaEntity = myScene.createEntity("chinaFact", new Vector2(695, 239)); //(21,7)
            var chinaInMap = content.Load<Texture2D>("usa");
            var chinaComponent = chinaEntity.addComponent(new Sprite(chinaInMap));

            //army testing
            // var armyEntity = myScene.createEntity("armyFact", new Vector2(700, 239)); 
            //var armyInMap = content.Load<Texture2D>("army-png/smallarmy");
            //var armyComponent = armyEntity.addComponent(new Sprite(armyInMap));
            var armyAtlas = myScene.contentManager.Load<TextureAtlas>("armyAtlas");
            var anim = armyAtlas.getSpriteAnimation("flyright");

            var armyEntity = myScene.createEntity("armyInMap");
            armyEntity.addComponent(new Sprite<Animation>(Animation.FlyRight, anim));
            armyEntity.addComponent(new army(tiledmap));
            armyEntity.transform.position = new Vector2(200, 200);

            var spriteArmy = armyEntity.getComponent<Sprite<Animation>>();
            spriteArmy.play(Animation.FlyRight);
            Core.scene = myScene;
        }        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Update(GameTime gameTime)
        //{
        //    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        //        Exit();

        //    // TODO: Add your update logic here

        //    base.Update(gameTime);
        //}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
