namespace RecklessDriver
{
    class GameObject
    {
        public string Name { get; set; }
        public string tag { get; set; }
        public bool Enabled { get; set; }
        public virtual void OnCollision(GameObject go)
        {
        }
    }
}
