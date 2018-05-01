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

        public IActionResult newCustomerCount(DateTime fromTime, DateTime toTime)
        {
            int x = 0;

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
                new DataPoint(0, User0, "Employee"),
                new DataPoint(1, User1, "Customer"),
                new DataPoint(2, User2, "Flagged Customer"),
                new DataPoint(3, User3, "Faculty")
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public IActionResult Update() //checks the borrow table if users are overdue
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=den1.mssql4.gear.host;Database=cosc3380;Uid=cosc3380;Pwd=vfegaf$;";
            conn.Open();

            string late_users = "SELECT USERS.UserName, User_Type FROM LIBDB.BORROW INNER JOIN LIBDB.USERS ON LIBDB.USERS.UserName = LIBDB.BORROW.UserName WHERE Due_Date<GETDATE() and Return_Date is NULL; ";
            SqlCommand comm1= new SqlCommand(late_users,conn);

            //reads the query of all the late users and put them into a list
            SqlDataReader reader = comm1.ExecuteReader();
            List<string> str = new List<string>();
            List<int> UT = new List<int>();
            while (reader.Read())
            {
                str.Add(reader.GetValue(0).ToString());
                UT.Add(Convert.ToInt32(reader.GetValue(1).ToString()));
            }
            reader.Close();
           for(int i =0; i<str.Count;i++)
            {
                string query1 = "select count(*) from LIBDB.FINE where UserName='"+str[i]+"'";
                SqlCommand comm2 = new SqlCommand(query1, conn);
                int user_exist = Convert.ToInt32(comm2.ExecuteScalar().ToString());
                if(user_exist<1)//we have to insert the user to fine table
                {
                    string insert_fine = "insert into LIBDB.FINE values('"+str[i]+"', 0, 1, GETDATE() + 20)";
                    SqlCommand insert_fine_user = new SqlCommand(insert_fine, conn);
                    insert_fine_user.ExecuteNonQuery();
                }
                else
                {
                    string update_fine = " UPDATE LIBDB.FINE set AMOUNT = 1 where UserName='"+str[i]+"'";
                    SqlCommand update_fine_user = new SqlCommand(update_fine, conn);
                    update_fine_user.ExecuteNonQuery();
                }
                //flag the customer
                string set_flag = "UPDATE LIBDB.USERS set USER_TYPE ="+UT[i] + "where UserName='" + str[i] + "'";
                SqlCommand update_users = new SqlCommand(set_flag, conn);
                update_users.ExecuteNonQuery();
            }

            conn.Close();
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
