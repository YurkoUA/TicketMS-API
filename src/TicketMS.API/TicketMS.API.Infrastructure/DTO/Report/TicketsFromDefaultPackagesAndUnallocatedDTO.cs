namespace TicketMS.API.Infrastructure.DTO.Report
{
    public class TicketsFromDefaultPackagesAndUnallocatedDTO
    {
        public int FromDefaultPackagesCount { get; set; }
        public int FromDefaultPackagesNewCount { get; set; }

        public int UnallocatedCount { get; set; }
        public int UnallocatedNewCount { get; set; }
    }
}
