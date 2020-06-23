using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Term_Insurances_AppLication.Models
{
    public class Customer
    {


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter your Name")]

        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter your Last Name")]
        public string last_name { get; set; }

        [Display(Name = "Select Gender")]
        [Required(ErrorMessage = "Please Select Gender")]




        public int gender_ { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Enter your DOB")]
        [DataType(DataType.Date)]

        public DateTime? date_of_birth { get; set; }

        [Display(Name = "Is NRI?")]

        public bool nri_flag { get; set; }

        [Display(Name = "Is Tobacco user?")]

        public bool tobbaco_user_flag { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter your Address")]

        public string Address_Line1 { get; set; }

        [Display(Name = "Street/Area")]
        [Required(ErrorMessage = "Enter your Area/Street name")]

        public string Address_Line2 { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Select your State")]
        public int State { get; set; }

        [Display(Name = "City/Town")]
        [Required(ErrorMessage = "Enter your City Name")]
        public string City { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress)]

        public string Email_Id { get; set; }

        [Display(Name = "Nominee Name")]
        [Required(ErrorMessage = "Please Enter your Nominee Name")]

        public string Nominee_name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required")]
        [RegularExpression((@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"), ErrorMessage = "Invalid Phone number")]
        public long Phone_Number { get; set; }

        /*
        [Display(Name = "First Name")]
        [Required]
        public string first_name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string last_name { get; set; }

        public int gender_code { get; set; }

        [Display(Name = "Select Gender")]
        [Required(ErrorMessage = "Required")]

        public int gender_ { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime ? date_of_birth { get; set; }

        [Display(Name = "Is NRI?")]

        public bool nri_flag { get; set; }

        [Display(Name = "Is Tobacco user?")]

        public bool tobbaco_user_flag { get; set; }

        [Display(Name = "Address Line 1")]

        public string Address_Line1 { get; set; }

        [Display(Name = "Address Line 2")]

        public string Address_Line2 { get; set; }

        [Required]
        public int State { get; set; }


        public string City { get; set; }

        [Display(Name = "Email ID")]

        public string Email_Id { get; set; }

        [Display(Name = "Nominee Name")]

        public string Nominee_name { get; set; }

        [Display(Name = "Phone Number")]
        public long Phone_Number { get; set; }
        */

    }
}