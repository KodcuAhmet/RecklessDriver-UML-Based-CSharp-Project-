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
            player.Name = "Player";

            // Prepare the scenary
            Scene scene = new Scene();
            scene.Start(player);

            // Run a loop
            while (player.IsAlive)
            {
                // Generate GameObjects (sideobjects, traffic etc)
                scene.GenerateNPCs();
                // Player is driving
                Drive();

                // Collide with other objects
                scene.Collide();

                // Repeat until health is 0

            }
            EndGame();
        }
        private void Drive()
        {
            Console.WriteLine("\nPlayer is driving");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine("");
        }

        // Game continues until health is 0 or player ends the game
        public void EndGame()
        {
            Console.WriteLine("Total cash accumulated: {0}", cash);
        }
    }
}
