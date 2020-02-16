using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truextend.StudentManagement.Core.Entities
{
    public class clsStudentBE
    {
        public int Id { get; set; }
        public string StudentType { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
