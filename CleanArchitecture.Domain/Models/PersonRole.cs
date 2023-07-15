using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Model
{
    //roles disponibles para un usaurio
    public partial class PersonRole : BaseDomainModel
    {
        public int? PersonId { get; set; }
        public int? RoleId { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Role? Role { get; set; }
    }
}
