using System;
using System.Linq;

namespace TheShop
{
	public class ShopService
	{
		private readonly ILogger _logger;
		private readonly IDatabaseDriver _databaseDriver;

		private Supplier1 _supplier1;
		private Supplier2 _supplier2;
		private Supplier3 _supplier3;
		
		public ShopService(ILogger logger = null, IDatabaseDriver databaseDriver = null)
		{
			_logger = logger ?? new Logger();
			_databaseDriver = databaseDriver ?? new DatabaseDriver();
			_supplier1 = new Supplier1();
			_supplier2 = new Supplier2();
			_supplier3 = new Supplier3();
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

			Article article = null;
			Article tempArticle = null;
			var articleExists = _supplier1.ArticleInInventory(id);
			if (articleExists)
			{
				tempArticle = _supplier1.GetArticle(id);
				if (maxExpectedPrice < tempArticle.ArticlePrice)
				{
					articleExists = _supplier2.ArticleInInventory(id);
					if (articleExists)
					{
						tempArticle = _supplier2.GetArticle(id);
						if (maxExpectedPrice < tempArticle.ArticlePrice)
						{
							articleExists = _supplier3.ArticleInInventory(id);
							if (articleExists)
							{
								tempArticle = _supplier3.GetArticle(id);
								if (maxExpectedPrice < tempArticle.ArticlePrice)
								{
									article = tempArticle;
								}
							}
						}
					}
				}
			}
			
			article = tempArticle;
			#endregion

			#region selling article

			if (article == null)
				throw new Exception("Could not order article");


			_logger.Log(LogMessageType.Debug, "Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				_databaseDriver.Save(article);
				_logger.Log(LogMessageType.Info, "Article with id=" + id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				_logger.Log(LogMessageType.Error, "Could not save article with id=" + id);
				throw new Exception("Could not save article with id" + ex);
			}
			catch (Exception)
			{
			}

			#endregion
		}

		public Article GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}

}
