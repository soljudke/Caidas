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
        Texture2D repeat;
        Texture2D letra;
        Texture2D bien;
<<<<<<< HEAD
        Texture2D otraCaja;
        Texture2D mal;
        Rectangle recCaja;
        Rectangle recCaja2;
=======
        Rectangle recCaja;
>>>>>>> origin/master
        Rectangle recRepeat;
        Rectangle recPlayer;
        int cosa = 0;
        int flag = 0;
        int pressedX, pressedY;
        bool noDraw = false;
        bool malTocado = false;
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
<<<<<<< HEAD
            repeat= Content.Load<Texture2D>("repeat");
            otraCaja = Content.Load<Texture2D>("caja2");
            mal = Content.Load<Texture2D>("cancel");
=======
              repeat= Content.Load<Texture2D>("repeat");

>>>>>>> origin/master
            letra = Content.Load<Texture2D>("a");
            bien = Content.Load<Texture2D>("Bien");
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
            if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed)/* && (recPlayer.Contains(currentMouseState.X, currentMouseState.Y) || (recPlayer.Contains(previousMouseState.X, previousMouseState.Y)))*/)
            {
                clicked = true;
                flag = 1;
                pressedX = currentMouseState.X;
                pressedY = currentMouseState.Y;
            }
            else if (previousMouseState.LeftButton == ButtonState.Released & currentMouseState.LeftButton == ButtonState.Pressed) 
            {
                clicked = false;
            }
            else if (previousMouseState.LeftButton == ButtonState.Released & currentMouseState.LeftButton == ButtonState.Released)
            {
                clicked = false;
            }
            if ((previousMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed) && (recRepeat.Contains(currentMouseState.X, currentMouseState.Y)))
            {
                clicked = true;
                flag = 0;
                pressedX = currentMouseState.X;
                pressedY = currentMouseState.Y;
                cosa = 0;
                cosa2 = 0;
                noDraw = false;
<<<<<<< HEAD
                malTocado = false;
=======
>>>>>>> origin/master
                clicked = false;
            }
            // TODO: Add your update logic here
            cosa2++;
            recCaja = new Rectangle(100, 350, caja.Width, caja.Height);
<<<<<<< HEAD
            recCaja2 = new Rectangle(200, 350, caja.Width, caja.Height);
=======
>>>>>>> origin/master
            recRepeat = new Rectangle(500, 10,repeat.Width,repeat.Height);
            if (clicked)
            {
                recPlayer = new Rectangle(currentMouseState.X, currentMouseState.Y, letra.Width, letra.Height);
            }
            else
            {
                if (flag==0)
                {
                    recPlayer = new Rectangle(100, cosa2, letra.Width, letra.Height);
                }
                else if (flag == 1)
                {
                    cosa2 = pressedY;
                    recPlayer = new Rectangle(pressedX, cosa2, letra.Width, letra.Height);
                }
               
            }
            
            if (recCaja.Intersects(recPlayer))
            {
                noDraw = true;
            }
<<<<<<< HEAD
            if (recCaja2.Intersects(recPlayer))
            {
                malTocado = true;
            }
=======
>>>>>>> origin/master
            if (cosa == 400)
            {
                cosa = 0;
                flag = 0;
                cosa2 = 0;
                GraphicsDevice.Clear(Color.CornflowerBlue);
                noDraw = false;
<<<<<<< HEAD
                malTocado = false;
=======
>>>>>>> origin/master
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
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
<<<<<<< HEAD
            if (!noDraw && !malTocado)
=======
            if (!noDraw)
>>>>>>> origin/master
            {
                if (clicked)
                {
                    spriteBatch.Draw(letra, new Vector2(currentMouseState.X, currentMouseState.Y), Color.White);
                }
                else
                {
                    if (flag == 0)
                    {
                        cosa++;
                        spriteBatch.Draw(letra, new Vector2(100, cosa), Color.White);
                    }
                    else if (flag == 1)
                    {
                        //cosa = pressedY;
                        cosa++;
                        spriteBatch.Draw(letra, new Vector2(pressedX, cosa), Color.White);
                    }

                }

                spriteBatch.Draw(caja, new Vector2(100, 350), Color.White);
<<<<<<< HEAD
                spriteBatch.Draw(otraCaja, new Vector2(200, 350), Color.White);
            }
            else
            {
                if (noDraw)
                {
                    GraphicsDevice.Clear(Color.Orange);
                    spriteBatch.Draw(bien, new Vector2(200, 200), Color.White);
                }
                if (malTocado)
                {
                    GraphicsDevice.Clear(Color.Orange);
                    spriteBatch.Draw(mal, new Vector2(200, 200), Color.White);
                }
            }
           
=======
            }
            else
            {
                GraphicsDevice.Clear(Color.Orange);
                spriteBatch.Draw(bien, new Vector2(200, 200), Color.White);
            }
>>>>>>> origin/master
            spriteBatch.Draw(repeat, new Vector2(500, 10), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
