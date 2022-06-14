using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B2SpletnaTest.Models
{
    public class Seznam
    {
        [Key]
        public int st { get; set; }
        public IList<Imena> seznam { get; set; }
    }
}