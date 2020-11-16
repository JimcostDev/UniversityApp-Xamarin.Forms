namespace UniversityApp.ViewModels
{
    public class MainViewModel
    {
        public CourseViewModel Courses { get; set; }
        public CourseInstructorsViewModel CourseInstructors { get; set; }
        public MoviesViewModel Movies { get; set; }
        public StudentsViewModel Students { get; set; }
        public DepartmentsViewModel Departments { get; set; }
        public InstructorViewModel Instructors { get; set; }
        public EnrollmentViewModel Enrollments { get; set; }
        public OfficeAssignmentViewModel OfficeAssignments { get; set; }

        public MainViewModel()
        {
            Courses = new CourseViewModel();
            CourseInstructors = new CourseInstructorsViewModel();
            Students = new StudentsViewModel();
            Departments = new DepartmentsViewModel();
            Instructors = new InstructorViewModel();
            Enrollments = new EnrollmentViewModel();
            OfficeAssignments = new OfficeAssignmentViewModel();
            //Movies = new MoviesViewModel();

        }
    }
}