using SFML.Graphics;
using SFML.System;


namespace Ping_pong
{
    public class Ball : GameObject
    {
        public CircleShape Shape;
        public float speed = 2f;

        private int YDirection = 1;
        private int XDirection = 1;

        public Ball() 
        {
            Shape = new CircleShape(150);

            Shape.Origin = new Vector2f(Shape.Radius, Shape.Radius);
        }
        public void Move()
        {
            Vector2f direction = new Vector2f(XDirection, YDirection);

            Shape.Position += direction * speed;
        }

        public override void Update()
        {
            Move();
        }
    }
}
