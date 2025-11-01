using System;
namespace Telephony.Models
{
	public class Smartphone : ICallable, IBrowsable
	{
        public string Browse(string url)
        {
            bool isValidUrl = url.All(c => !char.IsDigit(c));
            if (!isValidUrl)
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            bool isValidPhoneNumber = phoneNumber.All(c => char.IsDigit(c));
            if (!isValidPhoneNumber)
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }
    }
}

