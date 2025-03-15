namespace RecklessDriver
{
    class Scene
    {
        private const int NPC_TYPES = 2;
        private const int SIDEOBJECT_COUNT = 2;
        private const int TRAFFIC_COUNT = 2;
        private Queue<SideObject> sideList = new Queue<SideObject>();
        private Queue<Vehicle> trafficList = new Queue<Vehicle>();
        private Player player;
        private Random random = new Random();

        public void Start(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            GenerateSideObjects();
            GenerateTraffic();
            DisplaySideObjects();
            DisplayTraffic();
            Collide();
        }

        public void Collide()
        {
            GameObject go = null;
            if (random.Next(2) == 0)
                return;

            switch (random.Next(NPC_TYPES))
            {
                case 0: // SideObjects
                    go = sideList.ElementAt(random.Next(sideList.Count));
                    break;
                case 1: // Traffic
                    go = trafficList.ElementAt(random.Next(trafficList.Count));
                    break;
            }

            if (go != null)
            {
                go.OnCollision(player);
            }
            Thread.Sleep(1000);
        }

        private void GenerateSideObjects()
        {
            if (sideList.Count > 6)
            {
                sideList.Dequeue(); // Removing the oldest object
            }

            SideObject sideObject = null;
            switch (random.Next(SIDEOBJECT_COUNT))
            {
                case 0: // FireHydrant
                    sideObject = new FireHydrant(5, 10);
                    break;
                case 1: // LetterBox
                    sideObject = new LetterBox(8, 13);
                    break;
            }
            sideList.Enqueue(sideObject);
        }

        private void GenerateTraffic()
        {
            if (trafficList.Count > 6)
            {
                trafficList.Dequeue(); // Removing the oldest object
            }

            Vehicle vehicle = null;
            switch (random.Next(TRAFFIC_COUNT))
            {
                case 0: // Sedan
                    vehicle = new Sedan(15, 80);
                    break;
                case 1: // Van
                    vehicle = new Van(18, 90);
                    break;
            }
            trafficList.Enqueue(vehicle);
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
