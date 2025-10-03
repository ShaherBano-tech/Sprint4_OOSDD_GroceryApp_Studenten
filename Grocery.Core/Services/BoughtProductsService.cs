
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService : IBoughtProductsService
    {
        private readonly IGroceryListItemsRepository _groceryListItemsRepository;
        private readonly IClientRepository _clientRepository;
        //private readonly IProductRepository _productRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        public BoughtProductsService(
            IGroceryListItemsRepository groceryListItemsRepository, 
            IGroceryListRepository groceryListRepository, 
            IClientRepository clientRepository) 
            //IProductRepository productRepository)
        {
            _groceryListItemsRepository=groceryListItemsRepository;
            _groceryListRepository=groceryListRepository;
            _clientRepository=clientRepository;
            //_productRepository=productRepository;
        }
        public List<BoughtProducts> Get(int? productId)
        {
            if (productId == null) return new List<BoughtProducts>();

            var items = _groceryListItemsRepository.GetAll()
                .Where(i => i.ProductId == productId)
                .ToList();

            var result = new List<BoughtProducts>();

            foreach (var item in items)
            {
                var list = _groceryListRepository.Get(item.GroceryListId);
                if (list != null)
                {
                    var client = _clientRepository.Get(list.ClientId);
                    if (client != null)
                    {
                        result.Add(new BoughtProducts
                        {
                            Client = client,
                            GroceryList = list,
                        });
                    }
                }

                //throw new NotImplementedException();
            }
            return result;
        }
    }
}
