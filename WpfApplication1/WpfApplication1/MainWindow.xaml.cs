using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  

    public partial class MainWindow : Window
    {
       

        public class DeserializedTextBox
        {
            [YamlMember(Alias = "textbox")]
            public List<TextBox> textboxes { get; set; }
            public class TextBox
            {
                public string id { get; set; }
                public string caption { get; set; }
                public string size { get; set; }
            }
        }

        public class YamlImporter
        {
            public static DeserializedTextBox Deserialize(string yamlName)
            {
                StreamReader sr = new StreamReader(yamlName);
                string text = sr.ReadToEnd();
                var input = new StringReader(text);
                var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
                var deserializeObject = deserializer.Deserialize<DeserializedTextBox>(input);
                return deserializeObject;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DeserializedTextBox obj = YamlImporter.Deserialize("example1.yaml");
            Console.WriteLine(obj.textboxes[1].id);
            Console.WriteLine(obj.textboxes[1].caption);
            Console.WriteLine(obj.textboxes[1].size);
        }
    }
}
