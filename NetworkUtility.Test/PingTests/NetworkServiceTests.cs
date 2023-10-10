using FluentAssertions;
using NetworkUtility.Ping;

namespace NetworkUtility.Test.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - Variables, classes, Mocks, etc.
            var pingService = new NetworkService();


            //Act - Execute the function
            var result = pingService.SendPing();


            ////Assert - Did it return what we expected? - using Xunit
            // Assert.Equal("Success: Ping sent!", pingService.SendPing());

            //Assert - Did it return what we expected? - Using fluent assertions
            result.Should().Be("Success: Ping sent!");
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnsSumOfTwoNumbers(int a, int b, int expected)
        {
            //Arrange - Variables, classes, Mocks, etc.
            var pingService = new NetworkService();

            //Act - Execute the function
            var result = pingService.PingTimeout(a, b);

            //Assert - Did it return what we expected?
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(4);
            result.Should().NotBe(0);
            result.Should().NotBeInRange(-10000, 0);
        }
    }
}
