using Mentor138.Entities.Comman;
using System.Collections.ObjectModel;
using System.Xml;

namespace Mentor138.Entities
{
    public class School:BaseEntity
    {      
        public string SchoolName { get; set;}
        public int Number { get; set; } 
        public Collection<Student> Students { get; set; } 
    }
}
