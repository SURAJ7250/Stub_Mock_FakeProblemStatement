using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StubMockFake;
using static StubMockFake.StarBucks;

namespace StubMockFake
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //  Using Fake
        public void OrderACoffee_Should_Return_Received_Message()
        {
            IMakeACoffee coffee = new FakeStarBucksStore();
            StarBucksStore store = new StarBucksStore(new FakeStarBucksStore());
            //Act
            string result = store.OrderCoffee(2, 4);
            //Assert
            Assert.AreEqual("Your Order is received.", result);
        }
        //Using Stub
        [TestMethod]
        public void OrderACoffee_Should_Return_Received_MessageUsingStub()
        {
            StarBucksStore store = new StarBucksStore(new StubStarbucks());
            string result = store.OrderCoffee(2, 4);
            Assert.AreEqual("Your Order is received.", result);
        }
        //Using Mock
        [TestMethod]
        public void OrderACoffee_Should_Return_Received_MessageUsingMock()
        {
            var service = new Mock<IMakeACoffee>();
            service.Setup(x => x.CheckIngridentAvalability()).Returns(true);
            service.Setup(x => x.CoffeeMaking(It.IsAny<int>(), It.IsAny<int>())).Returns("Your Order is received.");
            var store = new StarBucksStore(service.Object);
            var result = store.OrderCoffee(2, 4);
            Assert.AreEqual("Your Order is received.", result);
        }
    }
}