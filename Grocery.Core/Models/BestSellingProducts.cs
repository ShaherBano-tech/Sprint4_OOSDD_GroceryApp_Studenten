
using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class BestSellingProducts
    {

        public int Rank { get; set; }          // 1, 2, 3, ...
        public string Name { get; set; }       // Productnaam
        public int SoldQuantity { get; set; }  // Hoeveel verkocht
        public int Stock { get; set; }         // Nog op voorraad

    //public int Stock { get; set; }
    //[ObservableProperty]
    //public int nrOfSells;
    //[ObservableProperty]
    //public int ranking;

    //public BestSellingProducts(int productId, string name, int stock, int nrOfSells, int ranking) : base(productId, name)
    //{
    //    Stock=stock;
    //    NrOfSells=nrOfSells;
    //    Ranking=ranking;
    //}
    }
}
