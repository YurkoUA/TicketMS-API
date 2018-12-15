using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketMS.API.Infrastructure.Common.Attributes.Validation
{
    public class PaletteColorAttribute : ValidationAttribute
    {
        // TODO: Error message.

        public override bool IsValid(object value)
        {
            if (value is string colorName)
            {
                return Regex.IsMatch(colorName, @"^[A-Za-z-]+$");
            }
            throw new ArgumentException();
        }
    }
}
