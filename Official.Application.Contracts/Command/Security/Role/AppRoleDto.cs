namespace Official.Application.Contracts.Command.Security.Role
{
    public class AppRoleDto
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public string NormalizedName { get; private set; }
        public string ConcurrencyStamp { get; private set; }
    }
}
