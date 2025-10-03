﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class GroceryListItem : ObservableObject
    {
        public int Id { get; set; }   // dit zat in je oude base class Model

        public int GroceryListId { get; set; }
        public int ProductId { get; set; }

        [ObservableProperty]
        private int amount;

        [ObservableProperty]
        private Product product = new(0, "None", 0);

        public GroceryListItem(int id, int groceryListId, int productId, int amount)
        {
            Id = id;
            GroceryListId = groceryListId;
            ProductId = productId;
            Amount = amount;
        }
    }
}

