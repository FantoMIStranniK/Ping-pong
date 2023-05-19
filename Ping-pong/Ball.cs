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

        private float lastYDirection = -1;
        private float lastXDirection = -1;

        public Ball() 
        {
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
        public override void Awake()
        {
            base.Awake();

            Shape.Position = new Vector2f(1600 / 2, 900 / 2);
        }
        public override void Move()
        {
            base.Move();

            Vector2f direction = new Vector2f(xDirection, yDirection);

            Shape.Position += direction * speed;
        }
        public void TryChangeDirectionOnCollision(GameObject collideable)
        {
            if (IsCollidingWith(Shape, collideable.DrawableShape))
            {
                ChangeDirection(collideable.tag);
            }
            else
            {
                lastYDirection = yDirection;                
                lastXDirection = xDirection;
            }
        }
        public void ChangeDirection(string tag)
        {
            Random rand = new Random();

            if (lastYDirection == yDirection && tag is not "border")
            {
                yDirection = -yDirection;
            }

            if (lastXDirection == xDirection && tag is "border")
            {
                xDirection = -xDirection;
            }
        }
        public void ResetBall(float x, float y)
        {
            yDirection = -yDirection;

            Shape.Position = new Vector2f(x, y);
        }
    }
}
