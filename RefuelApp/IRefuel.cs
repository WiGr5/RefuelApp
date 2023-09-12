using static RefuelApp.RefuelBase;

namespace RefuelApp
{
    public interface IRefuel
    {
        string Name { get; }
        void AddDistance(float data);
        void AddDistance(string data);
        Statistics GetStatistics();
        event DistanceAddDelegate DistanceAdded;
    }
}