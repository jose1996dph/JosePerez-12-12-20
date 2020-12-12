using Miniproject.Services;
using Miniproject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miniproject
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton(new TaskStore());
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
