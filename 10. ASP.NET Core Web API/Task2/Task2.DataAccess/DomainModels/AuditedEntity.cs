using Microsoft.AspNetCore.Identity;

namespace Task2.DataAccess.DomainModels;

public abstract class AuditedEntity : BaseEntity
{
    public Guid CreatedById { get; set; }
    public IdentityUser CreatedBy { get; set; }
    public DateTime Created { get; set; }

    public Guid UpdatedById { get; set; }
    public IdentityUser UpdatedBy { get; set; }
    public DateTime Updated { get; set; }
}