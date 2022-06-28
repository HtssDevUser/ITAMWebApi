using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class assets
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public int status  { get; set; }        
    }
}