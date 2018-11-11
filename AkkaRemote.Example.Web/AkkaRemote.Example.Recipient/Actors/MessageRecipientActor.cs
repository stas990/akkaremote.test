using System;
using Akka;
using Akka.Actor;
using AkkaRemote.Example.Shared.Models.Messages;

namespace AkkaRemote.Example.Recipient.Actors
{
	public class MessageRecipientActor : UntypedActor
	{
		protected override void OnReceive(object message) => message.Match()
			.With<TextMessage>(x => Console.WriteLine(x.Text));
	}
}
