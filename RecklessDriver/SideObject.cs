namespace RecklessDriver
{
    class SideObject : GameObject
    {
        public int Damage { get; set; }
        public int Cash { get; set; }
        protected int Count = 0;
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
            Name = "FireHydrant";
        }

        public override void OnCollision(GameObject other)
        {
            if (other.Tag == "Player")
            {
                Player player = other as Player;
                if (Count == 0)
                {
                    Console.WriteLine("#### COLLISION -> [FireHydrant] Fountain");
                    player.ApplyDamage(Damage, Cash);
                }
                else
                {
                    Console.WriteLine("#### COLLISION -> [FireHydrant] collided again");
                    player.ApplyDamage(Damage, Cash * Count);
                }
            }
        }
    }
    class LetterBox : SideObject
    {
        public LetterBox(int damage, int cash) : base(damage, cash)
        {
            Name = "LetterBox";
        }

        public override void OnCollision(GameObject other)
        {
            if (other.Tag == "Player")
            {
                Player player = other as Player;
                if (Count == 0)
                {
                    Console.WriteLine("#### COLLISION -> [LetterBox] Letters faiiling");
                    player.ApplyDamage(Damage, Cash);
                }
                else
                {
                    Console.WriteLine("#### COLLISION -> [LetterBox] collided again");
                    player.ApplyDamage(Damage, Cash * Count);
                }
            }
        }
    }
}
