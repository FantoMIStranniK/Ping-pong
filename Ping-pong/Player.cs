using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Ping_pong
{
    public class Player : GameObject
    {
        public RectangleShape padleShape;

        public bool IsAi {get; private set;} = false;

        private Vector2f size = new Vector2f(250, 7.5f);

        private float speed = 10f;
        private int moveDirection = 0;
        private int width;
        private int height;

        private int countOfTicks = 0;

        public Player(bool isAi, int ScreenWidth)
        {
            IsAi = isAi;

            m_Collider = this;
            m_Movement = this;

            width = ScreenWidth;

            speed = 1.5f;

            padleShape = new RectangleShape(size);

            DrawableShape = padleShape;

            padleShape.Origin = new Vector2f(size.X / 2, size.Y / 2);

            padleShape.FillColor = Color.Green;
            padleShape.OutlineColor = Color.White;
            padleShape.OutlineThickness = 10f;

            tag = "padle";
        }
        public override void Update()
        {
            base.Update();

            GetInput();

            Move();
        }
        public void GetInput()
        {
            if (!IsAi)
                HumanInput();
            else
                AiInput();
        }
        private void HumanInput()
        {
            moveDirection = 0;

            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && CanMoveLeft())
                moveDirection = -1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) && CanMoveRight())
                moveDirection = 1;

        }
        private void AiInput()
        {
            Random rand = new Random();

            if(countOfTicks >= 15)
            {
                countOfTicks = 0;

                if (rand.NextSingle() <= .25f && moveDirection != 0)
                    moveDirection = -moveDirection;
                else
                    moveDirection = rand.Next(-1, 1);
            }
            else
            {
                countOfTicks++;
            }

            if (!CanMoveLeft())
                moveDirection = 1;
            if(!CanMoveRight())
                moveDirection = -1;
        }
        public override void Move()
        {
            base.Move();

            float newX = padleShape.Position.X + moveDirection * speed;

            padleShape.Position = new Vector2f(newX, padleShape.Position.Y);
        }
        private bool CanMoveLeft()
        {
            return padleShape.Position.X - size.X / 2 > 0;
        }
        private bool CanMoveRight() 
        { 
            return padleShape.Position.X + size.X / 2 < width;
        }
    }
}
