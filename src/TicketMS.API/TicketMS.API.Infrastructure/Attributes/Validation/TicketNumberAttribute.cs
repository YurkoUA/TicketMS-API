using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketMS.API.Infrastructure.Attributes.Validation
{
    public class TicketNumberAttribute : ValidationAttribute
    {
        // TODO: Error message.

        public override bool IsValid(object value)
        {
            if (value is string number)
            {
                if (!Regex.IsMatch(number, @"^\d{6}$"))
                {
                    return false;
                }

                return !number.Equals("000000");
            }

            throw new ArgumentException();
        }
    }
}
