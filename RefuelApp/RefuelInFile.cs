using System.Reflection.Metadata.Ecma335;

namespace RefuelApp
{
    public class RefuelInFile : RefuelBase
    {
        public override event DistanceAddDelegate DistanceAdded;
        private const string fileName = "car.txt";
        private List<float> distances = new List<float>();
        public RefuelInFile(string name) 
            : base(name)
        {
        }

        public override void AddDistance(float distance)
        {
            using(var writer =File.AppendText(fileName))
            {
                if (distance >= 250 && distance <= 2000)
                {
                    writer.WriteLine(distance);
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
            var distanceFromFile = this.ReadDistanceFromFile();
            var resulut = this.CoutStatistic(distanceFromFile);
            return resulut;
        }
        private List<float> ReadDistanceFromFile()
        {
            var distances = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        distances.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return distances;
        }

        public Statistics CoutStatistic(List<float> distances)
        {
            var statistic = new Statistics();
            foreach (var distance in distances) 
            { 
                statistic.AddDistance(distance);
            }
            return statistic;
        }
    }
}
