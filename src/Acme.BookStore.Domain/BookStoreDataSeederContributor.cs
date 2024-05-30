using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepo;

    public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepo)
    {
        this._bookRepo = bookRepo;
    }
    
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepo.GetCountAsync() <= 0)
        {
            await _bookRepo.InsertAsync(new Book
            {
                Name = "1984",
                Type = BookType.Dystopia,
                PublishDate = new DateTime(1949, 6, 8),
                Price = 19.84f
            }, true);
            await _bookRepo.InsertAsync(new Book
            {
                Name = "The Hitchhiker's Guide to the Galaxy",
                Type = BookType.ScienceFiction,
                PublishDate = new DateTime(1995, 9, 27),
                Price = 42.0f
            }, true);
        }
    }
}