using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string _name;
        private string _header = "";
        private string _footer = "";

        public GroupData(string name)
        {
            this._name = name;
        }
     
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }                
        }

        public string Header
        {
            get
            {
                return _header;
            }

            set
            {
                _header = value;
            }
        }

        public string Footer
        {
            get
            {
                return _footer;
            }

            set
            {
                _footer = value;
            }
        }
    }
}
