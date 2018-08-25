namespace TicketMS.API.Bootstrap
{
    public static class Bootstrap
    {
        public static void Initialize()
        {
            DapperMapping.ConfigureCustomMapping();
        }
    }
}
