using RefuelApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===================================\n" +
                          "Welcome to the Refuel a Car Program\n" +
                          "===================================\n");
      
        string namecar = "DOL12345";
        Console.WriteLine("Enter name a car:\n");
        string userInput = Console.ReadLine(); 
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            namecar = userInput;
        }

        bool exitAdd = true;
        while (exitAdd)
        {
            Console.WriteLine( "---------------------------------------------------\n" +
                               "Select program operating mode by choosing a button:\n" +
                              $"I - Info\n" +
                              $"M - Mode Memory\n" +
                              $"F - Mode File\n" +
                              $"Q - Quit\n" +
                              $"---------------------------------------------------\n");


            var input = Console.ReadLine()?.ToLower();
            Console.WriteLine();

            switch (input)
            {
                case "q":
                    exitAdd = false;
                    break;
                case "m":
                    ToMode(namecar, true);
                    break;
                case "f":
                    ToMode(namecar, false);
                    break;
                case "i":
                    Info();
                    break;
                default:
                    Console.WriteLine("Invalid operation.\n");
                    break;
            }
        }
    }

    static void ToMode(string nameCar, bool isMemory)
    {
        var car = isMemory ? (IRefuel)new RefuelInMemory(nameCar) : (IRefuel)new RefuelInFile(nameCar);
        car.DistanceAdded += DistanceAddDelegate;
        Add(car);
        ShowStatistic(car);
    }

    static void DistanceAddDelegate(object sender, EventArgs args)
    {
        Console.WriteLine("Added a new distance.\n");
    }

    static void Info()
    {
        Console.WriteLine("The program is used to calculate the fuel consumption gauge with a full tank of 50l. \r\n" +
             "You can enter one or more trips.\n" +
             "The data can be stored in memory or stored in a file,\n" +
             "Calculates MIN, MAX, Average fuel wear per 100km,\n" +
             "Sum of refueled fuel and traveled Km,\n" +
             "Your Driving Economy Class.\n\n" +
             "A - is very good result\n" +
             "G - is very  bed result\n\n" +
             "=========================\n" +
             "Legend of driving economy\n\n" +
             "A: 2.5 - 4.9 l/km\n" +
             "B: 5.0 - 5.4 l/Km\n" +
             "C: 5.5 - 5.9 l/km\n" +
             "D: 6.0 - 6.4 l/km\n" +
             "E: 6.5 - 6.9 l/km\n" +
             "F: 7.0 - 8.0 l/km\n" +
             "G: Above 8.0 l/km\n\n");
    }
    static void Add(IRefuel car)
    {
        while (true)
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                               "Enter the distance traveled in Km since the last refueling 50l fuel\n" +
                               "(Press Q to exit and view statistics)\n");
            Console.WriteLine("Enter distance range between: 250 - 2000 Km");

            var input = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(input) || input.ToLower() == "q")
            {
                break;
            }

            try
            {
                car.AddDistance(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Catch Exception: {ex.Message}");
            }
        }
    }

    static void ShowStatistic(IRefuel car)
    {
        var statistic = car.GetStatistics();

        Console.WriteLine($"Car {car.Name}\n" +
                        $"\nLowest fuel consumption: {statistic.MinCom:N2} l/100km\n" +
                        $"Highest fuel consumption: {statistic.MaxCom:N2} l/100km\n" +
                        $"Amount of fuel: {statistic.Fuel} l\n" +
                        $"Sum driven: {statistic.SumKm} km\n" +
                        $"\nAverage fuel comsumption: {statistic.Avg:N2}\n" +
                        $"Driving economy: {statistic.AvgLetter}\n");
    }
}
