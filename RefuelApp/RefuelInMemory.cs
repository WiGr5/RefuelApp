using System.Runtime.CompilerServices;

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

        public override void AddDistance(string distance)
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
        public override Statistics GetStatistics()
        {
            var statistic = new Statistics();
            foreach (var data in this.distances)
            {
                statistic.AddDistance(data);
            }
        return statistic;
        }
    }
}