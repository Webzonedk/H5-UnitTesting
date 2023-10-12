using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Test.PingTests
{
    public class NetworkServiceTests
    {

        private readonly NetworkService _pingService;

        public NetworkServiceTests()
        {
            _pingService = new NetworkService();
        }


        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - Variables, classes, Mocks, etc.

            //Act - Execute the function
            var result = _pingService.SendPing();

            //Assert - Did it return what we expected? - Using fluent assertions
            result.Should().Be("Success: Ping sent!");
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Contain("Success", Exactly.Once());
        }


        // Testing multiple inputs
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnsSumOfTwoNumbers(int a, int b, int expected)
        {
            //Arrange - Variables, classes, Mocks, etc.

            //Act - Execute the function
            var result = _pingService.PingTimeout(a, b);

            //Assert - Did it return what we expected?
            result.Should().Be(expected);
            result.Should().BeOneOf(new[] { 2, 4 });
            result.Should().NotBe(0);
            result.Should().NotBeInRange(-10000, 0);
        }

        // Testing specific Method
        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            //Arrange - Variables, classes, Mocks, etc.

            //Act - Execute the function
            var result = _pingService.LastPingDate();

            //Assert - Did it return what we expected? - Using fluent assertions
            result.Should().BeAfter(1.January(2020));
            result.Should().BeBefore(1.January(2024));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnPingOptions()
        {
            //Arrange - Variables, classes, Mocks, etc.
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act - Execute the function
            var result = _pingService.GetPingOptions();

            //Assert WARNING: "Be" Careful - Did it return what we expected? - Using fluent assertions
            result.Should().BeOfType<PingOptions>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }


        [Fact]
        public void NetworkService_GetPingOptionsList_ReturnPingOptions()
        {
            //Arrange - Variables, classes, Mocks, etc.
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act - Execute the function
            var result = _pingService.GetPingOptions();

            //Assert WARNING: "Be" Careful - Did it return what we expected? - Using fluent assertions
            result.Should().BeOfType<PingOptions>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }
    }
}
