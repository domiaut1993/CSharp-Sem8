
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace upr2_aysel
{

    class Exercise2
    {
        public struct Coordinate
        {
            public float lat;
            public float lng;
        }

        static void Main()
        {


            string[] lines = File.ReadAllLines("C:\\Users\\student\\43\\UPR2\\UPR2\\UPR2\\input-01.txt");
            List<Coordinate> coordinates = new List<Coordinate>();

            foreach (var line in lines)
            {
                var pairs = line.Split(';');
                foreach (var pair in pairs)
                {
                    var latLng = pair.Split(',');
                    Coordinate coord = new Coordinate
                    {
                        lat = float.Parse(latLng[0], CultureInfo.InvariantCulture),
                        lng = float.Parse(latLng[1], CultureInfo.InvariantCulture)
                    };
                    coordinates.Add(coord);
                }
            }

            string json = JsonConvert.SerializeObject(coordinates, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("C:\\Users\\student\\43\\UPR2\\UPR2\\UPR2\\output.json", json);
        }


    }


}
