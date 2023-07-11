namespace CountryQuiz.Services.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using FluentAssertions;

public class CountryServiceTests
{
    [Fact]
    public async Task GetContinents_ReturnsAllContinents()
    {
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var expectedResponse = JsonSerializer.Serialize(new GraphQLResponse
        {
            Data = new GraphQLData
            {
                Continents = new List<Continent>
                {
                    new Continent {
                        Name = "Continent 1",
                        Code = "C1",
                        Countries = new List<Country>
                        {
                            new Country
                            {
                                Name = "Country 1",
                                Capital = "Capital 1",
                                Emoji = "😃"
                            }
                        }
                    }
                }
            }
        });

        var httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(expectedResponse)
        };

        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(httpResponseMessage);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var countryService = new CountryService(httpClient);

        var continents = await countryService.GetContinentsWithCountries();

        continents.Should().NotBeNull();

        continents.Should().BeEquivalentTo(new List<Continent>
        {
            new Continent
            {
                Name = "Continent 1",
                Code = "C1",
                Countries = new List<Country>
                {
                    new Country
                    {
                        Emoji = "😃",
                        Name = "Country 1",
                        Capital = "Capital 1"
                    }
                }
            },
        });
    }
}
