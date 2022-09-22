using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinema_plus
{
    public class BiletAlModel
    {
        public List<int> koltuklar { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string telno { get; set; }
        public string eposta { get; set; }
        public int filmId { get; set; }
        public int seansId { get; set; }
    }
}