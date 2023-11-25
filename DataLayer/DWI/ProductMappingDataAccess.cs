using BusinessModels;
using BusinessModels.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataLayer.DWI
{
    public class ProductMappingDataAccess
    {
        public CollectionResult<ProductMapping> GetAllProductMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<ProductMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProductMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllProductMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.TotalCount = Convert.ToInt32(reader[0]);
                }
                reader.NextResult();

                while (reader.Read())
                {
                    var ProductMappingObj = new ProductMapping();
                    ProductMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ProductMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    ProductMappingObj.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                    ProductMappingObj.ProductType = reader["ProductType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductType"]);
                    ProductMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    ProductMappingObj.FormFactor = reader["FormFactor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FormFactor"]);
                    ProductMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    ProductMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    ProductMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    ProductMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    ProductMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    ProductMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);

                   
                    result.Data.Add(ProductMappingObj);
                    result.Message = "Selected Successfully";

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return result;
        }

        #region public CollectionResult<ProductMapping> GetAllProductMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        public CollectionResult<ProductMapping> GetAllProductMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            //var result = new Result<Part>
            //{
            //    Status = true,
            //    Message = default(string),
            //    Data = new Part()

            //};
            var result = new CollectionResult<ProductMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProductMapping>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingProductMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("PageSize", pageSize);
                cmd.Parameters.AddWithValue("Search", search);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.TotalCount = Convert.ToInt32(reader[0]);
                }
                reader.NextResult();

                while (reader.Read())
                {
                    var ProductMappingObj = new ProductMapping();
                    ProductMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ProductMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    ProductMappingObj.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                    ProductMappingObj.ProductType = reader["ProductType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductType"]);
                    ProductMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    ProductMappingObj.FormFactor = reader["FormFactor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FormFactor"]);
                    ProductMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    ProductMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    ProductMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    ProductMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    ProductMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    ProductMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);

                    result.Data.Add(ProductMappingObj);
                    result.Message = "Get List Successfully";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return result;
        }
        #endregion

        #region public Result<ProductMapping> GetByProductMappingId(int Id, string Connectionstring)
        public Result<ProductMapping> GetByProductMappingId(int Id, string Connectionstring)
        {
            var result = new Result<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new ProductMapping()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelProductMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ProductMappingObj = new ProductMapping();
                    ProductMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ProductMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    ProductMappingObj.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                    ProductMappingObj.ProductType = reader["ProductType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductType"]);
                    ProductMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    ProductMappingObj.FormFactor = reader["FormFactor"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FormFactor"]);
                    ProductMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    ProductMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    ProductMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    ProductMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    ProductMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    result.Data = ProductMappingObj;
                    result.Message = "Get record succesfully";

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return result;
        }
        #endregion

        #region public Result<int> AddorUpdateProductMapping(ProductMapping values, string Connectionstring)
        public Result<int> AddorUpdateProductMapping(ProductMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = default(int)
            };
            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_AddorUpdateProductMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("MT", values.MT.Trim());
                cmd.Parameters.AddWithValue("Product", values.Product);
                cmd.Parameters.AddWithValue("ProductType", values.ProductType);
                cmd.Parameters.AddWithValue("Series", values.Series);
                cmd.Parameters.AddWithValue("FormFactor", values.FormFactor);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", values.Mode);

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();
            return result;
        }
        #endregion

        #region public Result<int> DeleteProductMapping(ProductMapping values, string Connectionstring)
        public Result<int> DeleteProductMapping(ProductMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = default(int)
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelProductMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteProductMapping");

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();
            return result;
        }
        #endregion
    }
}
