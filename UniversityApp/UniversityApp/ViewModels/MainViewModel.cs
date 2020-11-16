namespace UniversityApp.ViewModels
{
    public class MainViewModel
    {
        public CourseViewModel Courses { get; set; }
        public CourseInstructorsViewModel CourseInstructors { get; set; }
        public MoviesViewModel Movies { get; set; }
        public StudentsViewModel Students { get; set; }

        public MainViewModel()
        {
            //Courses = new CoursesViewModel();
            //CourseInstructors = new CourseInstructorsViewModel();
            //Movies = new MoviesViewModel();
            Students = new StudentsViewModel();
        }
    }
}