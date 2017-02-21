using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{

    public enum Sizes : byte { Small=2, Mediu=4, Big=6 };

    public class TextBoxModel
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public int Size { get; set; }
    }
}
