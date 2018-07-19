using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Models;

namespace Core.Actions
{
    public class SaveProductHandler : IRequestHandler<SaveProductRequest, Product>
    {
        public Task<Product> Handle(SaveProductRequest request, CancellationToken cancellationToken)
        {
            using (var db = new AppDbContext())
            {
                var result = db.Products.Add(request.Payload);
                db.SaveChanges();
                return Task.FromResult(result.Entity);
            }
        }
    }

    public class SaveProductRequest : IRequest<Product>
    {
        public Product Payload { get; }

        public SaveProductRequest(Product payload)
        {
            Payload = payload;
        }
    }
}