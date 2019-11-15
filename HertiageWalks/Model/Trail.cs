using System;
using System.Collections.Generic;
using System.Text;


namespace HertiageWalks.Model
{
    public class Trail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string time { get; set; }
        public string length { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string img { get; set; }
        public string audio { get; set; }

        public Trail()
        {

        }
        
    }
}
