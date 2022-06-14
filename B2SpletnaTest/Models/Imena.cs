using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2SpletnaTest.Models
{
    public class Imena
    {
        public string ime { get; set; }

        public int starost { get; set; }

        public Imena(string ime, int starost)
        {
            this.ime = ime;
            this.starost = starost;
        }
    }
}