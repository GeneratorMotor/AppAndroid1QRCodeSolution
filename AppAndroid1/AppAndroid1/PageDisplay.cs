using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppAndroid1.Classess;
using Xamarin.Forms;

namespace AppAndroid1
{
    public class PageDisplay : ContentPage
    {

        public PageDisplay(ViewCompyter wc)
        {
            Title = "Сведения об оргтехнике";

            Padding = new Thickness(20);
            
            if(wc == null)
            {
                throw new ArgumentNullException("Нет данных для отображения");
            }

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Отображаем данные с сервера", FontSize = 15, HorizontalOptions = LayoutOptions.Center },
                    new Label { Text = "Номер комнаты - " +  wc.DepartmentName?.Trim()  },
                    new Label { Text = "Серийный номер - " +  wc.SeriynNumber?.Trim()  },
                    new Label { Text = "Инвентарный номер - " +  wc.InventoryNumber?.Trim()  },
                    new Label { Text = "Описание компьютера - " +  wc.Name?.Trim()  },
                    new Label { Text = "Сотрудник - " +  wc.Сотрудник?.Trim()  },
                }
            };
            
        }
    }
}