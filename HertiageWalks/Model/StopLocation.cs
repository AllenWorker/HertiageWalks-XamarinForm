using System;
using System.Collections.Generic;
using System.Text;

namespace HertiageWalks.Model
{
    public class StopLocation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string short_desc { get; set; }
        public string full_desc { get; set; }
        public string coord_x { get; set; }
        public string coord_y { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string img { get; set; }
        public string audio { get; set; }
        public string street_location { get; set; }
        public Pivot pivot { get; set; }

    }
}
