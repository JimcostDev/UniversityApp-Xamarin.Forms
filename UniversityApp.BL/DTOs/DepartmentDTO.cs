using Newtonsoft.Json;
using System;

namespace UniversityApp.BL.DTOs
{    
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }        
        
        public string Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int InstructorID { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
