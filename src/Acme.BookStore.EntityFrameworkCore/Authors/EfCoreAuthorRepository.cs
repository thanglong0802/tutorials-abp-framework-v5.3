using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Authors;

public class EfCoreAuthorRepository : EfCoreRepository<BookStoreDbContext, Authors, Guid>, IAuthorRepository
{
    public EfCoreAuthorRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Authors> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Authors>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), author => author.Name == filter)
            .OrderBy(sorting)
            .Take(maxResultCount)
            .ToListAsync();
    }
}