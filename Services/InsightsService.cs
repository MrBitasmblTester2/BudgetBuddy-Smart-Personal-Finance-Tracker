// Services/InsightsService.cs
using System.Net.Http;
using System.Net.Http.Json;
public class InsightsService {
  private readonly HttpClient _client;
  public InsightsService(HttpClient client){_client=client;}
  public async Task<string> GetInsights(object data){
    var res=await _client.PostAsJsonAsync("http://localhost:8000/insights", data);
    return await res.Content.ReadAsStringAsync();
  }
}