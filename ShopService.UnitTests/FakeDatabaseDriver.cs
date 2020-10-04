using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TheShop.UnitTests
{
    [TestFixture]
    class FakeDatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new List<Article>() { new Article() { Id = 1 } };

        public Article GetById(int id) => _articles.SingleOrDefault(x => x.Id == id);

        public void Save(Article article) => throw new Exception("Error can not save article!");

        public List<ISupplier> GetSuppliers() => new List<ISupplier>() { new Supplier1(), new Supplier2(), new Supplier3() };

    }
}
