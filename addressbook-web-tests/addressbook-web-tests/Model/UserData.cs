using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class UserData : IEquatable<UserData>, IComparable<UserData>
   {
        private string firstname;
        private string lastname;
        

        public UserData(string lastname, string firstname)
        {
            this.lastname = lastname;
            this.firstname = firstname;
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

        public bool Equals(UserData other)//метод сравнения списка контактов
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(firstname, other.firstname) && string.Equals(lastname, other.lastname);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       public override string ToString()
          {
            return "name=" + firstname;
          }


       public int CompareTo(UserData other)
       {

           if (other == null) return 1;
           if (ReferenceEquals(this, other)) return 0;

           var lastNameCompare = String.CompareOrdinal(this.lastname, other.lastname);
           

           if (lastNameCompare != 0)
           {
               return lastNameCompare;

           }
           var firstNameCompare = String.CompareOrdinal(this.firstname, other.firstname);
           return firstNameCompare;
            
        }
   }
}

