using System;
using System.Collections.Generic;
using System.Text;

namespace HertiageWalks.Core.Model
{
    public class StopLocation
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal string short_desc { get; set; }
        internal string full_desc { get; set; }
        internal string coord_x { get; set; }
        internal string coord_y { get; set; }
        internal string created_at { get; set; }
        internal string updated_at { get; set; }
        internal string img { get; set; }
        internal string audio { get; set; }
        internal string street_location { get; set; }
        internal Pivot pivot { get; set; }

    }
}
