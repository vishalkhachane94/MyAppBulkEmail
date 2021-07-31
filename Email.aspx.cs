using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace BulkEmailApp
{
    public partial class Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void king_Click(object sender, EventArgs e)
        {

            if (Request.Files["FileUpload1"].ContentLength <= 0)  
        { return; }  
  
        //Get the file extension  
        string fileExtension = Path.GetExtension(Request.Files["FileUpload1"].FileName);  
  
        //If file is not in excel format then return  
        if (fileExtension != ".xls" && fileExtension != ".xlsx")  
        { return; }  
  
        //Get the File name and create new path to save it on server  
        string fileLocation = Server.MapPath("\\") + Request.Files["FileUpload1"].FileName;  
  
        //if the File is exist on serevr then delete it  
        if (File.Exists(fileLocation))  
        {  
            File.Delete(fileLocation);  
        }  
        //save the file lon the server before loading  
        Request.Files["FileUpload1"].SaveAs(fileLocation);  
  
        //Create the QueryString for differnt version of fexcel file  
        string strConn = "";
            switch (fileExtension)
            {
                case ".xls": //Excel 1997-2003  
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation
    + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                    break;
                case ".xlsx": //Excel 2007-2010  
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation
    + ";Extended Properties=\"Excel 12.0 xml;HDR=Yes;IMEX=1\"";
                    break;
            }
            //OleDbConnection con=new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=C:\\email-list\\email.xls;extended properties =excel 12.0");
            //con.Open();
            //OleDbCommand cmd = new OleDbCommand("Select Email,Name,Mobile from [sheet1$]", con);
            //OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
            //Label2.Text = GridView1.Rows.Count.ToString();
            //con.Close();
            string query = "select * from [Sheet1$]";
            OleDbConnection objConn;
            OleDbDataAdapter oleDA;
            DataTable dt = new DataTable();
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            oleDA = new OleDbDataAdapter(query, objConn);
            oleDA.Fill(dt);
            objConn.Close();
            oleDA.Dispose();
            objConn.Dispose();

            //Bind the datatable to the Grid  
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label2.Text = GridView1.Rows.Count.ToString();

            //Delete the excel file from the server  
            File.Delete(fileLocation);
        }
        protected void Sendbtn_Click(object sender, EventArgs e)
        {
            FileStream file1 = new FileStream(@"C:\\Log File\\MailService.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(file1);
            sw1.BaseStream.Seek(0, SeekOrigin.End);
            sw1.WriteLine("*************************************************************" + System.Environment.NewLine + " E-Mail Subject :" +Txt_Subject.Text+" Time To Send Email : " + DateTime.Now);
            sw1.Flush();
            sw1.Close();

            foreach (GridViewRow grow in GridView1.Rows)
            {
                string Emails = grow.Cells[0].Text.Trim();

                //string file = Server.MapPath("~/Mail.html");
                //string mailbody = System.IO.File.ReadAllText(file);
                string mailbody = Txt_Bodycontent.Text;
                string to = Emails;
               // string from = "vishalkhachane94@gmail.com";
                string from = TextBox1.Text;


                MailMessage msg = new MailMessage(from, to);
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment("C:\\Users\\Vishal\\Desktop\\v\\sample.pdf");
                //msg.Attachments.Add(attachment);
                if (FileUpload2.HasFile)//Attaching document
                {
                    string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    msg.Attachments.Add(new Attachment(FileUpload2.PostedFile.InputStream, FileName));

                }
                //msg.Subject = "Testing Email";
                msg.Subject = Txt_Subject.Text;
                msg.Body = mailbody;
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                String Host = TextBox3.Text;
                int Port = Convert.ToInt32(TextBox4.Text);
                SmtpClient client = new SmtpClient(Host, Port);
               
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential(TextBox1.Text, TextBox2.Text);
                
                client.EnableSsl = true;
                
                client.Credentials = basicCredential;

                /* MailMessage msg = new MailMessage();

                 msg.From = new MailAddress("vishalkhachane94@gmail.com");
               // msg.To.Add("vishalkhachane228@gmail.com");
                 msg.Subject = "test";
                 msg.Body = "Test Content";
                 msg.Priority = MailPriority.High;

                 SmtpClient client = new SmtpClient();

                 //client.Credentials = new NetworkCredential("vishalkhachane94@gmail.com", "9822924653", "smtp.gmail.com");
                 //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                 System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("vishalkhachane94@gmail.com", "9822924653");
                 client.Host = "smtp.gmail.com";
                 client.Port = 587;
                 client.DeliveryMethod = SmtpDeliveryMethod.Network;
                 client.EnableSsl = true;
                 client.UseDefaultCredentials = true;
                 client.Credentials = basicCredential;

                 //client.Send(msg);*/
                try
                {
                    
                    client.Send(msg);
                    cnfrm.Text = "Email Sended Successfully";
                    Page.RegisterStartupScript("Key", "<script type='text/javascript'>window.onload = function(){alert('Email Sended Successfully');return false;}</script>");
                    ClientScript.RegisterStartupScript(this.GetType(),"popup", "<script language=javascript>window.open('/Email.aspx','PrintMe','height=650px,width=1024px,scrollbars=1');</script>");



                    // const string filename1 = "MailService.txt";
                    // StreamWriter tw = new StreamWriter(filename1);
                    FileStream fs = new FileStream(@"C:\\Log File\\MailService.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine("Fetched Students Email's at " + Emails + " at " + DateTime.Now);
                    sw.Flush();
                    sw.Close();

                    




                }
                catch (Exception ex)
                {
                    FileStream fs = new FileStream(@"C:\\BulkEmails\\WebApplication64\\WebApplication64\\MailService.error.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine("Exception in setEmails: " + Emails + " at " + DateTime.Now);
                    sw.Flush();
                    sw.Close();
                    Response.Write(ex.Message);
                }
                
            }
            //cnfrm.Text = "Email Sended Successfully";
            

            //Response.Redirect("Email.aspx");
            //Page.RegisterStartupScript("Key", "<script type='text/javascript'>window.open = function(){alert('Email Sended Successfully');return false;}</script>");

        }

    }
}