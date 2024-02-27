using Mentor138.Entities.Comman;

namespace Mentor138.Entities
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public int SchoolId{ get; set; }
        public School School { get; set; }
    }
 
}
