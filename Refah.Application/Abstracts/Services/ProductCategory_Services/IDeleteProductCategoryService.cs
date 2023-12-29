﻿using Refah.Application.Contract.Operation;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.ProductCategory_Services
{
    [TransientService]
    public interface IDeleteProductCategoryService
    {
        Task<OperationResult> RemoveAsync(Guid id);
    }
}
