﻿using System.Linq;

namespace HelloDocker.Models
{
    public class Repository : IRepository
    {

        private static Product[] DummyData = new Product[]
            {new Product{ Name = "Abbey Road", Category="Classic Rock", ProductId=1969, Price=10 },
             new Product{ Name = "Nevermind", Category="Alternative", ProductId=1994, Price=10 } };


        public IQueryable<Product> Products => DummyData.AsQueryable<Product>();
    };
}