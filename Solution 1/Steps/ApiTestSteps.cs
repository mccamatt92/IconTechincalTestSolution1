using RestSharp;
using TechTalk.SpecFlow;

namespace Solution_1.Steps;

[Binding]
public class ApiTestSteps
{
    private RestClient client;
    private RestResponse response;
    //private ApiResponse apiResponse;

    [Given(@"I have the API endpoint for page ""(.*)""")]
    public void GivenIHaveTheAPIEndpointForPage(string page)
    {
        client = new RestClient($"https://reqres.in/api/users?page={page}");
    }
}
