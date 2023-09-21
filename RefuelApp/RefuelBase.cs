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
        public abstract void AddDistance(float distance);
        public void AddDistance(string distance)
        {
            if (float.TryParse(distance, out float result))
            {
                this.AddDistance(result);
            }
            else
            {
                throw new Exception("Bed value ");
            }
        }
        public abstract Statistics GetStatistics(); 
    }
}
