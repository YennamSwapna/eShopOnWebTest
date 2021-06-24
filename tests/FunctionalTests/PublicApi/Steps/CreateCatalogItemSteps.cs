using System;
using System.Net.Http;
using System.Text.Json;
using TechTalk.SpecFlow;
using Xunit;
using System.Text;
using Microsoft.eShopWeb.FunctionalTests.Web.Api;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace Microsoft.eShopWeb.FunctionalTests.PublicApi.Steps
{
    [Binding]
    public class CreateCatalogItemSteps : IClassFixture<ApiTestFixture>
    {
        JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public CreateCatalogItemSteps(ApiTestFixture factory)
        {
            Client = factory.CreateClient();            
        }

        public HttpClient Client { get; }


        [Given(@"I input CatalogBrandId (.*)")]
        public async Task GivenIInputCatalogBrandIdAsync(int CatalogBrandId)
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            model.CatalogItem.CatalogBrandId = CatalogBrandId;
        }
        
        [Given(@"I input CatalogTypeId (.*)")]
        public async Task GivenIInputCatalogTypeIdAsync(int CatalogTypeId)
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            model.CatalogItem.CatalogTypeId = CatalogTypeId;
        }
        
        [Given(@"I input Description ""(.*)""")]
        public async void GivenIInputDescription(string Description)
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            model.CatalogItem.Description = Description;
        }
        
        [Given(@"I input Name ""(.*)""")]
        public async void GivenIInputName(string Name)
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            model.CatalogItem.Name = Name;
        }
        
        [Given(@"I input PictureUri ""(.*)""")]
        public async void GivenIInputPictureUri(string PictureUri)
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            model.CatalogItem.PictureUri = PictureUri;
        }
        
        [Given(@"I input Price (.*)m")]
        public async Task GivenIInputPriceMAsync(Decimal Price)
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            model.CatalogItem.Price = Price;
        }
        
        [When(@"I send Create Catalog Item Request")]
        public async void WhenISendCreateCatalogItemRequest()
        {
            var jsonContent = GetValidNewItemJson();
            var token = ApiTokenHelper.GetNormalUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);            
        }
        
        [Then(@"Validate Catalog is created")]
        public async void ThenValidateCatalogIsCreated()
        {
            var jsonContent = GetValidNewItemJson();
            var token = ApiTokenHelper.GetNormalUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        private static StringContent GetValidNewItemJson()
        {
            var request = new eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemRequest()
            {
                CatalogBrandId = 1,
                CatalogTypeId = 2,
                Description = "Test",
                Name = "Testing",
                PictureUri = "test 123",
                Price = 1.23m
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }
    }
}
