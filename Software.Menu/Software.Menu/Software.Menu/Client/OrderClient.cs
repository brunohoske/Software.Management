﻿using AutoMapper;
using Software.Menu.DTOs;
using Software.Menu.Models.ViewModels;
using Software.Menu.Models;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text;

namespace Software.Menu.Client
{
    public class OrderClient : BaseClient
    {
        private readonly IMapper _mapper;
        public OrderClient(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public OrderClient(string cnpj, IMapper mapper)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
            _mapper = mapper;

        }

        public async Task SubmitOrder(List<ItemCart> itens,int comanda, int idCompany)
        {
            try
            {
                decimal total = 0;
                List<ProductDTO> productsDTO = new List<ProductDTO>();

                foreach (var item in itens)
                {
                    if (item.Product.IsCombo)
                    {
                        foreach (var comboProduct in item.Product.ComboProducts)
                        {
                            for (int i = 0; i < item.Quantity; i++)
                            {
                                var productDto = _mapper.Map<ProductDTO>(comboProduct);
                                productDto.Note = item.GetNote();
                                productsDTO.Add(productDto);
                                // foreach (var acomp in item.Acompanhamentos)
                                // {
                                //     for(int index = 0; index < acomp.Quantity; index++)
                                //     {
                                //         var acompanhamentoDto = mapper.Map<ProductDTO>(acomp.Product);
                                //         acompanhamentoDto.Note = "";
                                //         productsDTO.Add(acompanhamentoDto);
                                //     }

                                // }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < item.Quantity; i++)
                        {
                            var productDto = _mapper.Map<ProductDTO>(item.Product);
                            productDto.Note = item.GetNote();
                            productsDTO.Add(productDto);
                            // foreach (var acomp in item.Acompanhamentos)
                            // {
                            //     for(int index = 0; index < acomp.Quantity; index++)
                            //     {
                            //         var acompanhamentoDto = mapper.Map<ProductDTO>(acomp.Product);
                            //         acompanhamentoDto.Note = "";
                            //         productsDTO.Add(acompanhamentoDto);
                            //     }

                            // }
                        }
                    }


                    total += item.GetPrice();
                }

                Order order = new Order()
                {
                    Id = await GetOrderNumber(),
                    Date = System.DateTime.Now,
                    Store = new Company() { Id = idCompany },
                    Table = new Table() { TableNumber = comanda, Store = new Company() { Id = idCompany } },
                    Value = total

                };

                OrderDTO orderDTO = new OrderDTO()
                {
                    Id = order.Id,
                    Products = productsDTO,
                    Date = order.Date,
                    Store = order.Store,
                    Table = order.Table,
                    Value = order.Value
                };

                string jsonBody = System.Text.Json.JsonSerializer.Serialize(orderDTO);
                HttpContent httpContent = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("Orders", httpContent);




            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar pedido" + ex.Message);
            }
        }

        async Task<List<Product>> GetProducts()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Products").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Product> p = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(content, options);



            return p;
        }

        async Task<int> GetOrderNumber()
        {
            HttpResponseMessage response = _httpClient.GetAsync("OrderNumber").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            int number = JsonSerializer.Deserialize<int>(content, options);



            return number;
        }

        public async Task<List<Order>> GetOrders_(int comanda)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"GetOrdersInTable/{comanda}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Order> o = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(content, options);



            return o;
        }

        public async Task<List<OrderDisplayModel>> GetOrders(int companyId)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(new OrderIdsModel() { OrderIds = new List<int>() { 1 } }), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync($"https://localhost:7265/api/menu/orders/list/{companyId}",content).Result;
            
            if(!response.IsSuccessStatusCode )
            {
                return new List<OrderDisplayModel>();
            }

            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<OrderDisplayModel> orders = JsonSerializer.Deserialize<List<OrderDisplayModel>>(result, options);



            return orders;
        }

        public async Task SendOrder()
        {

        }
    }
}
