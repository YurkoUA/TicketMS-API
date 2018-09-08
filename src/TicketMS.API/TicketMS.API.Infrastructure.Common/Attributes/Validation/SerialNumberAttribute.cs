using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketMS.API.Infrastructure.Common.Attributes.Validation
{
    public class SerialNumberAttribute : ValidationAttribute
    {
        // TODO: Error message.

        public override bool IsValid(object value)
        {
            if (value is string serialNumber)
            {
                if (!Regex.IsMatch(serialNumber, @"^\d{2}$"))
                {
                    return false;
                }

                var numberInt = int.Parse(serialNumber);
                return numberInt >= 1 && numberInt <= 50;
            }

            throw new ArgumentException();
        }
    }
}
