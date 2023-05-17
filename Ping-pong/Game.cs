using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;

namespace Ping_pong
{
    public class Game
    {
        private Stopwatch clock = new Stopwatch();

        private Ball ball;
        private Player player1;
        private Player player2;

        private List<GameObject> gameObjects = new List<GameObject>();

        private RenderWindow window;
        private uint wantedFrameRate = 144;

        private uint width = 1600;
        private uint height = 900;

        private bool gameFinished = false;

        public void StartGame()
        {
            Init();

            #region Time variables
            double totalTimeBeforeUpdate = 0d;
            float previousTimeElapsed = 0f;
            float deltaTime = 0;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();
            #endregion

            while (window.IsOpen) 
            {
                #region Time operations
                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;
                #endregion

                if (totalTimeElapsed >= 1/wantedFrameRate)
                {
                    totalTimeBeforeUpdate = 0;

                    DoGameStep();

                    Time.UpdateTime();
                }

                if(gameFinished)
                    window.Close();
            }
        }
        private void DoGameStep()
        {
            Time.UpdateTime();

            Display();

            UpdateGameObjects();

            TryClose();

            CheckBallPosition();
        }
        private void CheckCollisionWithBall(Shape collisionShape)
        {
            ball.TryChangeDirectionOnCollision(collisionShape);
        }
        private void Init()
        {
            Time.Start();

            ball = new Ball();
            player1 = new Player(false, (int)width);
            player2 = new Player(true, (int)width);

            ball.Shape.Position = new Vector2f(width / 2, height / 2);
            player1.padleShape.Position = new Vector2f(width / 2, 120);
            player2.padleShape.Position = new Vector2f(width / 2, height - 120);

            window = new RenderWindow(new VideoMode(width, height), "Game window");

            window.SetFramerateLimit(wantedFrameRate);

            Border left = new Border(25, (int)height);
            Border right = new Border(25, (int)height);

            right.BorderShape.Position = new Vector2f((int)width, (int)height / 2);
            left.BorderShape.Position = new Vector2f(0, (int)height / 2);

            gameObjects = new List<GameObject>()
            {
                ball,
                player1, 
                player2,
                left,
                right,
            };
        }
        private void CheckBallPosition()
        {
            if(ball.Shape.Position.Y - ball.Shape.Radius <= 100 || ball.Shape.Position.Y + ball.Shape.Radius >= height -100)
                gameFinished = true;
        }
        private void UpdateGameObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update();

                if (gameObject.tag is not "ball")
                {
                    CheckCollisionWithBall(gameObject.DrawableShape);
                }
            }
        }
        #region Window
        private void TryClose()
        {
            window.Closed += WindowClosed;
        }
        private void Display()
        {
            window.Clear(Color.Black);

            window.DispatchEvents();

            DrawGameObjects();

            window.Display();
        }
        private void DrawGameObjects()
        {
            foreach(var gameObject in gameObjects)
            {
                window.Draw(gameObject.DrawableShape);
            }
        }
        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
        #endregion
    }
}
