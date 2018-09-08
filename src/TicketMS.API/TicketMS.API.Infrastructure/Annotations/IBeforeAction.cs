using Microsoft.AspNetCore.Mvc;

namespace TicketMS.API.Infrastructure.Annotations
{
    public interface IBeforeAction
    {
        void ExecuteBeforeAction(ActionContext context);
    }
}
