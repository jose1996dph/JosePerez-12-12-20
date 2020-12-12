using Miniproject.Models;
using System;
using Xamarin.Forms;

namespace Miniproject.ViewModels
{
    public class NewTaskViewModel : BaseViewModel
    {
        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        private string taskTitle;

        public string TaskTitle
        {
            get => taskTitle;
            set => SetProperty(ref taskTitle, value);
        }

        public NewTaskViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(description) 
                && !String.IsNullOrWhiteSpace(TaskTitle);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Task newTask = new Task()
            {
                Id = Guid.NewGuid().ToString(),
                Title = TaskTitle,
                Description = Description
            };

            await DataStore.AddAsync(newTask);

            await Shell.Current.GoToAsync("..");
        }
    }
}
