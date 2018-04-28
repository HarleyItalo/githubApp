using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GitHub.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        bool _isRunning;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    Notify();

                }
            }
        }

        public static Dictionary<string, object> Parameters
        {
            get;
            set;
        } = new Dictionary<string, object>();


        public void SetParameters(string Key, object Value)
        {
            if (Parameters.Keys.Contains(Key))
            {
                Parameters.Remove(Key);
            }
            Parameters.Add(Key, Value);
        }


        public async Task NavigateTo(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        public async Task NavigateBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public virtual void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            GC.Collect();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
