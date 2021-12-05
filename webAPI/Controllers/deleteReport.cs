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
    public class deleteReport : ControllerBase
    {
        private readonly IConfiguration _configration;
        public deleteReport(IConfiguration configration)
        {
            _configration = configration;
        }

        [HttpPost]
        public JsonResult Post(accountIDAndUserID data)
        {




            string query = $"DELETE from ACCOUNT where id=@accountId and userid=@userId ";
            DataTable table = new DataTable();
            string sqlDataSource = _configration.GetConnectionString("myConnection");
            MySqlDataReader myReader1;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {

                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {

                    mycommand.Parameters.AddWithValue("@accountId", data.accountId);
                    mycommand.Parameters.AddWithValue("@userId", data.userId);

                    myReader1 = mycommand.ExecuteReader();

                    table.Load(myReader1);
                    myReader1.Close();
                    mycon.Close();

                }


            }


            return new JsonResult("delete");
        }
    }
}
