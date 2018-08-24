namespace TicketMS.API.Data.Entity.Secondary.Report
{
    public class PackageSummaryEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TicketsCount { get; set; }
        public string NewTicketsCount { get; set; }

        public string SerialName { get; set; }
    }
}
