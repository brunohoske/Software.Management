﻿using Software.Menu.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class MenuClient : BaseClient
    {
        public MenuClient(string cnpj) 
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }

        public async Task<bool> CloseCheck(Table table)
        {
            string jsonbody = JsonSerializer.Serialize(table);
            HttpContent content = new StringContent(jsonbody,System.Text.Encoding.UTF8,"application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("CloseCheck",content);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Order>> GetOrders()
        {
            HttpResponseMessage response = _httpClient.GetAsync("GetOrdersInTable").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Order> o = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(content, options);



            return o;
        }

        public async Task<Coupon> SearchCoupon(string code)
        {
            
            _httpClient.DefaultRequestHeaders.Add("code",code);
            HttpResponseMessage response = _httpClient.GetAsync("SearchCoupon").Result;
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Coupon coupon = JsonSerializer.Deserialize<Coupon>(content);
                _httpClient.DefaultRequestHeaders.Remove("code");

                return coupon;
            }
            _httpClient.DefaultRequestHeaders.Remove("code");

            return null ;
           

        }
    }
}
