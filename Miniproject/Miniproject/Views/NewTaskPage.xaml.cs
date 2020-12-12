using Miniproject.Models;
using Miniproject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miniproject.Views
{
    public partial class NewTaskPage : ContentPage
    {
        public NewTaskPage()
        {
            InitializeComponent();
            BindingContext = new NewTaskViewModel();
        }
    }
}