using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if( await session.Query<Product>().AnyAsync() )
            {
                return;
            }

            session.Store(GetPreconfigureProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfigureProducts() => new List<Product>()
        {
             new Product
            {
                Id = new Guid("01915111-a4ab-44a8-becd-c9c0387e2b3b"),
                Name = "Madshan",
                Category = new List<string> { "Hehehehe", "HAhaha", "LOOLOLO" },
                Description = "Desfqewqewqe",
                ImageFile = "qwewqewq",
                Price = 20m
            },
            new Product
            {
                Id = new Guid("01915123-3b49-4397-b76d-5369a9b71bcd"),
                Name = "Madshan",
                Category = new List<string> { "Hehe", "HAhaha", "LOOLOLO" },
                Description = "Desfqewqewqe",
                ImageFile = "qwewqewq",
                Price = 20m
            }
        };
    }
}
