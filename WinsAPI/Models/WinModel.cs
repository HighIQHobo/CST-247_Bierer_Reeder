using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinsAPI.Models
{
    public class WinModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Clicks { get; set; }
        public DateTime WinDate { get; set; }
    }
}