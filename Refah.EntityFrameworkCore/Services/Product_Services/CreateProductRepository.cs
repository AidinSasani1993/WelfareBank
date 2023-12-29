using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services.Product_Services
{
    [ScopedService]
    public class CreateProductRepository : CreateRepository<WelfareBankDbContext, Product, Guid>,
                                           ICreateProductRepository

    {
        public CreateProductRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}
