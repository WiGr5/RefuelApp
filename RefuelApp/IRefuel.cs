using static RefuelApp.RefuelBase;

namespace RefuelApp
{
    public interface IRefuel
    {
        string Name { get; }
        void AddDistance(float distance);
        void AddDistance(string distance);
        Statistics GetStatistics();
        event DistanceAddDelegate DistanceAdded;
    }
}