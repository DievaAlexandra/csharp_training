using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class UserData
    {
        private string _firstname;
        private string _middlename;
        private string _lastname;
        

        public UserData(string firstname, string middlename, string lastname)
        {
            this._firstname = firstname;
            this._middlename = middlename;
            this._lastname = lastname;
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return _middlename;
            }

            set
            {
                _middlename = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastname;
            }

            set
            {
                _lastname = value;
            }
        }

    }
}

