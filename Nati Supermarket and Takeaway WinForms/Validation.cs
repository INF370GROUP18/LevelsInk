using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public class Validation
    {
        public bool validationAlphamumeric(string validationText)
        {
            Regex r = new Regex(@"^[a-zA-Z0-9\s,]*$");
            if (r.IsMatch(validationText))

            {
                return true;
            }
            else
            {
                return false;

            };

        }
        public bool validationPhoneNumber(string TexttoValidate)
        {
            if (TexttoValidate.Length == 10 && TexttoValidate.Length >= 10 && TexttoValidate.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidationEmail(string textToValidate)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(textToValidate);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ValidationDecimal(string textToValidate)
        {
            Regex r = new Regex(@"[\d]{1,4}([.,][\d]{1,2})?");
            if (r.IsMatch(textToValidate))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
        public bool ValidationNumeric(string textToValidate)
        {
            int outparse;
            if (int.TryParse(textToValidate, out outparse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidationTextOnly(string textToValidate)
        {
            Regex r = new Regex(@"^[a-zA-Z ]*$");
            if (r.IsMatch(textToValidate))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}
