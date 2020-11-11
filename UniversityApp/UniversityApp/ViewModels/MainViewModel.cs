using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.ViewModels
{
    public class MainViewModel
    {
        public CourseViewModel Courses { get; set; }
        public MainViewModel()
        {
            Courses = new CourseViewModel();
        }
    }
}
