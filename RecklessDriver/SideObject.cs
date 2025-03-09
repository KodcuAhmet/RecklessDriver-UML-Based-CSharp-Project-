namespace RecklessDriver
{
    class SideObject : GameObject
    {
        public int Damage { get; set; }
        public int Cash { get; set; }
        public int Count;
        public SideObject(int damage, int cash)
        {
            Damage = damage;
            Cash = cash;
        }
    }
    class FireHydrant : SideObject
    {
        public FireHydrant(int damage, int cash) : base(damage, cash)
        {
        }

        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
