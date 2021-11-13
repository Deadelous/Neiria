using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;


namespace Neiria.BlazorApp.Data.Services
{
  public class ClothService : IClothService
  {
    private readonly HttpClient _httpclient;

    private readonly string baseurl = "https://localhost:7004/";
    public ClothService(HttpClient httpClient)
    {
      _httpclient = httpClient;
    }

    public async Task<IEnumerable<Cloth>> GetAllClothes()
    {
      return await _httpclient.GetFromJsonAsync<Cloth[]>("api/Clothes");
    }

    public async Task<Cloth> GetSpecificCloth(Guid id)
    {
      return await _httpclient.GetFromJsonAsync<Cloth>($"api/Clothes/{id}");
    }

    public async Task<Cloth> CreateNewCloth(Cloth cloth)
    {
      var content = JsonConvert.SerializeObject(cloth);
      var response = await _httpclient.PostAsJsonAsync("api/Clothes", content);

      var apiResponse = JsonConvert.DeserializeObject<Cloth>(await response.Content.ReadAsStringAsync());

      return apiResponse;
    }

    public async Task DeleteCloth(Guid id)
    {
      using (var _httpClient = new HttpClient())
      {
        using (var response = await _httpClient.DeleteAsync(baseurl + $"api/Clothes/{id}"))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
        }
      }
    }
  }
}
