using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace TheShop.UnitTests
{    
    [TestFixture]
    public class ShopServiceTests
    {
        private ShopService _shopService;

        [SetUp]
        public void SetUp()
        {
            _shopService = new ShopService(null, new FakeDatabaseDriver(), new List<ISupplier>() { new FakeSupplier() });
        }

        [Test]
        [TestCase(0, 1, 1)]
        public void OrderAndSellArticle_CanNotOrderArticleIsNull_TrowArgumetNullException(int id, int maxExpectedPrice, int buyerId)
        {            
            Assert.That(() => _shopService.OrderAndSellArticle(id, maxExpectedPrice, buyerId), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(1, 1, 1)]
        public void OrderAndSellArticle_ArticleIsNull_TrowException(int id, int maxExpectedPrice, int buyerId)
        {
            var shopService = new ShopService(null, new FakeDatabaseDriver(), new List<ISupplier>() { new FakeSupplier2() });
            Assert.That(() => _shopService.OrderAndSellArticle(id, maxExpectedPrice, buyerId), Throws.Exception);
        }


    }
}
