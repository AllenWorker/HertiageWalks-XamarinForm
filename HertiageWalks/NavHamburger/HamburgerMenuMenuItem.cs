using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HertiageWalks.NavHamburger
{

    public class HamburgerMenuMenuItem
    {
        public HamburgerMenuMenuItem()
        {
            TargetType = typeof(HamburgerMenuDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}