using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Student.Model
{
    internal class ClassRoomModel:Connect
    {
        public int classroom_id { get; set; }
        public int grade_id { get; set; }
        public int teacher_id { get; set; }
        public string sestion { get; set; }
        public string remark { get; set; }
    }
}
