using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class UserMetadata
    {

    }
    public class LedgerMetadata
    {
        [Required(ErrorMessage = "Date of Ledger Entry is Required")]
        [Display(Name = "Ledger Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date;

    }
}