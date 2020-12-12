using Miniproject.Models;
using Miniproject.ViewModels;
using Miniproject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miniproject.Views
{
    public partial class TasksPage : ContentPage
    {
        TasksViewModel _viewModel;

        public TasksPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TasksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}