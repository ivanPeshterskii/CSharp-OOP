using System;
namespace Composite.Models.Interface
{
	public interface IGiftOperations
	{
		void Add(GiftBase gift);
		void Remove(GiftBase gift);
	}
}

