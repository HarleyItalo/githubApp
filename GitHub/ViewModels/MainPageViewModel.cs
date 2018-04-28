using System;
using System.Collections.ObjectModel;
using GitHub.Models;
using System.Windows.Input;
using Xamarin.Forms;
using GitHub.Views;
namespace GitHub.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Repositories> Respositories
        {
            get;
            set;
        } = new ObservableCollection<Repositories>();

        private Repositories _selected;
        public Repositories SelectedItem
        {

            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                Notify();
                if (_selected != null)
                {
                    new Command(async () =>
                    {
                        SetParameters("URL", _selected.HtmlUrl);
                        await NavigateTo(new SourceCodePage());
                    }).Execute(null);
                }
            }
        }

        private string _term;
        public string Term
        {
            get { return _term; }
            set { _term = value; Notify(); }
        }

        public ICommand BuscarRespositorios
        {
            get;
            set;
        }

        public MainPageViewModel()
        {
            BuscarRespositorios = new Command(async () =>
            {
                var respositories = new Repositories();
                if (!string.IsNullOrWhiteSpace(Term))
                {
                    IsRunning = true;
                    Respositories.Clear();

                    var results = await respositories.GetAsync($"https://api.github.com/users/{Term}/repos");


                    foreach (var item in results)
                    {
                        Respositories.Add(item);
                    }

                    IsRunning = false;
                }
            });


        }


    }
}
