﻿namespace TicketMS.API.Infrastructure.DTO.Ticket
{
    public class TicketDTO
    {
        public int NominalId { get; set; }
        public int ColorId { get; set; }
        public int SerialId { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
    }
}
