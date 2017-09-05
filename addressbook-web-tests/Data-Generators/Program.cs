using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;


namespace addressbook_test_data_generators
{
    class Program
    {

        //генерация тестовых данных
        static void Main(string[] args) 
        {
            int count = Convert.ToInt32(args[0]); //кол-во генерируемых объектов
            StreamWriter writer = new StreamWriter(args[1]); //имя файла
            string format = args[2]; //формат в котором будет создан файл
            string datatype = args[3]; //тип данных group или contacts


            //Если datatype == groups то создаются группы, иначе - контакты

            List<GroupData> groups = new List<GroupData>();
            List<UserData> contacts = new List<UserData>();

            if (datatype == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
            }
            else if (datatype == "contacts")
            {
                
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new UserData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                }
            }

            else
            {
                System.Console.Out.Write("Unrecognized type of data " + datatype);
            }
            
            //Определние формата файла: XML или JSON
            if (format == "xml")
            {
                if (datatype == "groups")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                

            }
            else if (format == "json")
            {

                if (datatype == "groups")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }
          
            writer.Close();
        }


        //запись данных в файл для Групп
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        
        //запись данных в файл для Контактов 
        static void writeContactsToXmlFile(List<UserData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<UserData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
