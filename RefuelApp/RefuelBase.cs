namespace RefuelApp
{
    public abstract class RefuelBase : IRefuel
    {
        public delegate void DistanceAddDelegate(object sender, EventArgs args);
        public abstract event DistanceAddDelegate DistanceAdded;

        public RefuelBase(string name)
        {
            this.Name = name;
        }
        public string Name {get; private set ;}
        public abstract void AddDistance(float data);
        public abstract void AddDistance(string data);
        public abstract Statistics GetStatistics(); 
    }
}
