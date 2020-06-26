using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Term_Insurances_AppLication.Models;
using System.IO;
using DataAccessLayer;

namespace Term_Insurances_AppLication.Controllers
{
    public class DocumentUploadController : Controller
    {
        public string FileName1,FileName2;
        // GET: Document
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public void FileUpload()
        {
            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string fileName = Path.GetFileName(Request.Files[i].FileName);
                    fileName = Path.Combine(Server.MapPath("~/File Upload/"), fileName);
                    file.SaveAs(fileName);
                }
            }

            
        }
        public ActionResult ThankYou()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Document dc,FormCollection formdata, HttpPostedFileBase File_Attachment1, HttpPostedFileBase File_Attachment2)
        {
            string addressSelected = formdata["AddressProof"].ToString();
            string addressSelected2 = formdata["AddressProof2"].ToString();
            Response.Write(addressSelected);
            Response.Write(addressSelected2);



            /* if (Request.Files.Count > 0)
             {*/
            if (File_Attachment1.ContentLength > 0)
            {
                var fileName = Path.GetFileName(File_Attachment1.FileName);
                var path = Path.Combine(Server.MapPath("~/File Upload/"), fileName);
                File_Attachment1.SaveAs(path);
                Response.Write(path);
                this.FileName1=path;
            }

            if (File_Attachment2.ContentLength > 0)
            {
                var fileName = Path.GetFileName(File_Attachment2.FileName);
                var path = Path.Combine(Server.MapPath("~/File Upload/"), fileName);
                File_Attachment2.SaveAs(path);
                Response.Write(path);
                this.FileName2 = path;


            }
            Response.Write(FileName1);
            Response.Write(FileName2);

            AddDocumentDetails documents = new AddDocumentDetails();

            documents.AddDocuments(addressSelected, FileName1, addressSelected2, FileName2);/*
            string con = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(con);

            sqlCon.Open();


            SqlCommand sqlCmd = new SqlCommand("select policy_id from POLICY_DETAILS where policy_id=(Select max (policy_id) From POLICY_DETAILS)", sqlCon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();

            sdr.Read();
            {

                ViewBag.POLICYID = Convert.ToInt32(sdr["policy_id"]);

            }


            sqlCon.Close();


            SqlCommand sqlCmd1 = new SqlCommand("INSERT into DOCUMENTS (policy_id,document_type,document_proof,document_type2,document_proof2) values (@policy_id,@document_type,@document_proof,@document_type2,@document_proof2)", sqlCon);
            sqlCon.Open();

            sqlCmd1.Parameters.AddWithValue("@policy_id", ViewBag.POLICYID);
            sqlCmd1.Parameters.AddWithValue("@document_type", formdata["Departments"].ToString());      
            sqlCmd1.Parameters.AddWithValue("@document_proof", FileName1);
            sqlCmd1.Parameters.AddWithValue("@document_type2", formdata["Dropdown2"].ToString());
            sqlCmd1.Parameters.AddWithValue("@document_proof2", FileName2);


            sqlCmd1.ExecuteNonQuery();
            */
            return RedirectToRoute(new
            {
                controller = "DocumentUpload",
                action = "ThankYou"

            });
        }
        
    }
}