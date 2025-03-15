using System.Security.Cryptography.X509Certificates;

namespace RecklessDriver
{
    class GameManager
    {
        private static GameManager instance = new GameManager();
        public static GameManager Instance => instance;
        private int cash;

        private GameManager()
        {

        }
        public int GetCash()
        {
            return cash;
        }
        public void AddCash(int amount)
        {
            cash += amount;
        }
        public void NewGame()
        {
            // Choose a vehicle
            PlayerVehicle vehicle = new PlayerVehicle("Sedan", 5, 70, 4);

            // Create a player object
            Player player = new Player(100, vehicle);
            player.Tag = "Player";

            // Prepare the scenary
            Scene scene = new Scene();
            scene.Start(player);

            // Run a loop
            while (player.IsAlive)
            {
                Console.Clear();
                // Generate GameObjects (sideobjects, traffic etc)
                scene.Execute();
                // Player is driving
                player.Drive();

                // Repeat until health is 0

            }
            EndGame();
        }

        // Game continues until health is 0 or player ends the game
        public void EndGame()
        {
            Console.WriteLine("Total cash accumulated: {0}", cash);
        }
    }
}
