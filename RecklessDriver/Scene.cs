namespace RecklessDriver
{
    class Scene
    {
        private const int NPC_TYPES = 2;
        private const int SIDEOBJECT_COUNT = 2;
        private const int TRAFFIC_COUNT = 2;
        private List<SideObject> sideList = new List<SideObject>();
        private List<TrafficCar> trafficList = new List<TrafficCar>();
        private Player player;
        private Random random = new Random();

        public void Start(Player player)
        {
            this.player = player;
        }

        public void GenerateNPCs()
        {
            sideList.Add(GenerateSideObjects());
            trafficList.Add(GenerateTraffic());
            DisplaySideObjects();
            DisplayTraffic();
        }

        public void Collide()
        {
            GameObject go = null;
            if (random.Next(2) == 0)
                return;

            switch (random.Next(NPC_TYPES))
            {
                case 0: // SideObjects
                    go = sideList[random.Next(sideList.Count)];
                    break;
                case 1: // Traffic
                    go = sideList[random.Next(sideList.Count)];
                    break;
            }

            if (go != null)
            {
                go.OnCollision(player);
                Thread.Sleep(1000);
            }
        }

        private SideObject GenerateSideObjects()
        {
            switch (random.Next(SIDEOBJECT_COUNT))
            {
                case 0: // FireHydrant
                    return new FireHydrant(5, 10);
                case 1: // LetterBox
                    return new LetterBox(8, 13);
                default:
                    break;
            }
            return null;
        }

        private TrafficCar GenerateTraffic()
        {
            switch (random.Next(TRAFFIC_COUNT))
            {
                case 0: // Sedan
                    return new Sedan(15, 80);
                case 1: // Van
                    return new Van(18, 90);
                default:
                    break;
            }
            return null;
        }

        public void DisplaySideObjects()
        {
            Console.WriteLine("<<<<< SIDEOBJECTS >>>>>>>");
            foreach (var obj in sideList)
            {
                Console.WriteLine(obj.Name);
            }
        }

        public void DisplayTraffic()
        {
            Console.WriteLine("<<<<< TRAFFIC >>>>>>>");
            foreach (var obj in trafficList)
            {
                Console.WriteLine(obj.Name);
            }
        }
    }
}
