namespace Official.Application.Contracts.Command.Log.AuditEntry
{
    public class AuditEntryDto
    {
        public int AuditEntryID { get; private set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; private set; }
        public string EntitySetName { get; private set; }
        public string EntityTypeName { get; set; }
        public int State { get; set; }
        public string StateName { get; private set; }

        public string NationalCode { get; set; }
        public string FullName { get; private set; }

    }
}
