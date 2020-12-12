using Miniproject.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Miniproject.ViewModels
{
    [QueryProperty(nameof(TaskId), nameof(TaskId))]
    public class TaskDetailViewModel : BaseViewModel
    {
        private Models.Task task;
        public string Id { get; set; }
        private string taskTitle;
        public string TaskTitle
        {
            get => taskTitle;
            set => SetProperty(ref taskTitle, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        private bool isComplete;

        public bool IsComplete
        {
            get => isComplete;
            set => SetProperty(ref isComplete, value);
        }

        private string taskId;
        public string TaskId
        {
            get
            {
                return taskId;
            }
            set
            {
                taskId = value;
                LoadTaskId(value);
            }
        }

        public Command CompleteTaskCommand { get; }
        public Command DeleteTaskCommand { get; }
        public TaskDetailViewModel()
        {
            CompleteTaskCommand = new Command(OnCompleteTask);
            DeleteTaskCommand = new Command(OnDeleteTask);
        }

        public async void LoadTaskId(string taskId)
        {
            try
            {
                task = await DataStore.GetAsync(taskId);
                Id = task.Id;
                TaskTitle = task.Title;
                Description = task.Description;
                IsComplete = task.IsComplete;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Task");
            }
        }

        private async void OnCompleteTask()
        {
            try
            {
                if (!await Shell.Current.DisplayAlert(null, "Are you sure to complete this task?", "Yes", "No"))
                {
                    return;
                }

                if (task.IsComplete)
                {
                    return;
                }

                task.IsComplete = IsComplete = true;

                await DataStore.UpdateAsync(task);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to update Task");
            }
        }

        private async void OnDeleteTask()
        {
            try
            {
                if (!await Shell.Current.DisplayAlert(null, "Are you sure to delete this task?", "Yes", "No"))
                {
                    return;
                }

                await DataStore.DeleteAsync(task.Id);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to delete Task");
            }
        }
    }
}
