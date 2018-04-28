using System;
using System.Linq;
namespace GitHub.ViewModels
{
    public class SourceCodePageViewModel : BaseViewModel
    {
        public SourceCodePageViewModel()
        {
            var param = Parameters.FirstOrDefault(i => i.Key == "URL");
            URL = param.Value.ToString();
        }
        private string _URL;
        public string URL
        {
            get { return _URL; }
            set { _URL = value; Notify(); }
        }
    }
}
