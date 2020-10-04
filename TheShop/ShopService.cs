using System;
using System.Linq;
using System.Collections.Generic;

namespace TheShop
{
	public class ShopService
	{
		private readonly ILogger _logger;
		private readonly IDatabaseDriver _databaseDriver;
		private readonly IList<ISupplier> _suppliers;

		public ShopService(ILogger logger = null, IDatabaseDriver databaseDriver = null, IList<ISupplier> suppliers = null)
		{
			_logger = logger ?? new Logger();
			_databaseDriver = databaseDriver ?? new DatabaseDriver();
			_suppliers = suppliers ?? _databaseDriver.GetSuppliers();
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

			var articlesFromSuppliers = new List<Article>();

			foreach (var supplier in _suppliers)
			{
				if (supplier.ArticleInInventory(id))
					articlesFromSuppliers.Add(supplier.GetArticle(id));
			}

			var article = articlesFromSuppliers.OrderBy(a => a.ArticlePrice).FirstOrDefault(a => a.ArticlePrice <= maxExpectedPrice);

			#endregion

			#region selling article

			if (article == null)
				throw new ArgumentNullException("Could not order article");


			_logger.Log(LogMessageType.Debug, "Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				_databaseDriver.Save(article);
				_logger.Log(LogMessageType.Info, "Article with id=" + id + " is sold.");
			}
			catch (Exception ex)
			{
				_logger.Log(LogMessageType.Error, "Could not save article with id=" + id);
				throw new Exception("Could not save article with id=" + id + ex);
			}			

			#endregion
		}

		public Article GetById(int id) => _databaseDriver.GetById(id);	
	}

}
