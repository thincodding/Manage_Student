using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Student.Model
{
    internal class StudentModel:Connect
    {
        public int studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string sex { get;set; }
        public string dob { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime date_of_join { get; set; } 
        public string status { get; set; }
        public byte[] photo { get; set; }
    }
}
