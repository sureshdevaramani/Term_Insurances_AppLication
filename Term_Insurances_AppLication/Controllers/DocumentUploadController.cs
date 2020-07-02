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

            documents.AddDocuments(addressSelected, FileName1, addressSelected2, FileName2);
            return RedirectToRoute(new
            {
                controller = "DocumentUpload",
                action = "ThankYou"

            });
        }
        
    }
}