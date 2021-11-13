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
  }
}
