using MVC.Client.Models;

namespace MVC.Client.Infrastructure
{
    public class LocalSession
    {
        public static IEnumerable<CatalogProduct> Products { get; set; }
    }
}
