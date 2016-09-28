using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Caidas
{
    public class Movimiento
    {
        Vector2 position = Vector2.Zero;
        Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
            set
            {
                //When we set the texture, we also want to get
                //the data right away and calculate the matrix
                texture = value;
                TextureData = new Color[value.Width * value.Height];
                Texture.GetData(TextureData);

                //Calculate the matrix of the object
                CalculateMatrix();
            }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Origin
        {
            get
            {
                return new Vector2(texture.Width / 2.0f, texture.Height / 2.0f);
            }
        }
        public Color[] TextureData
        {
            get;
            private set;
        }
        private void CalculateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
               /* Matrix.CreateRotationZ(rotation) * */
                Matrix.CreateScale(1.0f) *
                Matrix.CreateTranslation(new Vector3(position, 0));
        }
        public Matrix Transform
        {
            get;
            private set;
        }
        Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
        }
        MouseState previousState, currentState;
        public Rectangle Rectangle2
        {
            get;
            protected set;
        }

        public void Update()
        {
            previousState = currentState;
            currentState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            Position = new Vector2(currentState.X, currentState.Y);
            Rectangle2 = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }
    }
}
