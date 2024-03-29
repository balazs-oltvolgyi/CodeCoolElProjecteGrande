using SolarWatch.Contracts;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using OfferOasisBackend.Models;
using OfferOasisBackend.Service.Authentication;
using System.Configuration;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OfferOasisBackend.IntegrationTests;

public class ProductControllerIntegrationTests
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        var factory = new WebApplicationFactory<Program>();
        string connectionString = Environment.GetEnvironmentVariable("MyConnectionString");
        Environment.SetEnvironmentVariable("CONNECTION_STRING", connectionString);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        _client = factory.CreateClient();

        AuthRequest authRequest = new AuthRequest("admin@admin.com", "admin123");
        var jsonString = JsonSerializer.Serialize(authRequest);
        var jsonStringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = _client.PostAsync("/Auth/Login", jsonStringContent).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        var desContent = JsonSerializer.Deserialize<AuthResponse>(content, options);
        var token = desContent.Token;
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    }

    [Test]
    public async Task GetProductById_ReturnsProductWithCorrectId()
    {
        // Arrange
        var id = 1;

        // Act
        var response = await _client.GetAsync($"/GetProduct/{id}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var responseContent = await response.Content.ReadAsStringAsync();
        var productData = JsonConvert.DeserializeObject<Product>(responseContent);

        Assert.NotNull(productData);
        Assert.That(productData.Id, Is.EqualTo(id));
    }

    [Test]
    public async Task GetAllProducts_ReturnsOkStatus()
    {
        // Act
        var response = await _client.GetAsync($"/products");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task AddProduct_ReturnsCreatedResponse()
    {
        // Arrange
        Random random = new Random();
        var productNumber = random.Next(1, 10000);
        var newProduct = new Product(0, $"product {productNumber}", ProductType.Speaker, 200, 500,
            "https://example.com/images/bluetooth-speaker.jpg");
        var jsonString = JsonSerializer.Serialize(newProduct);
        var jsonStringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/AddProduct", jsonStringContent);

        // Assert
        //client.Get
       response.EnsureSuccessStatusCode();
       //post return id
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

}