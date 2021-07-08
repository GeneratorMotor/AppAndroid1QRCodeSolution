using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppAndroid1.Classess;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AppAndroid1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRoom : ContentPage
    {

        private List<Department> departments = new List<Department>();

        private string queryApi = "http://10.159.102.93:80/api/Room";

        public PageRoom()
        {
            InitializeComponent();

            

            //string queryApi = "http://localhost:50599/api/Room";

            HttpClient client = new HttpClient();

            var test = client.GetStringAsync(queryApi);

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject(test.Result);

            // Преобразуем string в Collection
            var listDepartments = JsonConvert.DeserializeObject<List<Department>>(json.ToString().Trim());

            if (listDepartments != null)
            {

                departments.AddRange(listDepartments);

                // Привяжем полученные данные.
                this.listDepartmens.ItemsSource = departments.Select(w => w.DepartmentName);
            }
            else
            {
                List<Department> departmentsNull = new List<Department>();
                Department departmentNull = new Department();
                departmentNull.DepartmentName = "Список на загружен";

                departmentsNull.Add(departmentNull);

                this.listDepartmens.ItemsSource = departmentsNull;
            }

        }

        public string TestTime()
        {
            return "Загрузили данными страницу";
        }

        private void OnTextChange(object sender, EventArgs e)
        {
            // Привяжем полученные данные.
            this.listDepartmens.ItemsSource = null;

            var dFind = this.departments
                    .Where(w => w.DepartmentName.ToLower().Contains(this.searFind.Text.ToLower())).Select(w => w.DepartmentName)
                    .ToList<string>();

            this.listDepartmens.ItemsSource = dFind;
        }

        private void listDepartmens_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                string nameDepartment = e.SelectedItem.ToString();

                // Найдем нужный Department.
                Department department = this.departments.Where(w => w.DepartmentName.ToLower().Trim() == nameDepartment.ToLower().Trim()).FirstOrDefault();

                if(department != null)
                {

                    NavigationPage.S

                    //// Обновим 
                    //Task<HttpStatusCode> httpStatusCode = Update(department);

                    //if(HttpStatusCode.OK != httpStatusCode.Result)
                    //{
                    //    // TODO: Пока не знаю наверное какое то окно с ошибкой.
                    //}
                }
            }
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            // Внесем изменение в БД.
            
        }

        // обновляем друга
        //public async Task<Department> Update(Department friend)
        public async Task<HttpStatusCode> Update(Department friend)
        //public async void Update(Department friend)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(queryApi,
                new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(friend),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.OK;

            //return System.Text.Json.JsonSerializer.Deserialize<Department>(
            //    await response.Content.ReadAsStringAsync(), options);
        }

        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}