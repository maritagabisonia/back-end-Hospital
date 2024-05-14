using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usermangment.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? EmailOfDoctor { get; set; }
        public string? EmailOfUser { get; set; }
        public DateTime? DateAndTime { get; set; }

    }
}
