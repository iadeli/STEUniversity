namespace Official.Application.Contracts.Command.Log.AuditEntry
{
    public class AuditEntryPropertyDto
    {
        public int AuditEntryPropertyID { get; set; }
        public int AuditEntryID { get; set; }
        public string PropertyName { get; set; }
        public string RelationName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
