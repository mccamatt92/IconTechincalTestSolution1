using Newtonsoft.Json;
using RestSharp;
using Solution_1.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Solution_1.Steps;

[Binding]
public class ApiTestSteps
{
    private RestClient client;
    private RestResponse response;
    private ApiResponse apiResponse;

    private readonly string url = "https://reqres.in/api/users";

    [Given(@"I have the API endpoint")]
    public void GivenIHaveTheAPIEndpointForPage()
    {
        client = new RestClient($"{url}");
    }

    [When(@"I send a request for page (.*)")]
    public void WhenISendAGETRequest(string page)
    {
        var request = new RestRequest($"?page={page}", Method.Get);
        response = client.Execute(request);
        apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
    }

    [Then(@"the response should contain (.*) users")]
    public void ThenTheResponseShouldContainUsers(int userCount)
    {
        Assert.Equal(userCount, apiResponse.Data.Count);
    }

    [Then(@"The response is successful")]
    public void ThenTheResponseIsSuccessful()
    {
        Assert.Equal(200, (int)response.StatusCode);
    }

    [Then("the page matches with (.*)")]
    public void ThenThePageMatchesWith(int page)
    {
        Assert.Equal(page, apiResponse.Page);
    }

    [Then(@"the user details should be:")]
    public void ThenTheUserDetailsShouldBe(Table table)
    {
        var userData = table.CreateInstance<UserModel>();

        var user = apiResponse.Data
            .FirstOrDefault(c => c.First_Name == userData.FirstName &&
                                 c.Last_Name == userData.LastName &&
                                 c.Email == userData.Email &&
                                 c.Avatar == userData.Avatar);


        Assert.Equal(userData.FirstName, user.First_Name);
        Assert.Equal(userData.LastName, user.Last_Name);
        Assert.Equal(userData.Email, user.Email);
        Assert.Equal(userData.Avatar, user.Avatar);
    }

    [Then(@"no users should be returned")]
    public void ThenNoUsersShouldBeReturned()
    {
        Assert.Empty(apiResponse.Data);
    }

}
