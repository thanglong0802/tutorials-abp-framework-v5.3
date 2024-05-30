using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Authors;

public interface IAuthorRepository : IRepository<Authors, Guid>
{
    Task<Authors> FindByNameAsync(string name);

    Task<List<Authors>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null);
}