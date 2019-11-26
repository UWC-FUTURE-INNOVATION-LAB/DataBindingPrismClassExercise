using DataBinding.Models;
using DataBindingPrism.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;

namespace DataBindingPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IDatabase _database;

        private DelegateCommand _getLatestProduct;
        public DelegateCommand GetLatestProductCommand =>
            _getLatestProduct ?? (_getLatestProduct = new DelegateCommand(ExecuteGetLatestProductCommand));

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        private Product _latestProduct;
        public Product LatestProduct
        {
            get { return _latestProduct; }
            set { SetProperty(ref _latestProduct, value); }
        }


        private async void ExecuteDeleteCommand()
        {
            await _database.DeleteProduct(LatestProduct);
            PopulateLatestProduct();
        }


        private async void ExecuteSaveCommand()
        {
            await _database.UpdateProduct(LatestProduct);
         
            PopulateLatestProduct();
        }

        private void ExecuteGetLatestProductCommand()
        {
            PopulateLatestProduct();
        }

        public MainPageViewModel(INavigationService navigationService, IDatabase database)
            : base(navigationService)
        {
            Title = "Main Page";

            _database = database;
        }

        private async void PopulateLatestProduct()
        {
            LatestProduct = await _database.GetLatestProduct();
        }
    }
}
