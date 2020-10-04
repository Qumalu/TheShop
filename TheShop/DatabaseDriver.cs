using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
	//in memory implementation
	public class DatabaseDriver : IDatabaseDriver
	{
		private List<Article> _articles = new List<Article>();

		public Article GetById(int id) => _articles.Single(x => x.Id == id);

		public void Save(Article article) => _articles.Add(article);

		public List<ISupplier> GetSuppliers() => new List<ISupplier>() { new Supplier1(), new Supplier2(), new Supplier3() };
	}

}
