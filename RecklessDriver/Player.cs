using System;

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
            GameManager.Instance.AddCash(cash);
        }

        public void Drive()
        {
            Console.WriteLine("\nPlayer is driving [Health={0}]", Health < 0 ? 0 : Health);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine("");
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
