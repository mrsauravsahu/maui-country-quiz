namespace CountryQuiz.Services;

using System.Net.Http;
using System.Text;
using System.Text.Json;

public class CountryService
{
    private readonly HttpClient _httpClient;
    private const string ApiEndpoint = "https://countries.trevorblades.com";

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? new HttpClient();
    }

    public async Task<List<Continent>> GetContinentsWithCountries()
    {
        var request = new GraphQLRequest
        {
            Query = @"
                query {
                    continents {
                        code
                        name
                        countries {
                            name
                            capital
                            emoji
                        }
                    }
                }"
        };

        var jsonRequest = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(ApiEndpoint, content);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var graphQLResponse = JsonSerializer.Deserialize<GraphQLResponse>(jsonResponse);


        return graphQLResponse.Data.Continents;
    }
}

public class GraphQLRequest
{
    public string Query { get; set; }
}

public class GraphQLResponse
{
    public GraphQLData Data { get; set; }
}

public class GraphQLData
{
    public List<Continent> Continents { get; set; }
}

public class Continent
{
    public string Code { get; set; }
    public string Name { get; set; }
    public List<Country> Countries { get; set; }
}

public class Country
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public string Emoji { get; set; }
}
