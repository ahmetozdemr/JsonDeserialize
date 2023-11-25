using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace JsonDeserialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Json veri getir
            var data = GetJsonData();

            //Json datamı modele uyarla
            var MyEntities = Deserialize(data);

            //C# modelimi json'a geri çevir
            ConvertJson(MyEntities);
        }

        public static void ConvertJson(Weather model)
        {
            WriteMessage("Json data'ya geri çevirme başladı");
            var jsonObject = JsonConvert.SerializeObject(model);
            WriteMessage(jsonObject);
        }

        public static Weather Deserialize(string model)
        {
            WriteMessage("C# modelimize uyarlıyoruz");

            var convertData = JsonConvert.DeserializeObject<Weather>(model);
            WriteMessage(convertData.GetType().ToString());
            WriteMessage(convertData.Summary);
            int i = convertData.TemperatureCelsius;
            Console.WriteLine(i+20);

            return convertData;
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetJsonData()
        {
            var model = @"{
            'Date': '2019 - 08 - 01T00: 00:00 - 07:00',
            'TemperatureCelsius': 25,
            'Summary': 'Hot',
            'TemperatureRanges': {
                          'coldMinTemp': 20,
                          'hotMinTemp': 40
            }
           }";

            return model;
        }
    }
}
