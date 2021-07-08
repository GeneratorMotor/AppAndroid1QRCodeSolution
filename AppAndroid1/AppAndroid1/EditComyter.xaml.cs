using System;
using System.Net;

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
    public partial class EditComyter : TabbedPage
    {
        private ViewCompyter vk;

        
        public EditComyter(ViewCompyter vk)
        {
            if(vk == null)
            {
                throw new ArgumentNullException("Нет данных для редактирования");
            }

            this.vk = vk;

            InitializeComponent();

            // Привяжем к странице данные.
            this.BindingContext = vk;
        }
    }
}