using Miniproject.ViewModels;
using Miniproject.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Miniproject
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
            Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));
        }

    }
}
