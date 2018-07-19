using Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core.Actions
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, ICollection<Product>>
    {
        /// <summary>
        /// Getting all products
        /// </summary>
        public Task<ICollection<Product>> Handle(
            GetAllProductsRequest request, 
            CancellationToken cancellationToken)
        {
            using (var db = new AppDbContext())
            {
                var products = db.Products.ToList();
                return Task.FromResult<ICollection<Product>>(products);
            }
        }
    }

    public class GetAllProductsRequest : IRequest<ICollection<Product>>
    {
        public GetAllProductsRequest()
        {
            
        }
    }
}