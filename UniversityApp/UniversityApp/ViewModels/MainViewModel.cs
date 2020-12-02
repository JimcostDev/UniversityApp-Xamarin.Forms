using System.Threading.Tasks;
using UniversityApp.Views;
using Xamarin.Forms;

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
        public CreateCourseViewModel CreateCourse { get; set; }
        public CreateStudentViewModel CreateStudent { get; set; }
        public CreateInstructorViewModel CreateInstructor { get; set; }
        public LoginViewModel Login { get; set; }
        public HomeViewModel Home { get; set; }

        public EditStudentViewModel EditStudent { get; set; }
        public EditInstructorViewModel EditInstructor { get; set; }


        public MainViewModel()
        {
            instance = this;
            Courses = new CourseViewModel();
            CourseInstructors = new CourseInstructorsViewModel();
            Students = new StudentsViewModel();
            Departments = new DepartmentsViewModel();
            Instructors = new InstructorViewModel();
            Enrollments = new EnrollmentViewModel();
            OfficeAssignments = new OfficeAssignmentViewModel();
            CreateCourse = new CreateCourseViewModel();
            CreateStudent = new CreateStudentViewModel();
            CreateInstructor = new CreateInstructorViewModel();
            Login = new LoginViewModel();
            Home = new HomeViewModel();

            CreateStudentCommand = new Command(async () => await GoToCreateStudent());
            CreateInstructorCommand = new Command(async () => await GoToCreateInstructor());

            //Movies = new MoviesViewModel();
        }

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();

            return instance;
        }
        public Command CreateStudentCommand { get; set; }
        async Task GoToCreateStudent()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateStudentPage());
        }

        public Command CreateInstructorCommand { get; set; }
        async Task GoToCreateInstructor()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateInstructorPage());
        }
    }
}