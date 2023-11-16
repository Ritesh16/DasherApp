// See https://aka.ms/new-console-template for more information
//using System.Globalization;
//using System.Threading;

//Console.WriteLine("Hello, World!");

//var url = @"C:\\Users\\rites\\Downloads\\data_archive (2)\dasher_delivery_information.csv";
//var data = File.ReadAllLines(url);
//for (int i = 0; i < data.Length; i++)
//{
//    if (i == 0)
//    {
//        continue;
//    }

//    DateTime date = DateTime.Parse(data[i].Split(',')[0].Replace("\"", ""),
//    CultureInfo.InvariantCulture);

//    var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
//    var today = TimeZoneInfo.ConvertTimeFromUtc(date, easternZone);
//    Console.WriteLine(today);


//}

using DasherApp.DataLoader;

var loader = new DataLoader();
loader.LoadDash();
