using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using AppAndroid1.Classess;
using ZXing.Mobile;
using ZXing;
using AppAndroid1.Droid.Classess;
using AppAndroid1.Droid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace AppAndroid1
{
    public partial class MainPage : ContentPage
    {
       
        // Создается один раз для всего приложения.
        private readonly HttpClient client;

        public const string TextCopyright = "Разработчик ЦКСЗН г. Саратов";

        // Строка подключения к БД.
        private readonly string con = "Server=10.159.102.21;Database=Android;User ID=myAndroid;Password=12A60Asd;";
        public MainPage()
        {
            InitializeComponent();


            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            client = new HttpClient();
        }

        private async void buttin1_Clicked(object sender, EventArgs e)
        {
            // /Проверим подключение к сети.
            var current = Connectivity.NetworkAccess;

            // Проверим доступна ли сеть.
            if (current == NetworkAccess.Internet)
            {

                // TODO: Отключили пока камеру для теста.

                #region Для теста закоментировал

                //// Подключим камеру и прочитаем QR код.
                //MobileBarcodeScanner scanner = new MobileBarcodeScanner();
               
                //// Включим сканер в камере.
                //scanner.UseCustomOverlay = true;

                //// Установим свойства камеры.
                //var opt = new MobileBarcodeScanningOptions();
                //opt.PossibleFormats.Clear();
                //opt.PossibleFormats.Add(ZXing.BarcodeFormat.QR_CODE);
                //opt.DelayBetweenContinuousScans = 3000;

                //// Включим ингвертирование изображения.
                //opt.TryInverted = true;

                #endregion

                try
                {
                    #region Закоментировано для теста
                    // TODO: Отключим камеру пока для теста
                    ////Прочитаем ID записи из QR кода.
                    //Result result = await scanner.Scan(opt);

                    //// Если прочитали данные с камеры.
                    //if (result != null)
                    //{
                    //    // Подадим вибро сигнал.
                    //    var duration = TimeSpan.FromSeconds(1);
                    //    Vibration.Vibrate(duration);

                    //    // Подадим звуковой сигнал.
                    //    // Файл храниться в AppAndroid1.Android.Assets.
                    //    //MyMediaPlayer myMediaPlayer = new MyMediaPlayer("zvonok.mp3");
                    //    //myMediaPlayer.StartPlayer();
                    //}


                    //// /Подача звукового сигнала пока не работает код оставим вдргу пригодиться
                    //////////string filePath = "Sound/zvonok.mp3";
                    ////////// Моя реализация звукового сигнала.
                    //////////MyMediaPlayer myMediaPlayer = new MyMediaPlayer(filePath);

                    //// Переменная для хранения id оргтехники для передачи в строку запроса.
                    //string id = string.Empty;

                    //// Получим значение id из QR кода
                    //id = result.Text.Trim();

                    #endregion

                    // TODO: Выключить тестовый путь на эмуляторе.
                    // Получим строку запроса к REST.
                    var uri = "http://10.159.102.93:80/api/Values/809";// + id.Trim();

                    // url к реальной REST API.
                    //var uri = "http://217.23.79.222:9090/api/Values/" + id.Trim();
                    
                    // TODO: Для тестироования в эмуляторе.
                    //var uri = "http://217.23.79.222:9090/api/Values/" + id.Trim();

                    // Получим данные о компьюторе.
                    GetMessage getMessage = new GetMessage();

                    // Получим ответ от сервера.
                    string jsonResultDate = await getMessage.Get(uri);

                    // Так как я долбаеб, и не разобрался с JObject
                    // Распарсим строку своими силами.

                    string[] jsonArray = jsonResultDate.Replace("{",string.Empty).Replace("}",string.Empty).Split(',');

                    // Модель компьютера.
                    ViewCompyter vk = new ViewCompyter();


                    // Счетчик.
                    int iCount = 1;

                    // Флаг указывает что мы должны отобразить данные по монитору.
                    bool flagDisplay = false;


                    // Распарсим строку на поля объекта.
                    foreach (var jstr in jsonArray)
                    {
                        string[] jsonArr = jstr.Split(':');

                        if (iCount == 1)
                        {
                            if (jsonArr != null && jsonArr[1] != null)
                            {
                                vk.id = Convert.ToInt32(jsonArr[1]);
                            }
                            else
                            {
                                vk.id = 0;
                            }
                        }
                        else if(iCount == 2)
                        {
                            if (jsonArr != null && jsonArr[1] != null)
                            {
                                vk.SeriynNumber = jsonArr[1].Trim();
                            }
                            else
                            {
                                vk.SeriynNumber = " - Ошибка выгрузки";
                            }
                        }
                        else if (iCount == 3)
                        {
                            if (jsonArr != null && jsonArr[1] != null)
                            {
                                vk.InventoryNumber = jsonArr[1].Trim();
                            }
                            else
                            {
                                vk.InventoryNumber = " - Ошибка выгрузки";
                            }
                        }
                        else if (iCount == 4)
                        {
                            if (jsonArr != null && jsonArr[1] != null)
                            {
                                vk.Name = jsonArr[1].Trim();
                            }
                            else
                            {
                                vk.Name = " - Ошибка выгрузки";
                            }
                        }
                        else if (iCount == 5)
                        {
                            if (jsonArr != null && jsonArr[1] != null)
                            {
                                vk.DepartmentName = jsonArr[1].Trim();
                            }
                            else
                            {
                                vk.DepartmentName = " - Ошибка выгрузки";
                            }
                        }
                        else if(iCount == 6)
                        {
                            if(jsonArr != null && jsonArr[1] != null)
                            {
                                vk.Сотрудник = jsonArr[1].Trim();
                            }
                            else
                            {
                            vk.Сотрудник = "Ошибка выгрузки";
                            }
                        }

                        iCount++;
                    }


                 
                    // TODO: Оставим пока не разберусь с JObject.
                    //// Распарсим строку с результатом ответа в JSON.
                    //JObject o = JObject.Parse(jsonResultDate);

                    ////var str = o.SelectToken(@"$.query.results.ViewCompyter");
                    //var str = o.SelectToken(@"$.pre");

                    ////var rateInfo = JsonConvert.DeserializeObject<ViewCompyter>(str.ToString());
                    //var rateInfo = JsonConvert.DeserializeObject<ViewCompyter>(jsonResultDate);

                    //// Проверим что мы получили системный блог, монитор или принтер.
                    //if(vk.flagDisplay == false && vk.flagPrinter == false)
                    //{
                        // Если оба флага лож, значит мы получили системный блок.
                        // Перейдем на другую страницу.
                        //PageDisplay pd = new PageDisplay(vk);

                        PageCompyter pd = new PageCompyter(vk);


                        // Добавим страницу в навигацию.
                        Navigation.PushAsync(pd);
                //}


            }
                catch (Exception exp)
            {
                await DisplayAlert("Ошибка", exp.Message, "Закрыть");
                //Если ошибка
                //inputId.Text = exp.Message;
            }

        }
            else
            {
                await DisplayAlert("Подключенние", "Подключение к сети отсутствует", "ОК");
            }

        }
    }
}
