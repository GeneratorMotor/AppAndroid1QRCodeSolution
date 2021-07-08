using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppAndroid1.Classess;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            // Получим строку запроса к REST.
            var uri = "http://10.159.102.93/api/Values/3";

            GetMessage getMessage = new GetMessage();

            // Получим ответ от сервера.
            string resultDate = await getMessage.Get(uri);

            //// Распарсим строку с результатом ответа в JSON.
            //JObject o = JObject.Parse(resultDate);

            //var str = o.SelectToken(@"$.query.results.ViewCompyter");

            //var rateInfo = JsonConvert.DeserializeObject<ViewCompyter>(str.ToString());

            //// TODO:  Для теста .
            //this.inputId.Text = result.Text;
        }
    }
}
