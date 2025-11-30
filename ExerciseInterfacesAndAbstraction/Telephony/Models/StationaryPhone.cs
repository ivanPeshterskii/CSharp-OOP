using System;
namespace Telephony.Models
{
	public class StationaryPhone : ICallable
	{
        public string Call(string phoneNumber)
        {
            bool isValidPhoneNumber = phoneNumber.All(c => char.IsDigit(c));
            if (!isValidPhoneNumber)
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}