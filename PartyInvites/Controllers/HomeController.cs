using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Data.SqlClient;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            string rr = "";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "db-msk01.cloud.softrazborki.net,14143";
            builder.InitialCatalog = "gsi_aevauto_db";
            builder.IntegratedSecurity = false;
            builder.UserID = "gsi_aevauto_user";
            builder.Password = "wvscP$49xX";
            using (SqlConnection cnn = new SqlConnection(builder.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT Count(*) FROM DetailOstatok";
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    rr = sdr[0].ToString();
                }

            }
            return View("MyView" + rr);
        }
    }
}
