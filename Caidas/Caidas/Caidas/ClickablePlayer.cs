using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Caidas
{
    public class ClickablePlayer : ClickableGameplayObject
    {
        Random random;
        public Texture2D ClickedTexture
        {
            get;
            set;
        }

        Texture2D saved;

        public ClickablePlayer()
            : base()
        {
            Alpha = 0.5f;
            random = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);
        }

        public override void OnHover()
        {
            base.OnHover();

            Alpha = 1.0f;

            Rotation += 0.01f;
        }

        public override void OnLeave()
        {
            base.OnLeave();

            Alpha = 0.5f;
        }

        public override void OnLeftClick()
        {
            base.OnLeftClick();

            Position = new Microsoft.Xna.Framework.Vector2(ActiveMouse.Position.X, ActiveMouse.Position.Y);
        }

        public override void OnHeldLeftClick()
        {
            base.OnHeldLeftClick();

            Position = new Microsoft.Xna.Framework.Vector2(ActiveMouse.Position.X, ActiveMouse.Position.Y);
        }

        public override void OnRightClick()
        {
            base.OnRightClick();

            saved = Texture;
            Texture = ClickedTexture;
        }

        public override void OnRightRelease()
        {
            base.OnRightRelease();

            Texture = saved;
        }

        protected override void UpdateGameplayObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (LeftState == ObjectClickedState.Normal && RightState == ObjectClickedState.Normal)
            {
                /*float rx = (float)((random.NextDouble() * 10) - 5);
                float ry = (float)((random.NextDouble() * 10) - 5);
                Position = new Microsoft.Xna.Framework.Vector2(Position.X + rx, Position.Y + ry);*/
            }
        }
    }
}
