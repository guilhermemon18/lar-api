using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Utils.Validation
{
    public class CpfValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            return ValidateCpf(value.ToString());
        }

        private bool ValidateCpf(string? v)
        {
            Console.WriteLine(v);
            if (v == null || string.IsNullOrEmpty(v.ToString()))
            {
                return false;
            }
            else
            {
                // if (v.Length == 14)
                // {
                //     string onlyNumbers = v.Replace(".", "").Replace("-", "");
                //     Console.WriteLine(v);
                //     Console.WriteLine(onlyNumbers);

                //     return v.ElementAt(3) == '.' && v.ElementAt(7) == '.' && v.ElementAt(11) == '-' && onlyNumbers.Length == 11 && onlyNumbers.All(char.IsDigit);
                // }
                // else
                if (v.Length == 11)
                {
                    return v.All(char.IsDigit);
                }

            }
            return false;
        }
    }
}