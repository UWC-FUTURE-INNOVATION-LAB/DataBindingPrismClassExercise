using System.Collections.Generic;
using System.Threading.Tasks;
using DataBinding.Models;
using SQLite;
using DataBindingPrism.Services.Interfaces;
using System.IO;
using System;

namespace DataBinding.Data
{
    public class ProductsDatabase : IDatabase
    {
        private SQLiteAsyncConnection database;

        public ProductsDatabase()
        {
            string dbPath = GetDbPath();

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product>().Wait();

            SeedData();
        }

        private string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.db3");
        }

        public Task<List<Product>> GetProducts()
        {
            return database.Table<Product>().ToListAsync();
        }

        public async Task<Product> GetLatestProduct()
        {
            int count = await database.Table<Product>().CountAsync();
            var latest = await database.Table<Product>().Where(x => x.Id == count).FirstOrDefaultAsync();

            return latest;
        }

       public Task<int> DeleteProduct(Product product)
       {
            return database.DeleteAsync(product);
       }

        public async Task<int> UpdateProduct(Product product)
        {

            return await database.UpdateAsync(product);
         
        }

        public async  Task<List<Product>> GetSortedData()
        {
            return await database.Table<Product>().OrderByDescending(o => o.Price).ToListAsync();
        }

        private async void SeedData()
        {
            if (await database.Table<Product>().CountAsync() == 0)
            {
                var product = new Product
                {
                    Name = "Xamarin",
                    Price = 500,
                    Category = "Software",
                    ImgSrc = "xamarin.jpg"
                };

                await database.InsertAsync(product);

                 product = new Product
                {
                    Name = "Banana",
                    Price = 10,
                    Category = "Fruit",
                    ImgSrc ="banana.jpg"
                };

                await database.InsertAsync(product);

                product = new Product
                {
                    Name = "Pumpkin",
                    Price = 40,
                    Category = "Vegetable",
                    ImgSrc = "pumpkin.jpg"
                };

                await database.InsertAsync(product);

                product = new Product
                {
                    Name = "TV",
                    Price = 5999,
                    Category = "Electronics",
                    ImgSrc = "tv.jpg"
                };

                await database.InsertAsync(product);

            }


        }
    }
}

