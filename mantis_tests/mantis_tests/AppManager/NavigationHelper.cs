using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public NavigationHelper(ApplicationManager manager, string baseURL) : this(manager)
        {
            this.baseURL = baseURL;
        }
    }
}
