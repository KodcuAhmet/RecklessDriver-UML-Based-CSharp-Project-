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
            base.OnCollision(other);
        }
    }
}
