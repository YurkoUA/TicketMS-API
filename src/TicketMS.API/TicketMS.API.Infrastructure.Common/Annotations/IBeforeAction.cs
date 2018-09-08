using Microsoft.AspNetCore.Mvc;

namespace TicketMS.API.Infrastructure.Common.Annotations
{
    public interface IBeforeAction
    {
        void ExecuteBeforeAction(ActionContext context);
    }
}
