using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppAndroid1.Classess;

namespace AppAndroid1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        private ViewCompyter vk;

        private NavigationPage navigationPage1 = new NavigationPage();
        public TabbedPage1(ViewCompyter vk)
        {
            if (vk == null)
            {
                throw new ArgumentNullException("Нет данных по компьютеру");
            }

            this.vk = vk;

            InitializeComponent();

            // Создадим экземпляр PageRoom.
            PageRoom pageRoom = new PageRoom(this.vk);

            navigationPage1.PushAsync(pageRoom);

            StackLayout stackLayout = new StackLayout();
            stackLayout.BindingContext = navigationPage1;
            //stackLayout.Navigation.PushAsync(pageRoom);

            this.BindingContext = stackLayout;






            //// Сооздадим разметку Стек.
            //StackLayout stackLayout = new StackLayout
            //{
            //    // Добавим в стек панель навигации.
            //    Children =
            //    {
            //        var test = new NavigationPage();
            //    }
            //};

        }

            

            //PageRoom pageRoom = new PageRoom(this.vk);

            //StackLayout stackLayout = new StackLayout
            //{
            //    Children =
            //    {
            //        new NavigationPage
            //        {
            //            Title = "Номер комнаты",
            //            BindingContext = new PageRoom(this.vk);
            //        }
            //    }
            //}


            //NavigationPage navigationPage = new NavigationPage();
            //navigationPage.Title = "Номер комнаты";
            //navigationPage.BindingContext = pageRoom;

            //StackLayout stackLayout = new StackLayout();
            //stackLayout.Children.Add(navigationPage);
    }
}