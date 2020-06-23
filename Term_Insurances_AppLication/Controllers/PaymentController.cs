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





            return View();




        }


    }
}