namespace RecklessDriver
{
    class TrafficCar : GameObject
    {
        public int Damage { get; set; }
        public int Cash { get; set; }
        public TrafficCar(int damage, int cash)
        {
            Damage = damage;
            Cash = cash;
        }
    }

    class Sedan : TrafficCar
    {
        public Sedan(int damage, int cash) : base(damage, cash)
        {
        }

        public override void OnCollision(GameObject other)
        {
            if (other.Name == "Player")
            {
                Player player = other as Player;
                Console.WriteLine("#### COLLISION -> [Sedan] Soarks flying");
                player.ApplyDamage(Damage, Cash);
            }
        }
    }

    class Van : TrafficCar
    {
        public Van(int damage, int cash) : base(damage, cash)
        {
            Name = "Van";
        }

        public override void OnCollision(GameObject other)
        {
            if (other.Name == "Player")
            {
                Player player = other as Player;
                Console.WriteLine("#### COLLISION -> [Van] Milk bottles falling");
                player.ApplyDamage(Damage, Cash);
            }
        }
    }
}
