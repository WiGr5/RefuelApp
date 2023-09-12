using RefuelApp;

namespace RefuelApp.Test
{
    internal class TypeTests
    {

        [Test]
        public void GetCarReturnsDifferentObjects()
        {
            var car1 = AddDistance("DOL12345");
            var car2 = AddDistance("DOL67890");

            Assert.AreNotSame(car1, car2);
            Assert.IsFalse(car1.Equals(car2));
            Assert.IsFalse(Object.ReferenceEquals(car1, car2));
        }

        [Test]
        public void TwoVarsCanReferenceSameObject()
        {
            var car1 = AddDistance("DOL12345");
            var car2 = car1;

            Assert.AreSame(car1, car2);
            Assert.IsTrue(car1.Equals(car2));
            Assert.IsTrue(object.ReferenceEquals(car1, car2));
        }

        private RefuelInMemory AddDistance(string nameCar)
        {
            return new RefuelInMemory(nameCar);
        }

    }
}