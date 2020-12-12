<<<<<<< HEAD
﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using NUnit.Framework;
using PhotoBooth.BL.Models.Order;
using PhotoBooth.BL.Queries;
=======
﻿using NUnit.Framework;
>>>>>>> e68eac5... added basic test for mapping
using PhotoBooth.DAL;
using PhotoBooth.DAL.Entity;
using PhotoBooth.DAL.Repository;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;


=======
using System.Linq;

>>>>>>> e68eac5... added basic test for mapping
namespace UnitTests
{
    public class MappingTests
    {
        private EntityFrameworkUnitOfWorkProvider<PhotoBoothContext> UnitOfWorkProvider;
        private BaseRepository<Order> OrdersRepository;

        [SetUp]
        public void SetupDatabase()
        {
            UnitOfWorkProvider = new TestUnitOfWorkProvider();
            OrdersRepository = new BaseRepository<Order>(UnitOfWorkProvider, new LocalDateTimeProvider());
        }

        [Test]
<<<<<<< HEAD
        public void OrderMappingTest()
        {
            MapperConfiguration MapConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<Order, OrderListModel>());
            var orderlist = new OrderListModel()
            {
                Address = "Hájecká 1800 Malíkovice 273 77",
                Id = Guid.Parse("9d75bbc6-206d-422d-a022-0f34719fc3fd"),
                RentalSince = new DateTime(2020, 12, 8, 16, 0, 0),
                RentalTill = new DateTime(2020, 12, 8, 23, 0, 0),
                Created = new DateTime(2020, 11, 3, 16, 0, 0),
                IsConfirmed = true,
                FinalPrice = 4321,
                CustomerFullName = "Marta Jurčíková"
            };
            var order = new Order()
            {
                LocationAddress = new Address()
                {
                    Street = "Hájecká",
                    BuildingNumber = "1800",
                    City = "Malíkovce",
                    PostalCode = "273 77"
                },
                RentalSince = new DateTime(2020, 12, 8, 16, 0, 0),
                RentalTill = new DateTime(2020, 12, 8, 23, 0, 0),
                Created = new DateTime(2020, 11, 3, 16, 0, 0),
                ConfirmationDate = new DateTime(2020, 11, 3, 16, 0, 0),
                FinalPrice = "4321",
                Customer = new ApplicationUser("Marta Jurčíková")
            };
            IQueryable<Order> orders = new List<Order>() { order }.AsQueryable();
            
            Assert.DoesNotThrow(() =>
            {
                orders.ProjectTo<OrderListModel>(MapConfig);
            });

        } 
    

        [Test]
        public void QueryTest()
        {
            using (UnitOfWorkProvider.Create())
            {
                OrderListQuery q = new OrderListQuery(UnitOfWorkProvider);
                Assert.DoesNotThrow(() =>
                {
                    q.Execute();
                });
=======
        public void OrderListQueryTest()
        {
            Order o = new Order(){
                RentalSince = new DateTime(2020, 12, 3, 16, 0, 0),
                RentalTill = new DateTime(2020, 12, 3, 23, 0, 0),
                Created = new DateTime(2020, 10, 3, 16, 0, 0),
                FinalPrice = 1234.ToString()
            };
            using (var uow = UnitOfWorkProvider.Create())
            {
                OrdersRepository.Insert(o);
                uow.Commit();
>>>>>>> e68eac5... added basic test for mapping
            }
        }

        protected PhotoBoothContext GetBoothContext(EntityFrameworkUnitOfWork<PhotoBoothContext> unitOfWork)
        {
            return unitOfWork.Context;
        }
    }
}