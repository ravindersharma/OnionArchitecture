using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Command
{
    public class DeleteProductByIdCommand:IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {

            private readonly IApplicaitonDbContext _context;

            public DeleteProductByIdCommandHandler(IApplicaitonDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == command.Id);
                if (product == null) return default;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return command.Id;
            }
        }
    }
}
