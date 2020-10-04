using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TheShop.UnitTests
{
    [TestFixture]
    class FakeSupplier2 : ISupplier
    {
        public bool ArticleInInventory(int id) => true;

        public Article GetArticle(int id) => new Article() { Id = 1, ArticlePrice = 1 };

    }
}
