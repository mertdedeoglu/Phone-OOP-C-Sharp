using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mert.Models
{
    class Kişi
    {
        public string İsim { get; set; }
        public string Soyisim { get; set; }
        public string Numara { get; set; }

        public Kişi()
        {
            this.İsim = "xxx";
            this.Soyisim = "xxx";
            this.Numara = "xxx";
        }
    }
}
