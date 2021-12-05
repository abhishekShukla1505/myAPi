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
    public class updateData : ControllerBase
    {
        private readonly IConfiguration _configration;
        public updateData(IConfiguration configration)
        {
            _configration = configration;
        }
        [HttpPost]
        public JsonResult Post(updateClass updateclass)
        {




            string query = $"UPDATE  ACCOUNT set title=@TITLE,bs=@BS ,da=@DS,hra=@,lta=@,ma=@MA,bpa=@BPA,tdse=@TDSE,hrae=@HRAE,ste=@STE,te=@TE,ele=@ELE,pfe=@PFE,fde=@FDE,STD=@STD,GS=@GS,EXEMPTION=@EXEMPTION,TAXABLE=@TAXABLE,SLAB=@SLAB,TAX=@TAX where id=@id and userid=@userid";
            DataTable table = new DataTable();
            string sqlDataSource = _configration.GetConnectionString("myConnection");
            MySqlDataReader myReader1;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {

                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {

                    
                    mycommand.Parameters.AddWithValue("@TITLE", updateclass.TITLE);
                    mycommand.Parameters.AddWithValue("@BS", updateclass.BS);
                    mycommand.Parameters.AddWithValue("@DS", updateclass.DS);
                    mycommand.Parameters.AddWithValue("@HRA", updateclass.HRA);
                    mycommand.Parameters.AddWithValue("@LTA", updateclass.LTA);
                    mycommand.Parameters.AddWithValue("@MA", updateclass.MA);
                    mycommand.Parameters.AddWithValue("@BPA", updateclass.BPA);
                    mycommand.Parameters.AddWithValue("@TDSE", updateclass.TDSE);
                    mycommand.Parameters.AddWithValue("@HRAE", updateclass.HRAE);
                    mycommand.Parameters.AddWithValue("@STE", updateclass.STE);
                    mycommand.Parameters.AddWithValue("@TE", updateclass.TE);
                    mycommand.Parameters.AddWithValue("@ELE", updateclass.ELE);
                    mycommand.Parameters.AddWithValue("@PFE", updateclass.PFE);
                    mycommand.Parameters.AddWithValue("@FDE", updateclass.FDE);
                    mycommand.Parameters.AddWithValue("@STD", updateclass.STD);
                    mycommand.Parameters.AddWithValue("@GS", updateclass.GS);
                    mycommand.Parameters.AddWithValue("@EXEMPTION", updateclass.EXEMPTION);
                    mycommand.Parameters.AddWithValue("@TAXABLE", updateclass.TAXABLE);
                    mycommand.Parameters.AddWithValue("@SLAB", updateclass.SLAB);
                    mycommand.Parameters.AddWithValue("@TAX", updateclass.TAX);
                    mycommand.Parameters.AddWithValue("@id", updateclass.id);
                    mycommand.Parameters.AddWithValue("@userid", updateclass.userid);






                    myReader1 = mycommand.ExecuteReader();

                    table.Load(myReader1);
                    myReader1.Close();
                    mycon.Close();

                }


            }


            return new JsonResult("updated");
        }
    }
}
