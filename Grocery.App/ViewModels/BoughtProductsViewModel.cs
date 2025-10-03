using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;


namespace Grocery.App.ViewModels
{
    public partial class BoughtProductsViewModel : BaseViewModel
    {
        private readonly IBoughtProductsService _boughtProductsService;

        [ObservableProperty]
        Product selectedProduct;
        public ObservableCollection<BoughtProducts> BoughtProductsList { get; set; } = [];
        public ObservableCollection<Product> Products { get; set; }

        public BoughtProductsViewModel(IBoughtProductsService boughtProductsService, IProductService productService)
        {
            _boughtProductsService = boughtProductsService;
            //Products = new(productService.GetAll());
            var UniqueProducts = productService.GetAll()
                                               .DistinctBy(p => p.Id)
                                               .ToList();
            Products = new(UniqueProducts);
        }

        partial void OnSelectedProductChanged(Product? oldValue, Product newValue)
        {
            BoughtProductsList.Clear();
            if (newValue == null) return;


            foreach (var bp in _boughtProductsService.Get(newValue.Id))
                BoughtProductsList.Add(bp);

            //Zorg dat de lijst BoughtProductsList met de gegevens die passen bij het geselecteerde product. 
        }

        [RelayCommand]
        public void NewSelectedProduct(Product product)
        {
            SelectedProduct = product;
        }
    }
}
