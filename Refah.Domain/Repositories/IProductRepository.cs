﻿using Refah.Domain.Entities;
using Refah.Domain.Framework.Abstracts;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Domain.Repositories
{
    [ScopedService]
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Product> GetByCodeAsync(string code);
    }
}
