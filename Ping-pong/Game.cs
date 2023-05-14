using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ping_pong
{
    public class Game
    {
        private Ball ball;
        RenderWindow window;
        private Stopwatch clock = new Stopwatch();


        public void StartGame()
        {
            Init();

            double totalTimeBeforeUpdate = 0d;
            float previousTimeElapsed = 0f;
            float deltaTime = 0;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();

            while (window.IsOpen) 
            {
                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                if (totalTimeElapsed >= 0.03)
                {
                    totalTimeBeforeUpdate = 0;

                    DoGameStep();

                    Time.UpdateTime();
                }
            }
        }
        private void Init()
        {
            Time.Start();

            ball = new Ball();

            window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            window.SetFramerateLimit(30);
        }
        private void DoGameStep()
        {
            Time.UpdateTime();

            Display();

            ball.Update();

            TryClose();
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
