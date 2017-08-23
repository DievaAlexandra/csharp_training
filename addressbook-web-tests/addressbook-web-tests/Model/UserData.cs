using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class UserData : IEquatable<UserData>, IComparable<UserData>
   {
       public UserData(string lastname, string firstname)
        {
            LastName = lastname;
            Firstname = firstname;
        }

      public string Firstname { get; set; }

       public string LastName { get; set; }

       public bool Equals(UserData other)//метод сравнения списка контактов
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Firstname, other.Firstname) && string.Equals(LastName, other.LastName);
        }

        public override int GetHashCode()
        {
           return Tuple.Create(Firstname, LastName).GetHashCode();
        }

       public override string ToString()
          {
            return "name=" +  LastName +  Firstname;
          }


       public int CompareTo(UserData other)
       {

           if (other == null) return 1;
           if (ReferenceEquals(this, other)) return 0;

           var lastNameCompare = String.CompareOrdinal(this.LastName, other.LastName);
           

           if (lastNameCompare != 0)
           {
               return lastNameCompare;

           }
           var firstNameCompare = String.CompareOrdinal(this.Firstname, other.Firstname);
           return firstNameCompare;
            
        }
   }
}

