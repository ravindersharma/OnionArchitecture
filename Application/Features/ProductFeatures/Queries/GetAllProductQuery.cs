using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllProductQuery:IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>> {


            private readonly IApplicaitonDbContext _context;

            public GetAllProductsQueryHandler(IApplicaitonDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query, CancellationToken cancellationToken) {
                var productList = await _context.Products.ToListAsync();
                if (productList == null) return null;

                return productList.AsReadOnly();
            
            }
        
        }
    }
}
