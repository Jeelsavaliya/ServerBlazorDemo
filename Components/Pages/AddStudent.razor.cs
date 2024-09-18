using Microsoft.AspNetCore.Components;
using ServerBlazorDemo.Models;
using ServerBlazorDemo.Services;

namespace ServerBlazorDemo.Components.Pages
{
    public partial class AddStudent
    {
        [Inject]
        public IStudentService studentService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        private Student student = new Student();

        protected async Task Save()
        {
            await studentService.AddStudent(student);
            StateHasChanged();
            navigationManager.NavigateTo("/student-list");
        }

        protected void BackToHome()
        {
            navigationManager.NavigateTo("/student-list");
        }
    }
}
