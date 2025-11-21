using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.Service
{
    public class ServiceOrder
    {
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public string Option { get; set; }       // Клас таксі, тип ескорту тощо
        public string Notes { get; set; }

        public override string ToString()
        {
            string s = $"{ServiceName} × {Quantity}";
            if (!string.IsNullOrWhiteSpace(Option))
                s += $" ({Option})";
            if (!string.IsNullOrWhiteSpace(Notes))
                s += $" [{Notes}]";
            return s;
        }
    }

}
