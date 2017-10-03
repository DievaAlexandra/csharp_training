using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        //свойства
        public string Name { get; set; }
        public string Id { get; set; }

        public ProjectData(string name)
        {
            Name = name;
        }

        
        public int CompareTo(ProjectData other)

        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        
        public bool Equals(ProjectData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        //метод вернет строковое представление объектов
        public override string ToString()
        {
            return "projectname= " + Name;
        }

      
    }
}
