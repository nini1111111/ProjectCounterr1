using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter22.Models
{
    public class Counter
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
        public string EditorPlaceholderText => "Enter counter's name";
        public DateTime Date { get; set; }
        public string SaveButtonText => "Save";
        public string DeleteButtonText => "Delete";
        public string AddButtonText => "Add";
        public string SubstractButtonText => "Substract";
       
    }
}
