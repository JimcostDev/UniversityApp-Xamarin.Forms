using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        private BL.Services.IStudentService studentService;
        private ObservableCollection<StudentDTO> student;
        private bool isRefreshing;

        public ObservableCollection<StudentDTO> Student
        {
            get { return this.student; }
            set { this.SetValue(ref this.student, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public StudentsViewModel()
        {
            this.studentService = new StudentService();
            this.RefreshCommand = new Command(async () => await GetStudents());
            this.RefreshCommand.Execute(null);
        }

        public Command RefreshCommand { get; set; }

        async Task GetStudents()
        {
            try
            {
                this.IsRefreshing = true;

                var connection = await studentService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }

                var listStudents = await studentService.GetAll(Endpoints.GET_STUDENTS);
                this.Student = new ObservableCollection<StudentDTO>(listStudents);
                this.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        }
    }
}
