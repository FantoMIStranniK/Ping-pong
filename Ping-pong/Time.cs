using System.Diagnostics;


namespace Ping_pong
{
    public static class Time
    {
        public static int deltaTime { get; private set; } = 0;
        private static Stopwatch timer = new Stopwatch();

        public static void Start()
        {
            timer.Start();
            deltaTime = 0;
        }
        public static void UpdateTime()
        {
            deltaTime = timer.Elapsed.Milliseconds;

            timer.Restart();
        }
    }
}
