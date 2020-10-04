namespace TheShop
{
	public class Supplier1 : ISupplier
	{
		public bool ArticleInInventory(int id) => true;		

		public Article GetArticle(int id)
		{
			return new Article()
			{
				Id = 1,
				NameOfArticle = "Article from supplier1",
				ArticlePrice = 458
			};
		}
	}

}
