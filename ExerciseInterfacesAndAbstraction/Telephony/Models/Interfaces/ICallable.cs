using System;
namespace Telephony.Models
{
	public interface ICallable
	{
		string Call(string phoneNumber);
	}
}