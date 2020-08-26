using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class cotiz
    {
        public string moneda { get; set; }
        public string precio { get; set; }
    }
    public class vuelta
    {
        public resultado result { get; set; }

        public string status { get; set; }

    }
    public class resultado
    {
        public DateTimeOffset updated { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public float value { get; set; }
        public float quantity { get; set; }
        public float amount { get; set; }
    }
}
