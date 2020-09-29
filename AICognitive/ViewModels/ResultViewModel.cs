using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AICognitive.Models;
using TinyMvvm;
using Xamarin.Essentials;

namespace AICognitive.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        public Element Item { get; set; }

        public async override Task Initialize()
        {
            await base.Initialize();

            Item = (Element)NavigationParameter;

            RaisePropertyChanged(nameof(Item));
        }

        //public ICommand Open => new TinyCommand(() =>
        //{
        //    Browser.OpenAsync(Item.WikipediaUrl);
        //});
    }
}
