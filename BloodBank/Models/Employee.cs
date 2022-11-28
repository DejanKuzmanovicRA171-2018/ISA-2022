using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //Administrator centra i medicinsko osoblje
    public class Employee
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
