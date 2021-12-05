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
    public class login : ControllerBase
    {
        private readonly  IConfiguration _configration;

        public login(IConfiguration configration)
        {
            _configration = configration;
        }
        [HttpPost]
        public JsonResult Post(loginclass login)
        {         


               
                
            string query = $"select id,name from user where email= @userEmail and password= @userPassword";
            DataTable table = new DataTable();
            string sqlDataSource = _configration.GetConnectionString("myConnection");
                 MySqlDataReader myReader1;
                
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {

                    mycon.Open();
                    using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                    {
                        
                        mycommand.Parameters.AddWithValue("@userEmail", login.userEmail);
                        mycommand.Parameters.AddWithValue("@userPassword", login.userPassword);
                        myReader1= mycommand.ExecuteReader();

                    table.Load(myReader1);
                    myReader1.Close();
                    mycon.Close();

                }                


                }


            return new JsonResult(table) ;
        }
    }
}
