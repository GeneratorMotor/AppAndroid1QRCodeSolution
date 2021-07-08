using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppAndroid1.Classess
{
    /// <summary>
    /// Класс описывающий карточку с орг. техникой.
    /// </summary>
    public class ViewCompyter
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("SeriynNumber")]
        public string SeriynNumber { get; set; }

        [JsonProperty("InventoryNumber")]
        public string InventoryNumber { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        //[JsonProperty("FirstName")]
        //public string FirstName { get; set; }

        //[JsonProperty("Expr1")]
        //public string Expr1 { get; set; }

        //[JsonProperty("SecondName")]
        //public string SecondName { get; set; }

        [JsonProperty("DepartmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("Сотрудник")]
        public string Сотрудник { get; set; }

        ///// <summary>
        ///// Указывает что текущая запись монитор.
        ///// </summary>
        //[JsonProperty("flagDisplay")]
        //public bool flagDisplay { get; set; }

        ///// <summary>
        ///// Указывает что текущая запись принтер.
        ///// </summary>
        //[JsonProperty("flagPrinter")]
        //public bool flagPrinter { get; set; }
    }
}
