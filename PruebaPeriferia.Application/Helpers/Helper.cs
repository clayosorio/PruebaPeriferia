using System.Text.RegularExpressions;

namespace PruebaPeriferia.Application.Helpers
{
    public static class Helper
    {
        public static bool IsValidEmail(string email) => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}
