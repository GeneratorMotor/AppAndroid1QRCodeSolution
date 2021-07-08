using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAndroid1.Classess;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAndroid1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCompyter : ContentPage
    {
        
        private ViewCompyter viewCompyter;
        public PageCompyter(ViewCompyter vk)
        {
            InitializeComponent();

            if(vk == null)
            {
                throw new ArgumentNullException("Отсутствует значения для описания оргтехники");
            }
            else
            {
                viewCompyter = vk;
            }

            // Привяжем экземпляр типа ViewCompyter
            // К контексту страницы.
            this.BindingContext = vk;
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        //private void Button_Clicked_1(object sender, EventArgs e)
        //{

        //}

        private void Button_Cliked_editRood(object sender, EventArgs e)
        {
            //EditComyter ek = new EditComyter(viewCompyter);
            TabbedPage1 ek = new TabbedPage1(viewCompyter);
            
            // Добавим страницу в навигацию.
            Navigation.PushAsync(ek);
        }
    }
}