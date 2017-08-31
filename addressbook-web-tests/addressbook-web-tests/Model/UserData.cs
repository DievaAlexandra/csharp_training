using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace WebAddressbookTests
{
   public class UserData : IEquatable<UserData>, IComparable<UserData>
   {
       private string allPhones;
       private string allEmails;
      

        public UserData(string lastname, string firstname)
        {
            LastName = lastname;
            Firstname = firstname;
            
        }

        //Свойства
       public string Firstname { get; set; }
        public string LastName { get; set; }
       public string Address { get; set; }
       public string HomePhone { get; set; }
       public string MobilePhone { get; set; }
       public string WorkPhone { get; set; }
       public string Email { get; set; }
       public string Email2 { get; set; }
       public string Email3 { get; set; }

       public string AllEmails
       {
           get
           {
               if (allEmails != null)
               {
                   return allEmails;
               }
               return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
           }
           set
           {
               allEmails = value;
            }
       }




       public string AllPhones
       {
           get
           {
               if (allPhones != null)
               {
                   return allPhones;
               }
               else
               {
                   return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
               }
           }
           set
           {
               allPhones = value;

           }
       }

        private string CleanUpPhone(string phone)
       {
           if (phone == null || phone == "")
           {
               return "";
           }
          return Regex.Replace(phone, "[ -()]", "") + "\r\n";
       }



       private string CleanUpEmails(string email)
       {
           if (email == null || email == "")
           {
               return "";
           }
           return email.Replace(" ", "") + "\r\n";
       }



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
            return "firstname= " + Firstname + " \nlastname= " + LastName;
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

