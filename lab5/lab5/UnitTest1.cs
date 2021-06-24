using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace lab5
{
    public class UnitTest
    {
        private readonly HttpClient client;

        public UnitTest()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://shikimori.org");
        }

        [Theory]
        [InlineData("GET", 123223)]
        public async Task GetUserRatesExistTestAsync(string method, int? id = null)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/v2/user_rates/{id}");

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Theory]
        [InlineData("GET", 7)]
        public async Task GetUserRatesNotExistTestAsync(string method, int? id = null)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/v2/user_rates/{id}");

            // Act
            var response = await client.SendAsync(request);

            // Assert;
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


        }
        [Theory]
        [InlineData("POST", 779734)]
        public async Task PostTopicIgnoreTestAsync(string method, int? id = null)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/v2/topics/{id}/ignore");

            // Act
            var response = await client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }
        [Theory]
        [InlineData("DELETE", 779734)]
        public async Task DeleteTopicIgnoreTestAsync(string method, int? id = null)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/v2/topics/{id}/ignore");
            // Act
            var response = await client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);


        }

        [Theory]
        [InlineData(9768)]
        public async Task PutTestAsync(int? id = null)
        {
            string content = "{ \"user_rate\": { \"chapters\": \"4\", \"episodes\": \"2\", \"rewatches\": \"5\", \"score\": \"10\", \"status\": \"watching\", \"text\": \"test\", \"volumes\": \"3\" } }";
            var requestContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/v2/user_rates/{id}", requestContent);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}

