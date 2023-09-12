namespace RefuelApp
{
    public class Statistics
    {
        public float MinKm { get; private set; } 
        public float MaxKm { get; private set; } 
        public float SumKm { get; private set; } 
        public int FullTank { get; private set; } 
        public int Fuel { get { return this.FullTank * 50; } } 
        public float MinCom
        {
            get
            {
                return this.MaxKm == 0 ? 0 : (50 / this.MaxKm) * 100;
            }
        } 
        public float MaxCom
        {
            get
            {
                return this.MinKm == 0 ? 0 : (50 / this.MinKm) * 100;
            }
        } 
        public float Avg
        {
            get
            {
                return this.SumKm == 0 ? 0 : ((this.Fuel) / this.SumKm) * 100;
            }
        }
        public char AvgLetter
        {
            get
            {
                switch (this.Avg)
                {
                    case var avg when avg >= 8:
                        return 'G';
                    case var avg when avg >= 7:
                        return 'F';
                    case var avg when avg >= 6.5:
                        return 'E';
                    case var avg when avg >= 6:
                        return 'D';
                    case var avg when avg >= 5.5:
                        return 'C';
                    case var avg when avg >= 5:
                        return 'B';
                    case var avg when avg >= 2.5:
                        return 'A';
                    default:
                        return '0';
                }
            }
        }
        public Statistics()
        {
            this.SumKm = 0;
            this.FullTank = 0;
            this.MaxKm = float.MinValue;
            this.MinKm = float.MaxValue;
        }
        public void AddDistance(float data)
        {
            this.FullTank++;
            this.SumKm += data;
            this.MinKm = Math.Min(this.MinKm, data);
            this.MaxKm = Math.Max(this.MaxKm, data);
        }
    }
}
