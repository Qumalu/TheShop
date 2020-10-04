using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TheShop.UnitTests
{
    [TestFixture]
    class FakeSupplier : ISupplier
    {
        public bool ArticleInInventory(int id) => false;

        public Article GetArticle(int id) => null;        
        
    }
}
