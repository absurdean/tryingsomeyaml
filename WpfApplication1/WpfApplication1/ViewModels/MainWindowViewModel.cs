using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Helpers;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged

        //пример textBoxControl'a в который биндятся данные из yaml
        public TextBoxControlViewModel TextBoxEx { get; set; }

        public MainWindowViewModel()
        {

            //список моделей с данными, получаемых из yaml
            var controls = YamlDriver.GetObjects(@"..\..\Resources\YamlConfig.yaml");

            //пример инициализации textBoxControl'a
            TextBoxEx = new TextBoxControlViewModel(controls[0] as TextBoxModel);

           
        }
    }
}
