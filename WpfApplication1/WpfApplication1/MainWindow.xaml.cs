using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

        public class TextBox
        {
            public string Id { get; set; }
            public string Caption { get; set; }
            public string Size { get; set; }
        }
        public class CheckBox
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public string Size { get; set; }
        }
        public class RadioButtonGroup
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public string Orientation { get; set; }
            public List<string> OptionList { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("example1.yaml");
            string text = sr.ReadToEnd();
            var input = new StringReader(text);

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);

            // Examine the stream
            var mapping =
                (YamlMappingNode) yaml.Documents[0].RootNode;

            var items = (YamlSequenceNode) mapping.Children[new YamlScalarNode("form-elements")];

            foreach (YamlMappingNode item in items)
            {

                var type = item.Children[new YamlScalarNode("type")];

                switch (type.ToString())
                {
                    case "textbox":
                    {

                        var textboxItem = new TextBox()
                        {
                            Id = item.Children[new YamlScalarNode("id")].ToString(),
                            Caption = item.Children[new YamlScalarNode("caption")].ToString(),
                            Size = item.Children[new YamlScalarNode("size")].ToString(),
                        };

                        break;

                    }

                    case "checkbox":
                    {
                        var checkboxItem = new CheckBox()
                        {
                            Id = item.Children[new YamlScalarNode("id")].ToString(),
                            Label = item.Children[new YamlScalarNode("label")].ToString(),
                            Size = item.Children[new YamlScalarNode("size")].ToString(),
                        };
                        break;
                    }
                    case "radiobuttons":
                    {
                        var optionListItems = (YamlSequenceNode) item.Children[new YamlScalarNode("optionList")];
                        var list = new List<string>();
                        foreach (YamlScalarNode x in optionListItems)
                        {
                            list.Add(x.ToString());
                        }
                        var radiobuttonsItem = new RadioButtonGroup()
                        {
                            Id = item.Children[new YamlScalarNode("id")].ToString(),
                            Label = item.Children[new YamlScalarNode("label")].ToString(),
                            Orientation = item.Children[new YamlScalarNode("orientation")].ToString(),
                            OptionList = list,
                        }
                        ;
                        break;
                    }
                }


            }

        }
    }
}
