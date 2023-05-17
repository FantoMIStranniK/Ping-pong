using SFML.Graphics;
using SFML.System;

namespace Ping_pong
{
    public class Border : GameObject
    {
        public RectangleShape BorderShape;

        public Border(int height, int width) 
        { 
            BorderShape = new RectangleShape(new Vector2f(height, width));

            DrawableShape = BorderShape;

            BorderShape.FillColor = Color.Blue;

            BorderShape.Origin = new Vector2f(height / 2, width / 2);

            tag = "border";
        }
    }
}
