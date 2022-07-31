using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Command
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {

            private readonly IApplicaitonDbContext _context;

            public CreateProductCommandHandler(IApplicaitonDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Name = command.Name;
                product.Barcode = command.Barcode;
                product.Description = command.Description;
                product.Rate = command.Rate;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }

    }
}
