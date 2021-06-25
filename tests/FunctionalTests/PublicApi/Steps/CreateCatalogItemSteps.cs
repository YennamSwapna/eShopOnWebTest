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
        
        private int _testBrandId = 1;
        private int _testTypeId = 2;
        private string _testDescription = "test description";
        private string _testName = "test name";
        private string _testUri = "test uri";
        private decimal _testPrice = 1.23m;

        public CreateCatalogItemSteps(ApiTestFixture factory)
        {
            Client = factory.CreateClient();            
        }

        public HttpClient Client { get; }        
        
        [When(@"I send Create Catalog Item Request")]
        public async void WhenISendCreateCatalogItemRequest()
        {
            var jsonContent = GetValidNewItemJson();
            var adminToken = ApiTokenHelper.GetAdminUserToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var response = await Client.PostAsync("api/catalog-items", jsonContent);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse>();
            Assert.Equal(model.CatalogItem.CatalogBrandId, _testBrandId);
            Assert.Equal(model.CatalogItem.CatalogTypeId, _testTypeId);
            Assert.Equal(model.CatalogItem.Description, _testDescription);
            Assert.Equal(model.CatalogItem.Name, _testName);
            Assert.Equal(model.CatalogItem.PictureUri, _testUri);
            Assert.Equal(model.CatalogItem.Price, _testPrice);
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

        private StringContent GetValidNewItemJson()
        {
            var request = new eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemRequest()
            {
                CatalogBrandId = _testBrandId,
                CatalogTypeId = _testTypeId,
                Description = _testDescription,
                Name = _testName,
                PictureUri = _testUri,
                Price = _testPrice
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }
    }
}
