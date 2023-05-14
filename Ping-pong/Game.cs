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
        private RenderWindow window;

        List<GameObject> GameObjects = new List<GameObject>();

        public void StartGame()
        {
            Init();

            #region Time variables
            double totalTimeBeforeUpdate = 0d;
            float previousTimeElapsed = 0f;
            float deltaTime = 0;
            float totalTimeElapsed = 0f;
            #endregion

            Clock clock = new Clock();

            while (window.IsOpen) 
            {
                #region Time operations
                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;
                #endregion

                if (totalTimeElapsed >= 0.03)
                {
                    totalTimeBeforeUpdate = 0;

                    DoGameStep();

                    Time.UpdateTime();
                }
            }
        }
        private void DoGameStep()
        {
            Time.UpdateTime();

            Display();

            UpdateGameObjects();

            TryClose();
        }
        private void Init()
        {
            Time.Start();

            ball = new Ball();

            window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            window.SetFramerateLimit(30);

            GameObjects.Add(ball);

        }
        private void UpdateGameObjects()
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update();
            }
        }
        private void TryClose()
        {
            window.Closed += WindowClosed;
        }
        private void Display()
        {
            window.Clear(Color.Black);

            window.DispatchEvents();

            window.Draw(ball.Shape);

            window.Display();
        }
        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}
