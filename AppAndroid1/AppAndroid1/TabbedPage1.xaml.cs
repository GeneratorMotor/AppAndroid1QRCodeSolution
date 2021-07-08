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
        public TabbedPage1(ViewCompyter vk)
        {
            InitializeComponent();

            if (vk == null)
            {
                throw new ArgumentNullException("Нет данных по компьютеру");
            }

            this.vk = vk;

        }


    }
}