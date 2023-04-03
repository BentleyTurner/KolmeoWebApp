using KolmeoWebApp.Controllers;
using KolmeoWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KolmeoWebAppTests
{
    public class ProductControllerTest
    {
        private readonly ProductController _controller;
        private readonly HttpClient _httpClient;
        private const string _jsonMediaType = "application/json";
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
        private static DbContextOptions<ProductContext> dbContextOptions;

        ProductContext context;

        public ProductControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            context = new ProductContext(dbContextOptions);
            context.Database.EnsureCreated();
            
            _controller = new ProductController(context);
            FillDbWithTestData();
        }

        private void FillDbWithTestData() {
            context.Products.Add(new Product { Id = 1, Name = "TestProd1Name", Description = "TestProd1Desc", Price = "TestProd1Price" });
            context.Products.Add(new Product { Id = 2, Name = "TestProd2Name", Description = "TestProd2Desc", Price = "TestProd2Price" });
            context.SaveChanges();
        }

        [Fact]
        public void ShouldReturnCorrectProducts()
        {
            List<ProductDTO> expectedReturn = new List<ProductDTO>
            {
                new ProductDTO{
                    Id = 1,
                    Name = "TestProd1Name",
                    Description = "TestProd1Desc",
                    Price = "TestProd1Price" 
                },

                new ProductDTO{
                    Id = 2,
                    Name = "TestProd2Name",
                    Description = "TestProd2Desc",
                    Price = "TestProd2Price" 
                },

            };

            // Act
            var result = _controller.GetProducts();


            Assert.Equivalent(expectedReturn, result.Result.Value);
        }

        [Fact]
        public void ShouldReturnCorrectProductById()
        {
            ProductDTO expectedReturn = new ProductDTO
            {
                Id = 2,
                Name = "TestProd2Name",
                Description = "TestProd2Desc",
                Price = "TestProd2Price"
            };

            // Act
            var result = _controller.GetProduct(2);

            Assert.Equivalent(expectedReturn, result.Result.Value);
        }

        [Fact]
        public void ShouldPostCorrectProduct()
        {
            List<ProductDTO> expectedReturn = new List<ProductDTO>
            {
                new ProductDTO{
                    Id = 1,
                    Name = "TestProd1Name",
                    Description = "TestProd1Desc",
                    Price = "TestProd1Price"
                },

                new ProductDTO{
                    Id = 2,
                    Name = "TestProd2Name",
                    Description = "TestProd2Desc",
                    Price = "TestProd2Price"
                },
                new ProductDTO{
                    Id = 3,
                    Name = "TestProd3Name",
                    Description = "TestProd3Desc",
                    Price = "TestProd3Price"
                },

            };

            ProductDTO newProduct = new ProductDTO
            {
                Id = 3,
                Name = "TestProd3Name",
                Description = "TestProd3Desc",
                Price = "TestProd3Price"
            };

            // Act
            var result = _controller.PostProduct(newProduct);


            Assert.Equivalent(expectedReturn, this.context.Products);
        }

        [Fact]
        public void ShouldPutCorrectProduct()
        {
            List<ProductDTO> expectedReturn = new List<ProductDTO>
            {
                new ProductDTO{
                    Id = 1,
                    Name = "TestProd1Name",
                    Description = "TestProd1Desc",
                    Price = "TestProd1Price"
                },

                new ProductDTO{
                    Id = 2,
                    Name = "TestProd2NameNew",
                    Description = "TestProd2DescNew",
                    Price = "TestProd2PriceNew"
                },

            };

            ProductDTO changedProduct = new ProductDTO
            {
                Id = 2,
                Name = "TestProd2NameNew",
                Description = "TestProd2DescNew",
                Price = "TestProd2PriceNew"
            };

            // Act
            var result = _controller.PutProduct(2, changedProduct);


            Assert.Equivalent(expectedReturn, this.context.Products);
        }

        [Fact]
        public void ShouldDeleteCorrectProduct()
        {
            List<ProductDTO> expectedReturn = new List<ProductDTO>
            {
                new ProductDTO{
                    Id = 1,
                    Name = "TestProd1Name",
                    Description = "TestProd1Desc",
                    Price = "TestProd1Price"
                },

            };

            

            // Act
            var result = _controller.DeleteProduct(2);


            Assert.Equivalent(expectedReturn, this.context.Products);
        }


        private static void AssertExpectedResponse(HttpResponseMessage givenResponse, System.Net.HttpStatusCode expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, givenResponse.StatusCode);
        }

    }
}
