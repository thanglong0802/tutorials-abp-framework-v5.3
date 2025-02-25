using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Books;

public class CreateUpdateBookDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime PublishDate { get; set; } = DateTime.Now;
    
    [Required]
    public float Price { get; set; }
    
    public Guid AuthorId { get; set; }
}