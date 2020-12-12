using Miniproject.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace Miniproject.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        private Models.Task _selectedTask;
        public Models.Task SelectedTask
        {
            get => _selectedTask;
            set
            {
                SetProperty(ref _selectedTask, value);
                OnTaskSelected(value);
            }
        }
        public ObservableCollection<Models.Task> Tasks { get; }
        public Command LoadTasksCommand { get; }
        public Command AddTaskCommand { get; }
        public Command<Models.Task> TaskTapped { get; }

        public TasksViewModel()
        {
            Title = "Browse";
            Tasks = new ObservableCollection<Models.Task>();
            LoadTasksCommand = new Command(async () => await ExecuteLoadTasksCommand());

            TaskTapped = new Command<Models.Task>(this.OnTaskSelected);

            AddTaskCommand = new Command(OnAddTask);
        }

        async System.Threading.Tasks.Task ExecuteLoadTasksCommand()
        {
            IsBusy = true;

            try
            {
                Tasks.Clear();
                var tasks = await DataStore.GetAllAsync();
                foreach (var task in tasks)
                {
                    Tasks.Add(task);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            _selectedTask = null;
        }

        private async void OnAddTask(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTaskPage));
        }

        private async void OnTaskSelected(Models.Task task)
        {
            if (task == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TaskDetailPage)}?{nameof(TaskDetailViewModel.TaskId)}={task.Id}");
        }
    }
}