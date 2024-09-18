using Microsoft.AspNetCore.Components;
using ServerBlazorDemo.Models;
using ServerBlazorDemo.Services;

namespace ServerBlazorDemo.Components.Pages
{
    public partial class DeleteStudent
    {
        [Inject]
        public IStudentService studentService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public Student student { get; set; } = new();

        protected async Task Delete()
        {
            await studentService.DeleteStudentAsync(student.Id);
            StateHasChanged();
            navigationManager.NavigateTo("/student-list");
        }

        protected void Back()
        {
            navigationManager.NavigateTo("/student-list");
        }

    }
}
