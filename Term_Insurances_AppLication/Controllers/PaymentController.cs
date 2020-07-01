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
using BussinessLayer;

using Twilio.TwiML;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Term_Insurances_AppLication.Controllers
{
    public class PaymentController : Controller
    {
        public AddPayment Pa = new AddPayment();



        /*cover_amount, plantttype,addon,policyid*/
        [HttpGet]

        public ActionResult Index(Policy cusObj)
        {

            Pa.GetCobverAmount();

            int Cover_amount = Pa.Cover_Amount;
            string Plan_type = Pa.Plan_Type;

            string Add_on = Pa.Add_on;

            ViewBag.PLAN = Plan_type;

            double CoverAmount = Cover_amount;

            double LAnnualPremium = Math.Round(CoverAmount / 250.6002, 2);
            double LMonthlyPremiuim = Math.Round(LAnnualPremium / 12, 2);

            double ELAnnualPremium = Math.Round(CoverAmount / 220.6002, 2);
            double ELMonthlyPremiuim = Math.Round(LAnnualPremium / 12, 2);

            if (Add_on != "")
            {


                LAnnualPremium = LAnnualPremium + 336;
                LMonthlyPremiuim = LMonthlyPremiuim + 28;

                ELAnnualPremium = ELAnnualPremium + 336;
                ELMonthlyPremiuim = ELMonthlyPremiuim + 28;
            }



            ViewData["LifeOptionAnnualPremium"] = LAnnualPremium;
            ViewData["LifeOptionMonthlyPremium"] = LMonthlyPremiuim;
            ViewData["ExtraLifeOptionAnnualPremium"] = ELAnnualPremium;
            ViewData["ExtraLifeOptionMonthlyPremium"] = ELMonthlyPremiuim;




            return View();




        }
        [HttpPost]
        public ActionResult Index(PaymentBussinessLayer pa, Policy cusObj)
        {
            Pa.GetCobverAmount();

            int Cover_amount = Pa.Cover_Amount;
            string Plan_type = Pa.Plan_Type;

            string Add_on = Pa.Add_on;

            int Policy_id = Pa.policy_id;


            ViewBag.PLAN = Plan_type;

            double CoverAmount = Cover_amount;

            double LAnnualPremium = Math.Round(CoverAmount / 250.6002, 2);
            double LMonthlyPremiuim = Math.Round(LAnnualPremium / 12, 2);

            double ELAnnualPremium = Math.Round(CoverAmount / 220.6002, 2);
            double ELMonthlyPremiuim = Math.Round(LAnnualPremium / 12, 2);




            if (cusObj.add_on != "")
            {


                LAnnualPremium = LAnnualPremium + 336;
                LMonthlyPremiuim = LMonthlyPremiuim + 28;

                ELAnnualPremium = ELAnnualPremium + 336;
                ELMonthlyPremiuim = ELMonthlyPremiuim + 28;
            }



            ViewData["LifeOptionAnnualPremium"] = LAnnualPremium;
            ViewData["LifeOptionMonthlyPremium"] = LMonthlyPremiuim;
            ViewData["ExtraLifeOptionAnnualPremium"] = ELAnnualPremium;
            ViewData["ExtraLifeOptionMonthlyPremium"] = ELMonthlyPremiuim;

            Pa.AddPaymentDetails(Policy_id, pa.payment_mode, pa.policy_premium);
            long Phone = (long)Convert.ToDouble(TempData["Phone_Number"]);

            const string accountSid = "ACf589355e9dff8b19c8a1571903581f58";
            const string authToken = "72c758060fd3a9617de671154d11499c";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi" + TempData["First_Name"] + ", this message is to confirm that the premium payment amount of ₹" + pa.policy_premium + " for the Policy No. " + ViewBag.POLICYID + " has been completed successfully on " + DateTime.Now + ". Thank you!",
                from: new Twilio.Types.PhoneNumber("+12017013713"),
                to: new Twilio.Types.PhoneNumber("+91" + TempData["Phone_Number"])
            );

            Console.WriteLine(message.Sid);




            return RedirectToAction("Index","DocumentUpload");




        }


    }
}