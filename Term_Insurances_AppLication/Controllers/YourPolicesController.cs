using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Term_Insurances_AppLication.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Services;

namespace Term_Insurances_AppLication.Controllers
{
    public class YourPolicesController : Controller
    {
        // GET: YourPolices
        public ActionResult Index()
        {/*
            int employeeID = Convert.ToInt32(Session["employeeID"]);
            Incident incident = new Incident();
            DataSet ds = onSubmittingIncident.GetIncidents(employeeID);
            List<Incident> incidentlists = new List<Incident>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Incident incidentlist = new Incident();
                incidentlist.Incident_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["incident_id"]);
                incidentlist.Title = Convert.ToString(ds.Tables[0].Rows[i]["incident_title"]);
                incidentlist.Description = Convert.ToString(ds.Tables[0].Rows[i]["incident_description"]);
                incidentlist.raised_by = Convert.ToString(ds.Tables[0].Rows[i]["raised_by"]);
                incidentlist.status = Convert.ToString(ds.Tables[0].Rows[i]["stage"]);
                incidentlist.SupportedBy = Convert.ToString(ds.Tables[0].Rows[i]["handler_name"]);
                if (!Convert.IsDBNull(ds.Tables[0].Rows[i]["created_on"]))
                    incidentlist.created_on = Convert.ToDateTime(ds.Tables[0].Rows[i]["created_on"]);
                if (!Convert.IsDBNull(ds.Tables[0].Rows[i]["altered_on"]))
                    incidentlist.altered_on = Convert.ToDateTime(ds.Tables[0].Rows[i]["altered_on"]);
                incidentlist.Employee.Name = Convert.ToString(ds.Tables[0].Rows[i]["employee_name"]);
                incidentlists.Add(incidentlist);
            }
            incident.incidentarray = incidentlists;
            return View("DisplayIncidents", incident);
            */

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formdata)
        {
           

            string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);

            int customerid = Convert.ToInt32(formdata["Customer_ID"]);
            long phone = Convert.ToInt64(formdata["Phone"]);

            string sqlquery = "select customer_id from CUSTOMER where phone_number=" + phone +  " and customer_id = " + customerid;

            SqlCommand command = new SqlCommand(sqlquery, con);
            try
            {
                con.Open();
                SqlDataReader sdr = command.ExecuteReader();

                sdr.Read();
                {
                    TempData["Customer_ID"] = Convert.ToInt32(sdr["customer_id"]);

                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Enter Vaild Customer ID or Phone number....!";
                return View();
                
            }



            if (Convert.ToInt32(TempData["Customer_ID"]) == 0)
            {
                 ViewBag.Message = "Enter Vaild Customer ID or Phone number";
                return View();
            }
            else
            {
                return RedirectToAction(
               "KnowYourPolices", "YourPolices"
               );
            }

            }
         

        public ActionResult KnowYourPolices()
        {
            string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);



            int customerid = Convert.ToInt32( TempData["Customer_ID"]);

            
            string sqlquery = "select policy_id,cover_amount,payout_option,policy_term,payment_term,plan_type,add_on from policy_details where customer_id = " + customerid;

            SqlCommand command = new SqlCommand(sqlquery, con);
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            DataSet ds1 = new DataSet();

            dataadapter.Fill(ds1);

            List<Policy> policylists = new List<Policy>();
            
            Policy policy = new Policy();

            if(ds1.Tables[0].Rows.Count> 0)
            { 
            for(int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                Policy policylist = new Policy();

                policylist.policy_id = Convert.ToInt32(ds1.Tables[0].Rows[i]["policy_id"]);
                policylist.cover_amount = Convert.ToInt32(ds1.Tables[0].Rows[i]["cover_amount"]);
                policylist.payout_option = ds1.Tables[0].Rows[i]["payout_option"].ToString();
                policylist.policy_term = Convert.ToInt32(ds1.Tables[0].Rows[i]["policy_term"]);
                policylist.payment_term = Convert.ToInt32(ds1.Tables[0].Rows[i]["payment_term"]);
                policylist.plan_type = ds1.Tables[0].Rows[i]["plan_type"].ToString();
                policylist.add_on = ds1.Tables[0].Rows[i]["add_on"].ToString();

                policylists.Add(policylist);


            }

            }
            else
            {
                return View("KnowYourPolices1");
            }
            policy.policylist = policylists;

            return View(policy);
        }

    }
}