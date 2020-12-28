﻿using AutoMapper.QueryableExtensions;
using PhotoBooth.BL.Models.Item.RentalItem;
using PhotoBooth.DAL.Entity;
using PhotoBooth.DAL.UnitOfWork;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoBooth.BL.Queries
{
    public class AvailableRentalItems : QueryBase<RentalItem, RentalItemModel>
    {
        private DateTime since;
        private DateTime till;
        public AvailableRentalItems(DateTime since, DateTime till, string databaseLink = "") : base(databaseLink) 
        {
            this.since = since;
            this.till = till;
        }

        public override ICollection<RentalItemModel> ExecuteAsync()
        {
            using (var uow = (specialDatabaseLink == "") ? new UnitOfWork(): new UnitOfWork(specialDatabaseLink))
            {
                var usedOrders = uow.OrderRepository.Get(x => (x.RentalSince >= since && x.RentalSince <= till) || (x.RentalTill >= since && x.RentalTill <= till));
                var items = usedOrders.Where(x => x != null).SelectMany(x => x.RentalItems);
                IQueryable temp = uow.GetRepo<RentalItem>().Get(x => !items.Contains(x), sortLambda, "").Take(pageSize).AsQueryable();
                return (ICollection<RentalItemModel>)temp.ProjectTo<RentalItemModel>(MapConfig);
            }
        }

    }
}
