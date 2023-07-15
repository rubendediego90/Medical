using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    public partial class Role : BaseDomainModel
    {
        //Roles
        public string? DRole { get; set; }
        public virtual ICollection<PersonRole>? PersonRoles { get; set; }
    }
}
