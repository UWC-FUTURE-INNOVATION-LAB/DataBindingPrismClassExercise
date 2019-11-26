using DataBinding.Models;
using DataBindingPrism.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataBindingPrism.ViewModels
{
    public class SecondExerciseViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _productsList;
        private IDatabase _database;

        public ObservableCollection<Product> ProductsList
        {
            get { return _productsList; }
            set { SetProperty(ref _productsList, value); }
        }

        public SecondExerciseViewModel(INavigationService navigationService, IDatabase database) : base(navigationService)
        {
            _database = database;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

           var products = await _database.GetSortedData();

            ProductsList = new ObservableCollection<Product>(products);
        }
    }
}
