using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Student.Model
{
    internal class GradeModel:Connect
    {
        public int Grade_id { get; set; }
        public string grade_name { get; set; }
        public string descrition { get; set; }
    }
}
