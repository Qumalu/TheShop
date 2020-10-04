namespace TheShop
{
	public class Supplier2 : ISupplier
	{
		public bool ArticleInInventory(int id) => true;

		public Article GetArticle(int id)
		{
			return new Article()
			{
				Id = 1,
				NameOfArticle = "Article from supplier2",
				ArticlePrice = 459
			};
		}
	}

}
