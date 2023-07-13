namespace CleanArchitecture.Domain.Model
{
    public partial class PersonRole
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? RoleId { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Role? Role { get; set; }
    }
}
