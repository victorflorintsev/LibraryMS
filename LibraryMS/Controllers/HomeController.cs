using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryMS.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace LibraryMS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Graph()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=den1.mssql4.gear.host;Database=cosc3380;Uid=cosc3380;Pwd=vfegaf$;";
            conn.Open();

            //Query
            string count_user0 = "select count(*) from LIBDB.USERS where User_Type=0";
            SqlCommand cmd = new SqlCommand(count_user0, conn);
            int User0 = Convert.ToInt32(cmd.ExecuteScalar().ToString()); //execute query and count the number of usertype 0

            string count_user1 = "select count(*) from LIBDB.USERS where User_Type=1";
            SqlCommand cmd1 = new SqlCommand(count_user1, conn);
            int User1 = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

            string count_user2 = "select count(*) from LIBDB.USERS where User_Type=2";
            SqlCommand cmd2 = new SqlCommand(count_user2, conn);
            int User2 = Convert.ToInt32(cmd2.ExecuteScalar().ToString());

            string count_user3 = "select count(*) from LIBDB.USERS where User_Type=3";
            SqlCommand cmd3 = new SqlCommand(count_user3, conn);
            int User3 = Convert.ToInt32(cmd3.ExecuteScalar().ToString());

            conn.Close();

            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(0, User0),
                new DataPoint(1, User1),
                new DataPoint(2, User2),
                new DataPoint(3, User3)
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
