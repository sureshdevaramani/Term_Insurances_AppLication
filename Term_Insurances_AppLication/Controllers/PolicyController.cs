using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using Term_Insurances_AppLication.Models;
using System.Configuration;


namespace Term_Insurances_AppLication.Controllers
{
    public class PolicyController : Controller
    {
        public int customer_id;
        public AddPolicy policy = new DataAccessLayer.AddPolicy();

        [HttpGet]
        // GET: Policy
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Details(Policy cusObj)
        {
            policy.GetPolicyDetails();

            int Policy_id = policy.Policy_id;

            ViewBag.POLICY_Id = Policy_id;

                cusObj.cover_amount = policy.Cover_Amount;
                cusObj.payout_option = policy.Payout_option;
                cusObj.policy_term = policy.Policy_term;
                cusObj.payment_term = policy.Payment_term;
                cusObj.plan_type = policy.Plan_type;
                cusObj.add_on = policy.Add_on;
         

           return View(cusObj);
        }

        [HttpPost]
        public ActionResult Details()
        {
            return RedirectToRoute(new
            {
                controller = "Payment",
                action = "Index"

            });
        }

        [HttpPost]
        public ActionResult Index(Policy cusObj)
        {
             long Phone = (long)Convert.ToDouble(TempData["Phone_Number"]);

            customer_id = policy.GetCustomerPK(Phone);

          
            if (cusObj.add_on == "")
            {
                cusObj.add_on = "null";
            }

            string add_on = cusObj.add_on.ToString();


            policy.AddPolicyDetails(customer_id,
                cusObj.cover_amount,
                cusObj.payout_option,
                cusObj.policy_term,
                 cusObj.payment_term,
                cusObj.plan_type,
                add_on);


            return RedirectToRoute(new
            {
                controller = "Policy",
                action = "Details"

            });

        }
    }
}