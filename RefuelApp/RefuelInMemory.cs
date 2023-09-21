namespace RefuelApp
{
    public class RefuelInMemory : RefuelBase
    {
        public override event DistanceAddDelegate DistanceAdded;
        private List<float> distances = new List<float>();
        public RefuelInMemory(string name) 
            : base(name)
        {
        }

        public override void AddDistance(float distance)
        {
            if (distance >= 250 && distance <= 2000)
            {
                this.distances.Add(distance);
                if (DistanceAdded != null)
                {
                    DistanceAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Outside the range traveled 250 - 2500 Km");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistic = new Statistics();
            foreach (var distance in this.distances)
            {
                statistic.AddDistance(distance);
            }
        return statistic;
        }
    }
}