using MrinalCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrinalCore.Entities;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using MrinalCore.Helpers;

namespace MrinalCore.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ConnectionStrings _connectionString;

        public ProductRepository(IOptions<ConnectionStrings> options)
        {
            _connectionString = options.Value;
        }
        public List<Product> getProductList()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string ConnectionPath = _connectionString.DefaultConnection;
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    using (SqlCommand cmd = new SqlCommand("stp_getProducts", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();
                                product.Id = DataHelper.ConvertTo<int>(reader["Id"]);
                                product.Name = DataHelper.ConvertTo<string>(reader["Name"]);
                                product.Description = DataHelper.ConvertTo<string>(reader["Description"]);
                                product.Price = DataHelper.ConvertTo<double>(reader["Price"]);
                                product.Category = DataHelper.ConvertTo<string>(reader["Category"]);
                                productList.Add(product);
                            }
                        }

                        reader.Close();

                    }

                }



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return productList;
        }
    }
}
