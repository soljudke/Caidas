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

namespace Caidas2
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
        bool clicked = false;
        int cosa2 = 0;
        MouseState currentMouseState;
        MouseState previousMouseState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            IsMouseVisible = true;
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
            caja = Content.Load<Texture2D>("caja");
            letra = Content.Load<Texture2D>("a");
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
        MouseState current, last;
        private float holdTimer;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            if (previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                clicked = true;
            }
            else if (previousMouseState.LeftButton == ButtonState.Released & currentMouseState.LeftButton == ButtonState.Pressed) 
            {
                clicked = false;
            }
            else if (previousMouseState.LeftButton == ButtonState.Released & currentMouseState.LeftButton == ButtonState.Released)
            {
                clicked = false;
            }

            // TODO: Add your update logic here
            cosa2++;
            recCaja = new Rectangle(100, 350, caja.Width, caja.Height);
            if (clicked)
            {
                recPlayer = new Rectangle(currentMouseState.X, currentMouseState.Y, letra.Width, letra.Height);
            }
            else
            {
                recPlayer = new Rectangle(100, cosa2, letra.Width, letra.Height);

            }
            
            if (recCaja.Intersects(recPlayer))
            {
                noDraw = true;
            }
            if (cosa == 350)
            {
                cosa = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
           //////////////////////////////////////////////////////////////////
            
            
            
            base.Update(gameTime);
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
            if (clicked)
            {
               
                spriteBatch.Draw(letra, new Vector2(currentMouseState.X, currentMouseState.Y), Color.White);
            }
            else
            {
                cosa++;
                spriteBatch.Draw(letra, new Vector2(100, cosa), Color.White);
            }
            
            
            spriteBatch.Draw(caja, new Vector2(100, 350), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
