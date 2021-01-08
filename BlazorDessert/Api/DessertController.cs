using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using BlazorDessert.Data;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorDessert.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DessertController : ControllerBase
    {
        private IConfiguration _config;
        public DessertController(IConfiguration config)
        {
            _config = config;
        }
        // GET: api/<DessertController>
        [HttpGet]
        public IEnumerable<Dessert> GetDesserts(int page = 0)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string sql = @"select * from Dessert order by DessertID offset 9 * @page rows fetch next 9 rows only ";
                return conn.Query<Dessert>(sql, new { page = page });
            }
        }
        [HttpGet]
        public int GetCount()
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string sql = @"select count(*) from dessert";
                return conn.QueryFirstOrDefault<int>(sql);
            }
        }
    }
}
