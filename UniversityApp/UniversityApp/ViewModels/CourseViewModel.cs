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
    public class CourseViewModel : BaseViewModel
    {
        private BL.Services.ICourseService courseService;
        private ObservableCollection<CourseDTO> courses;
        private bool isRefreshing;
        public ObservableCollection<CourseDTO> Courses
        {
            get { return this.courses; }
            set { this.SetValue(ref this.courses, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public CourseViewModel()
        {
            this.courseService = new CourseService();
            this.RefreshCommand = new Command(async () => await GetCourses());
            this.RefreshCommand.Execute(null);
        }
        public Command RefreshCommand { get; set; }

        async Task GetCourses() {
            try
            {
                this.IsRefreshing = true;
                var connection = await courseService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }
                var listCourses = await courseService.GetAll(Endpoints.GET_COURSES);
                this.Courses = new ObservableCollection<CourseDTO>(listCourses);
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
