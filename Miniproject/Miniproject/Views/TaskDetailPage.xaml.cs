using Miniproject.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Miniproject.Views
{
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage()
        {
            InitializeComponent();
            BindingContext = new TaskDetailViewModel();
        }
    }
}