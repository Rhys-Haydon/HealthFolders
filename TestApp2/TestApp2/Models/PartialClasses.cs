using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(UserMetadata))]
        public partial class User
        {

        }

        [MetadataType(typeof(LedgerMetadata))]
        public partial class Ledger
        {

        }
    }
}