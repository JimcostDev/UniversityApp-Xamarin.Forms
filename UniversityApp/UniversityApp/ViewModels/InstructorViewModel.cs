﻿using System;
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
    public class InstructorViewModel : BaseViewModel
    {
        private BL.Services.IInstructorService instructorService;
        private ObservableCollection<InstructorDTO> instructors;
        private bool isRefreshing;

        public ObservableCollection<InstructorDTO> Instructors
        {
            get { return this.instructors; }
            set { this.SetValue(ref this.instructors, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public InstructorViewModel()
        {
            this.instructorService = new InstructorService();
            this.RefreshCommand = new Command(async () => await GetInstructors());
            this.RefreshCommand.Execute(null);
        }

        public Command RefreshCommand { get; set; }

        async Task GetInstructors()
        {
            try
            {
                this.IsRefreshing = true;

                var connection = await instructorService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }

                var listInstructors = await instructorService.GetAll(Endpoints.GET_STUDENTS);
                this.Instructors = new ObservableCollection<InstructorDTO>(listInstructors);
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
