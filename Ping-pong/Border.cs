using SFML.Graphics;
using SFML.System;

namespace Ping_pong
{
    public class Border : GameObject
    {
        public RectangleShape BorderShape { get; private set; }

        public Border(int height, int width) 
        { 
            BorderShape = new RectangleShape(new Vector2f(height, width));

            DrawableShape = BorderShape;

            BorderShape.FillColor = Color.Blue;

            BorderShape.Origin = new Vector2f(height / 2, width / 2);

            tag = "border";
        }
        public void SetPosition(int width, int height)
        {
            BorderShape.Position = new Vector2f(width, height / 2);
        }
    }
}
