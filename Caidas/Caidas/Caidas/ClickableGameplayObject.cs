using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Caidas
{
    public enum ObjectClickedState
    {
        Normal,
        Clicked,
        Released
    }


    public abstract class ClickableGameplayObject : GameplayObject
    {
        public ObjectClickedState LeftState
        {
            get;
            protected set;
        }

        public ObjectClickedState RightState
        {
            get;
            protected set;
        }

        public Mouse ActiveMouse
        {
            get;
            protected set;
        }

        public ClickableGameplayObject()
            : base()
        {
            LeftState = RightState = ObjectClickedState.Normal;
        }
        
        public virtual void OnLeftClick() { }
        public virtual void OnHeldLeftClick() { }
        public virtual void OnLeftRelease() { }
        public virtual void OnLeftNormal() { }
        public virtual void OnRightClick() { }
        public virtual void OnHeldRightClick() { }
        public virtual void OnRightRelease() { }
        public virtual void OnRightNormal() { }
        public virtual void OnHover() { }
        public virtual void OnLeave() { }

        public void Update(GameTime gameTime, Mouse activeMouse)
        {
            base.Update(gameTime);

            bool intersect = activeMouse.Rectangle.Intersects(Rectangle);

            if (intersect || (ActiveMouse != null &&
                (LeftState != ObjectClickedState.Normal || RightState != ObjectClickedState.Normal)))
            {
                ActiveMouse = activeMouse;
                ActiveMouse.ClickedObject = this;
                if (intersect) OnHover();

                if (ActiveMouse.LeftClick && (LeftState == ObjectClickedState.Normal
                    || LeftState == ObjectClickedState.Released))
                {
                    LeftState = ObjectClickedState.Clicked;
                    OnLeftClick();
                }
                else if (ActiveMouse.LeftClick && LeftState == ObjectClickedState.Clicked)
                {
                    OnHeldLeftClick();
                }
                else if (ActiveMouse.LeftRelease && LeftState == ObjectClickedState.Clicked)
                {
                    LeftState = ObjectClickedState.Released;
                    OnLeftRelease();
                }
                else if (!ActiveMouse.LeftClick && LeftState == ObjectClickedState.Released)
                {
                    LeftState = ObjectClickedState.Normal;
                    OnLeftNormal();
                }

                if (ActiveMouse.RightClick && (RightState == ObjectClickedState.Normal
                    || RightState == ObjectClickedState.Released))
                {
                    RightState = ObjectClickedState.Clicked;
                    OnRightClick();
                }
                else if (ActiveMouse.RightClick && LeftState == ObjectClickedState.Clicked)
                {
                    OnHeldRightClick();
                }
                else if (ActiveMouse.RightRelease && RightState == ObjectClickedState.Clicked)
                {
                    RightState = ObjectClickedState.Released;
                    OnRightRelease();
                }
                else if (!ActiveMouse.RightClick && RightState == ObjectClickedState.Released)
                {
                    RightState = ObjectClickedState.Normal;
                    OnRightNormal();
                }
            }

            else
            {
                if (ActiveMouse != null)
                {
                    ActiveMouse.ClickedObject = null;
                    ActiveMouse = null;
                    OnLeave();
                }
            }

            UpdateGameplayObject(gameTime);
        }

        protected abstract void UpdateGameplayObject(GameTime gameTime);
    }
}
