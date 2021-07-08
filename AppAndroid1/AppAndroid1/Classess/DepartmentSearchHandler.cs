using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAndroid1.Classess
{
    public class DepartmentSearchHandler : SearchHandler
    {
        private List<Department> departments;
        public Type SelectedItemNavigationTarget { get; set; }

        public DepartmentSearchHandler(List<Department> departments)
        {
            this.departments = departments;
        }


        /// <summary>
        /// Спимсок с номерами комнат.
        /// </summary>
        public IList<Department> Departments { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = this.departments
                    .Where(department => department.DepartmentName.ToLower().Contains(newValue.ToLower()))
                    .ToList<Department>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Let the animation complete
            await Task.Delay(1000);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((Department)item).DepartmentName}");
        }

        string GetNavigationTarget()
        {
            return null; //return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }
    }
}
