using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UniversityApp.BL.DTOs
{
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public int Grade { get; set; } = 0;
        public CourseDTO Course { get; set; }
        public StudentDTO Student { get; set; }
    }
}
