using System;
using System.Collections.Generic;
using System.Text;

namespace ModulaLocal.Models
{
    public class TrayRespond
    {
        public int status { get; set; }
        public string message { get; set; } = string.Empty;
        public object data { get; set; }
        public string error { get; set; }
    }
}
