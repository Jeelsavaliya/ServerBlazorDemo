﻿using Microsoft.AspNetCore.Components;
using ServerBlazorDemo.Models;
using ServerBlazorDemo.Services;

namespace ServerBlazorDemo.Components.Pages
{
    public partial class StudentList
    {
        [Inject]
        public IStudentService studentService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public bool StateConferm { get; set; } 

        public List<Student> students { get; set; } = new List<Student>();

        protected override async Task OnInitializedAsync()
        {
            students = await studentService.GetAllStudentsAsync();
            StateHasChanged();
            
        }

        protected void AddStd()
        {
            StateHasChanged();
            navigationManager.NavigateTo("/add-student");
        }

        protected void DeleteStd()
        {
            StateConferm = true;
            StateHasChanged();
        }
    }
}
