namespace CleanArchitecture.Domain.Model
{
    public partial class Role
    {

        public int Id { get; set; }
        public string? DRole { get; set; }
        public virtual ICollection<PersonRole>? PersonRoles { get; set; }
    }
}
