using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
