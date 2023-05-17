using SFML.Graphics;
using SFML.System;


namespace Ping_pong
{
    public class Ball : GameObject
    {
        public CircleShape Shape;

        public float speed = 25f;
        public float yDirection = -1;
        public float xDirection = -0.5f;

        public Ball() 
        {
            m_Collider = this;
            m_Movement = this;

            speed = 2f;

            Shape = new CircleShape(75);

            DrawableShape = Shape;

            Shape.Origin = new Vector2f(Shape.Radius, Shape.Radius);

            Shape.FillColor = Color.Red;
            Shape.OutlineColor = Color.White;
            Shape.OutlineThickness = 10f;

            tag = "ball";
        }

        public override void Update()
        {
            base.Update();

            Move();
        }
        public override void Move()
        {
            base.Move();

            Vector2f direction = new Vector2f(xDirection, yDirection);

            Shape.Position += direction * speed;
        }
        public void TryChangeDirectionOnCollision(Shape collisionShape)
        {
            if (m_Collider.IsCollidingWith(Shape, collisionShape))
                ChangeDirection();
        }
        public void ChangeDirection()
        {
            Random rand = new Random();

            xDirection = -xDirection + rand.NextSingle() * (xDirection / Math.Abs(xDirection));
            yDirection = -yDirection + rand.NextSingle() * (yDirection / Math.Abs(yDirection));
        }
    }
}
