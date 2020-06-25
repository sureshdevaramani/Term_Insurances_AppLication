using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Term_Insurances_AppLication.Models
{
    public class Document
    {
        public int policy_id { get; set; }
        [Display(Name = "Document Type")]
        public string document_type { get; set; }
        [Display(Name = "Upload File")]

        [DataType(DataType.Upload)]
        public string document_proof { get; set; }

        public string Attachment { get; set; }
    }
}