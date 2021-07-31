using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Net.Mail;
using System.Net;
namespace WebApplication64
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //public String setEmails()
        //{
        //    try
        //    {
        //        String queryDates = "";
        //        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=mytest;Integrated Security=True;";

        //        queryDates = "select * form_no, name, emailid, mobile from registration_details where form_no in (select form_no from payment_received_r3_0521 where centre_id like 'A__%' or centre_id like 'C09%' ) and form_no not in(select form_no from Withdraw_0521)";

        //        SqlConnection con = new SqlConnection(connectionString);
        //        SqlCommand cmdDates = new SqlCommand(queryDates, con);

        //        //To check if connection is open then close it
        //        if (con.State == ConnectionState.Open)
        //            con.Close();

        //        //And now open the connection
        //        con.Open();
        //        SqlDataReader sdrDates = cmdDates.ExecuteReader();
        //        //  qu.Enqueue(new Candidate("mahendras@cdac.in", "2012001", "Mahendra Shoor"));
        //        if (sdrDates.HasRows)
        //        {
        //            while (sdrDates.Read())
        //            {
        //               qu.Enqueue(new Candidate(sdrDates["emailid"].ToString(), sdrDates["form_no"].ToString(), sdrDates["name"].ToString()));
        //            }
        //        }

        //        FileStream fs = new FileStream(@"F:\\EmailService\\MailService\\MailService.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //        StreamWriter sw = new StreamWriter(fs);
        //        sw.BaseStream.Seek(0, SeekOrigin.End);
        //        sw.WriteLine("Fetched Students Email's at " + DateTime.Now);
        //        sw.Flush();
        //        sw.Close();

        //        return "Done";
        //    }
        //    catch (Exception ex)
        //    {

        //        FileStream fs = new FileStream(@"F:\\EmailService\\MailService\\MailService.error.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //        StreamWriter sw = new StreamWriter(fs);
        //        sw.BaseStream.Seek(0, SeekOrigin.End);
        //        sw.WriteLine("Exception in setEmails: " + ex.Message + " at " + DateTime.Now);
        //        sw.Flush();
        //        sw.Close();

        //        return ex.Message;
        //    }

        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}