using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VehicleCollection.Models
{
    public class VehicleDatabase
    {
        private readonly string _apiEndpoint;
        private readonly HttpClient _httpClient;

        private async Task RunAsync()
        {
            _httpClient.BaseAddress = new Uri(_apiEndpoint);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }
        public async Task<ObservableCollection<Vehicle>> GetVehicles()
        {
            string vehiclesJSON = null;
            HttpResponseMessage response = await _httpClient.GetAsync(_apiEndpoint);
            if (response.IsSuccessStatusCode)
            {
                vehiclesJSON = await response.Content.ReadAsStringAsync();
            }
            return JsonSerializer.Deserialize<ObservableCollection<Vehicle>>(vehiclesJSON);
        }
        public async Task<ObservableCollection<Vehicle>> UpdateVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            await DeleteVehicle(oldVehicle);
            return await CreateVehicle(newVehicle);
        }

        public async Task<ObservableCollection<Vehicle>> DeleteVehicle(Vehicle v)
        {
            string vehiclesJSON = null;
            HttpResponseMessage response = await _httpClient.PutAsync($"{_apiEndpoint}/delete", new StringContent(JsonSerializer.Serialize<Vehicle>(v), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                vehiclesJSON = await response.Content.ReadAsStringAsync();
            }
            return JsonSerializer.Deserialize<ObservableCollection<Vehicle>>(vehiclesJSON);
        }

        public async Task<ObservableCollection<Vehicle>> CreateVehicle(Vehicle v)
        {
            // create or update if VIN already exists
            string vehiclesJSON = null;
            HttpResponseMessage response = await _httpClient.PutAsync($"{_apiEndpoint}/create", new StringContent(JsonSerializer.Serialize<Vehicle>(v), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                vehiclesJSON = await response.Content.ReadAsStringAsync();
            }
            return JsonSerializer.Deserialize<ObservableCollection<Vehicle>>(vehiclesJSON);
        }

        public VehicleDatabase(string apiEndpoint)
        {
            _httpClient = new HttpClient();
            _apiEndpoint = apiEndpoint;
            RunAsync();
        }
    }
}
