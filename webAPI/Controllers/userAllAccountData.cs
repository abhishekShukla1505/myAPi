using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userAllAccountData : ControllerBase
    {
        private readonly IConfiguration _configration;
        public userAllAccountData(IConfiguration configration)
        {
            _configration = configration;
        }

        [HttpPost]
        public JsonResult Post(alldata userId)
        {




            string query = $"select * from ACCOUNT where  userid=@userId ";
            DataTable table = new DataTable();
            string sqlDataSource = _configration.GetConnectionString("myConnection");
            MySqlDataReader myReader1;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {

                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {

                    mycommand.Parameters.AddWithValue("@userId", userId.id);
                  

                    myReader1 = mycommand.ExecuteReader();

                    table.Load(myReader1);
                    myReader1.Close();
                    mycon.Close();

                }


            }


            return new JsonResult(table);
        }
    }
}
