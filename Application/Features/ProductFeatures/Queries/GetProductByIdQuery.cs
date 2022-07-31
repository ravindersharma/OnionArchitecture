using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int  Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicaitonDbContext _context;

            public GetProductByIdQueryHandler(IApplicaitonDbContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == query.Id);
                if (product == null) return null;
                return product;
            }
        }
    }
}
