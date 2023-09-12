using RefuelApp;

namespace RefuelApp.Test
{
    public class Tests
    {
        [Test]

        public void TestGetStatistic()
        {
            // arrange

            var car = new RefuelInMemory("DOL12345");
            car.AddDistance(500);
            car.AddDistance(1000);
            car.AddDistance(1500);
            car.AddDistance(2000);

            // act
            var result = car.GetStatistics();

            // assert
            Assert.AreEqual(5000, result.SumKm);
            Assert.AreEqual(2000, result.MaxKm);
            Assert.AreEqual(500, result.MinKm);
            Assert.AreEqual(10, result.MaxCom);
            Assert.AreEqual(2.5, result.MinCom);
            Assert.AreEqual(4, result.Avg);

        }
    }
}