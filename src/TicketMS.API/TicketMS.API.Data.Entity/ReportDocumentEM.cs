namespace TicketMS.API.Data.Entity
{
    public class ReportDocumentEM
    {
        public int Id { get; set; }
        public ReportTypeEM Type { get; set; }
        public string FileUrl { get; set; }
    }
}
