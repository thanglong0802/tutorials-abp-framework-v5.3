using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors;

public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    [CanBeNull]
    public string Filter { get; set; }
}