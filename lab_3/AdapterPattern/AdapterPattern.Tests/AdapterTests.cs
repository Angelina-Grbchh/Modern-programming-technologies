using NUnit.Framework;

namespace AdapterPattern.Tests
{
    [TestFixture]
    public class AdapterTests
    {
        [Test]
        public void Adapter_TransformsRequest_Correctly()
        {
            // Arrange
            var adaptee = new Adaptee();
            var adapter = new Adapter(adaptee);

            // Act
            string result = adapter.GetRequest();

            // Assert
            Assert.That(result, Is.EqualTo("This is 'Specific request.'"));
        }
    }
}
