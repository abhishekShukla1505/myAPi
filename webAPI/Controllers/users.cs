using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace webAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class users : ControllerBase
    {

        private readonly IConfiguration _configration;
        public users(IConfiguration configration)
        {
            _configration = configration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id, name, email from user";
            DataTable table = new DataTable();
            string sqlDataSource = _configration.GetConnectionString("myConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {

                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon)) {
                    myReader = mycommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }


            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(userRegister userregister) {
            try {
                

                DataTable table = new DataTable();
                DataTable table1 = new DataTable();
                string query = $"insert into user(name, email, password) values (@userName, @userEmail, @userPassword)";
                string query2 = @"SELECT id FROM user ORDER BY id DESC LIMIT 1";
                string sqlDataSource = _configration.GetConnectionString("myConnection");
                MySqlDataReader myReader;
                MySqlDataReader myReader1;
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {

                    mycon.Open();
                    using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                    {
                        mycommand.Parameters.AddWithValue("@userName", userregister.userName);
                        mycommand.Parameters.AddWithValue("@userEmail", userregister.userEmail);
                        mycommand.Parameters.AddWithValue("@userPassword", userregister.userPassword);
                        myReader = mycommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }

                    mycon.Open();
                    using (MySqlCommand mycommand = new MySqlCommand(query2, mycon))
                    {
                           
                        myReader1 = mycommand.ExecuteReader();
                        table1.Load(myReader1);                        
                        myReader1.Close();
                        mycon.Close();
                    }


                }
                return new JsonResult(table1); ;
            }
            catch (Exception e) {
                return  new JsonResult("unsuccessful"+e.ToString());
            }
        }
    }
}
