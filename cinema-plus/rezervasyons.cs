//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cinema_plus
{
    using System;
    using System.Collections.Generic;
    
    public partial class rezervasyons
    {
        public int rez_id { get; set; }
        public Nullable<int> musteri_id { get; set; }
        public Nullable<int> film_id { get; set; }
        public Nullable<int> koltuk_no { get; set; }
        public Nullable<int> seans_id { get; set; }
    
        public virtual filmlers filmlers { get; set; }
    }
}
