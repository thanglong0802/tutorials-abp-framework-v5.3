using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors;

public class Authors : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; set; }
    public string ShortBio { get; set; }

    private Authors()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Authors(Guid id, [NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio) : base(id)
    {
        SetName(name);
        BirthDate = birthDate;
        ShortBio = shortBio;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name), maxLength: AuthorConsts.MaxNameLength);
    }

    internal Authors ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }
}