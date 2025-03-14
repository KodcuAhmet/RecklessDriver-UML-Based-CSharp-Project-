namespace RecklessDriver
{
    class PlayerVehicle
    {
        public string Name { get; private set; }
        public int Handling { get; private set; }
        public int TopSpeed { get; private set; }
        public int Strength { get; set; }

        public PlayerVehicle(string name, int handling, int topSpeed, int strength)
        {
            Name = name;
            Handling = handling;
            TopSpeed = topSpeed;
            Strength = strength;
        }

        public void Up() { }
        public void Back() { }
        public void Left() { }
        public void Right() { }
    }
}
