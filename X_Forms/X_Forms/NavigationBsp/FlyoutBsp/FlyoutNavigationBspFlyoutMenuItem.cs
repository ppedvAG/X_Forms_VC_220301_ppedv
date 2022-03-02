using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Forms.NavigationBsp.FlyoutBsp
{
    public class FlyoutNavigationBspFlyoutMenuItem
    {
        public FlyoutNavigationBspFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutNavigationBspFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}