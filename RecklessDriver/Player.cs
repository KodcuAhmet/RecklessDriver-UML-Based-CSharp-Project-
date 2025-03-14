namespace RecklessDriver
{
    class Player : GameObject
    {
        public int Health { get; set; }
        public PlayerVehicle Vehicle { get; set; }
        public Player(int health, PlayerVehicle vehicle)
        {
            Health = health;
            Vehicle = vehicle;
            Name = "Player";
        }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public void ApplyDamage(int damage, int cash)
        {
            Health -= damage - Vehicle.Strength;
            Console.WriteLine("Player health:{0}", Health);
            GameManager.Instance.AddCash(cash);
        }
        public void Accelerate()
        {
            Vehicle.Up();
        }
        public void Brake()
        {
            Vehicle.Back();
        }
        public void SteerLeft()
        {
            Vehicle.Left();
        }
        public void SteerRight()
        {
            Vehicle.Right();
        }
    }
}
