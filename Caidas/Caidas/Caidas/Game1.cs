using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Caidas
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D caja;
        Texture2D letra;
        Rectangle recCaja;
        Rectangle recPlayer;
        int cosa = 0;
        bool noDraw = false;
        int cosa2 = 0;
        ClickablePlayer player, friend;
        List<ClickablePlayer> clickableObjects;
        Mouse mouse;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
           // graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
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
          //  IsMouseVisible = true;

            player = new ClickablePlayer();
            friend = new ClickablePlayer();
           // player.Rotation = MathHelper.ToRadians(-90);
           // friend.Rotation = MathHelper.ToRadians(90);

            clickableObjects = new List<ClickablePlayer>(10);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
          mouse = new Mouse(Content.Load<Texture2D>("mouse-arrow"));
            caja = Content.Load<Texture2D>("caja");
            letra = Content.Load<Texture2D>("a");
            player.Texture = Content.Load<Texture2D>("a");
            //friend.Texture = Content.Load<Texture2D>("sprite-clicked");
            //player.ClickedTexture = Content.Load<Texture2D>("sprite-clicked");
            //friend.ClickedTexture = Content.Load<Texture2D>("sprite");
           player.Position = new Vector2(0 + player.Origin.Y,
                GraphicsDevice.Viewport.Height - player.Rectangle.Height - player.Origin.X);
            //friend.Position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            clickableObjects.Add(player);
            //clickableObjects.Add(friend);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
        public Vector2 NuevaPosi;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            cosa2++;
            recCaja = new Rectangle(100, 350, caja.Width, caja.Height);
            recPlayer = new Rectangle(100, cosa2, letra.Width, letra.Height);

            if (recCaja.Intersects(GameplayObject.recPlayer))
            {
                noDraw = true;
            }
            if (cosa==350)
            {
                cosa = 0;
            }
           mouse.Update();
           
            PerformMouseInteractions(gameTime);
            PerformNormalUpdate(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
           
            base.Update(gameTime);
            //cosa2++;
            //recFlor = new Rectangle(100, cosa2, flor.Width, flor.Height);
           
          
        }
   private void PerformNormalUpdate(GameTime gameTime)
        {
            foreach (ClickableGameplayObject cgo in clickableObjects)
            {
                if (cgo != mouse.ClickedObject)
                {
                    cgo.Update(gameTime);
                }
            }
        }
        private void PerformMouseInteractions(GameTime gameTime)
        {
            foreach (ClickableGameplayObject cgo in clickableObjects)
            {
                if (mouse.ClickedObject == null)
                {
                    cgo.Update(gameTime, mouse);
                    if (cgo.ActiveMouse != null)
                    {
                        return;
                    }
                }
                else
                {
                    mouse.ClickedObject.Update(gameTime, mouse);
                    return;
                }
            }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (noDraw)
            {
                 GraphicsDevice.Clear(Color.Orange);
            }
            // TODO: Add your drawing code here
           spriteBatch.Begin();
           cosa++;
          // var currentMouseState = Mouse.GetState();
           if (mouse.LeftClick)
           {
               NuevaPosi = mouse.miPosi;
               player.Draw(gameTime, spriteBatch);
           }
           else
           {
               player.DrawNo(gameTime, spriteBatch);
           }

            spriteBatch.Draw(caja, new Vector2(100, 350), Color.White);
            spriteBatch.End();
            mouse.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
