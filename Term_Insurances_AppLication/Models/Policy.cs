using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Term_Insurances_AppLication.Models
{
    public class Policy
    {
        public int customer_id { get; set; }
        [Required(ErrorMessage = "Please enter Cover amount")]

        public int policy_id { get; set; }

        [Range(5000000, 10000000000, ErrorMessage = "Please Enter Cover Amount")]
        public int cover_amount { get; set; }
        [Required(ErrorMessage = "Please choose anyone of the plan")]
        public string payout_option { get; set; }
        [Required(ErrorMessage = "Please enter policy term")]

        [Range(5, 45, ErrorMessage = "Please Enter Cover Amount")]

        public int policy_term { get; set; }
        [Required(ErrorMessage = "Please enter payment term")]
        public int payment_term { get; set; }
        [Required(ErrorMessage = "Please choose anyone of the plan")]
        public string plan_type { get; set; }
        [Required(ErrorMessage = "Please choose anyone of the options")]
        public string add_on { get; set; }

        public string policy_start_date { get; set; }

        public string policy_end_date { get; set; }

        public bool policy_active_flag { get; set; }

        public string policy_applied { get; set; }

        public List<Policy> policylist { get; set; }

    }
}