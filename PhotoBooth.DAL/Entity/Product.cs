﻿namespace PhotoBooth.DAL.Entity
{
    public class Product : ItemBase
    {
        public decimal Price { get; set; }
        public uint AmountLeft { get; set; }
    }
}