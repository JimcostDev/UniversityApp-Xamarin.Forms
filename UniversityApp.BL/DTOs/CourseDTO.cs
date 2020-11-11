using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.BL.DTOs
{
    public class CourseDTO
    {
        [JsonProperty("CourseID")]
        public long CourseID { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Credits")]
        public long Credits { get; set; }
    }
}
