

namespace Ping_pong
{
    public class GameHandler
    {
        private bool gameStarted = true;

        private Game game = new Game();
        public void LaunchGame()
        {
            game.StartGame();
        }
    }
}
