using apiweb.models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiweb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExternalController: ControllerBase
{
    readonly HttpClient Client;
    readonly static string urlBase = "https://jsonmock.hackerrank.com/api/football_matches";
    public ExternalController()
    {
        Client = new HttpClient();
    }


    /// <summary>
    ///Consuming External REST API
    ///
    /// Hacker Ranck Challenge: Consume REST API that contains information about football matches.
    /// The provided api allows querying matches by teams and year. Thea challenge is return the total numbers
    /// of goals scored by a given team and given year
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]string year,string team)
    {
        int goals = 0;
        string holdurl = urlBase +"?year="+ year +"&team1="+ team;
        string responseBody = await Client.GetStringAsync(holdurl);
        HackerRankResponse response = JsonConvert.DeserializeObject<HackerRankResponse>(responseBody);
        
        for (int i = 0; i < response?.total_pages; i++)
        {
            holdurl = urlBase +"?year="+ year +"&team1="+ team + "&page="+ (i+1);
            string responseBodyTeam1 = await Client.GetStringAsync(holdurl);
            HackerRankResponse responseTeam1 = JsonConvert.DeserializeObject<HackerRankResponse>(responseBodyTeam1);
            foreach (var item in responseTeam1.data)
            {
                goals+= int.Parse(item.team1goals);
            }
        }

        holdurl = urlBase +"?year="+ year +"&team2="+ team;
        responseBody = await Client.GetStringAsync(holdurl);
        response = JsonConvert.DeserializeObject<HackerRankResponse>(responseBody);

        for (int i = 0; i < response?.total_pages; i++)
        {
            holdurl = urlBase +"?year="+ year +"&team2="+ team + "&page="+ (i+1);
            string responseBodyTeam2 = await Client.GetStringAsync(holdurl);
            HackerRankResponse responseTeam2 = JsonConvert.DeserializeObject<HackerRankResponse>(responseBodyTeam2);
            foreach (var item in responseTeam2.data)
            {
                goals+= int.Parse(item.team2goals);
            }
        }
        
        return new JsonResult(new{success=true, message="Total goals of "+team+" at the year "+year, data=new{goals}});
    }
}