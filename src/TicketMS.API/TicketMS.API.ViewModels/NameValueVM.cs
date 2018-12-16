namespace TicketMS.API.ViewModels
{
    public class NameValueVM<TValue>
    {
        public string Name { get; set; }
        public TValue Value { get; set; }
        public bool? IsDefault { get; set; }
    }
}
