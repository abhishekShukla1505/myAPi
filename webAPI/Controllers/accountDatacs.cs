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
    public class accountDatacs : ControllerBase
    {
        private readonly IConfiguration _configration;
        public accountDatacs(IConfiguration configration)
        {
            _configration = configration;
        }
        [HttpPost]
        public JsonResult Post(accountclass data)
        {




            string query = $"insert into ACCOUNT(userid,title,bs,da,hra,lta,ma,bpa,tdse,hrae,ste,te,ele,pfe,fde,STD,GS,EXEMPTION,TAXABLE,SLAB,TAX)" +
                $" values( @userid,@TITLE ,@BS ,@DS, @HRA, @LTA, @MA, @BPA,@TDSE,@HRAE,@STE,@TE,@ELE,@PFE,@FDE, @STD, @GS, @EXEMPTION, @TAXABLE, @SLAB, @TAX)";
            DataTable table = new DataTable();
            string sqlDataSource = _configration.GetConnectionString("myConnection");
            MySqlDataReader myReader1;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {

                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {

                    mycommand.Parameters.AddWithValue("@userid", data.userid);
                    mycommand.Parameters.AddWithValue("@TITLE", data.TITLE);
                    mycommand.Parameters.AddWithValue("@BS", data.BS);
                    mycommand.Parameters.AddWithValue("@DS", data.DS);
                    mycommand.Parameters.AddWithValue("@HRA", data.HRA);
                    mycommand.Parameters.AddWithValue("@LTA", data.LTA);
                    mycommand.Parameters.AddWithValue("@MA", data.MA);
                    mycommand.Parameters.AddWithValue("@BPA", data.BPA);
                    mycommand.Parameters.AddWithValue("@TDSE", data.TDSE);
                    mycommand.Parameters.AddWithValue("@HRAE", data.HRAE);
                    mycommand.Parameters.AddWithValue("@STE", data.STE);
                    mycommand.Parameters.AddWithValue("@TE", data.TE);
                    mycommand.Parameters.AddWithValue("@ELE", data.ELE);
                    mycommand.Parameters.AddWithValue("@PFE", data.PFE);
                    mycommand.Parameters.AddWithValue("@FDE", data.FDE);
                    mycommand.Parameters.AddWithValue("@STD", data.STD);
                    mycommand.Parameters.AddWithValue("@GS", data.GS);
                    mycommand.Parameters.AddWithValue("@EXEMPTION", data.EXEMPTION);
                    mycommand.Parameters.AddWithValue("@TAXABLE", data.TAXABLE);
                    mycommand.Parameters.AddWithValue("@SLAB", data.SLAB);
                    mycommand.Parameters.AddWithValue("@TAX", data.TAX);






                    myReader1 = mycommand.ExecuteReader();

                    table.Load(myReader1);
                    myReader1.Close();
                    mycon.Close();

                }


            }


            return new JsonResult("done");
        }
    }
}
