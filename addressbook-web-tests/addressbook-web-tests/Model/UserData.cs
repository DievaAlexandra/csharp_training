using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class UserData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        

        public UserData(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }

            set
            {
                middlename = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

    }
}

