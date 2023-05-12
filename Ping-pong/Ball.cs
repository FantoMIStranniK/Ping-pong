using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ping_pong
{
    public class Ball : GameObject
    {
        public CircleShape BallShape;
        public float speed { get; private set; } = .000001f;

        private int YDirection = 0;
        private int XDirection = 1;

        public Ball() 
        {
            BallShape = new CircleShape(150);
        }
        public void Move()
        {
            float newBallX = BallShape.Position.X + XDirection * Time.deltaTime * speed;
            float newBallY = BallShape.Position.Y + YDirection * Time.deltaTime * speed;

            BallShape.Position = new Vector2f(BallShape.Position.X + newBallX, BallShape.Position.Y + newBallY);
        }

        public override void Update()
        {
            Move();
        }
    }
}
