using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketMS.API.Infrastructure.Attributes.Validation
{
    public class SerialNameAttribute : ValidationAttribute
    {
        // TODO: Error message.

        public override bool IsValid(object value)
        {
            if (value is string serialName)
            {
                return Regex.IsMatch(serialName, @"^[А-Я]{4}$");
            }

            throw new ArgumentException();
        }
    }
}
