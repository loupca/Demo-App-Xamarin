using System;
using System.Collections.Generic;
using System.Text;

namespace MASXamarinFormsDemo.Models.JsonResponse
{
    public class ProductResponseJson
    {

        public Product[] products { get; set; }
        public string device_geo { get; set; }
        public string clientCertsubject { get; set; }

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string price { get; set; }
        }

    }
}
