using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using MySql.Data.Types;


namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class UserData : IEquatable<UserData>, IComparable<UserData>
   {
       private string allPhones;
       private string allEmails;


       public UserData()
       {
       }

       public UserData(string lastname, string firstname)
        {
            LastName = lastname;
            Firstname = firstname;
            
        }

        //Свойства
       [Column(Name = "firstname")] 
       public string Firstname { get; set; }

       [Column(Name = "lastname")]
       public string LastName { get; set; }

       [Column(Name = "id"), PrimaryKey]
       public string Id { get; set; }

       public string Address { get; set; }
        
       public string HomePhone { get; set; }

       public string MobilePhone { get; set; }

       public string WorkPhone { get; set; }

       public string Email { get; set; }

       public string Email2 { get; set; }

       public string Email3 { get; set; }

       [Column(Name = "deprecated")]
        public string Deprecated { get; set; }


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

       public static List<UserData> GetAll()
       {
           using (AddressBookDB db = new AddressBookDB())
           {
              return (from c in db.Contacts.Where(x => x.Deprecated == "0000 - 00 - 00 00:00:00") select c).ToList();
           }
           
        }
    }
}

