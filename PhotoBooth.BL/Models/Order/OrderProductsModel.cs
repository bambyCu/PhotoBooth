﻿using PhotoBooth.BL.Models.Item.Product;
using PhotoBooth.BL.Models.Item.RentalItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoBooth.BL.Models.Order
{
    class OrderProductsModel : ModelBase
    {
        public DateTime RentalSince { get; set; }
        public DateTime RentalTill { get; set; }
        public ICollection<RentalItemModel> RentalItems { get; set; }
        public ICollection<ProductModel> OrderItems { get; set; }
    }
}
