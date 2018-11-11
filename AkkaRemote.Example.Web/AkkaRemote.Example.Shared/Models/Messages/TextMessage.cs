using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaRemote.Example.Shared.Models.Messages
{
	public class TextMessage
	{
		public TextMessage(string text)
		{
			Text = text;
		}

		public string Text { get; }
	}
}
