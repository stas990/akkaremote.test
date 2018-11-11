using Akka.Actor;
using Akka.Configuration;
using AkkaRemote.Example.Recipient.Actors;
using System;
using System.IO;

namespace AkkaRemote.Example.Recipient
{
	class Program
	{
		static void Main(string[] args)
		{
			var system = ActorSystem.Create("ExampleActors", ConfigurationFactory.ParseString(File.ReadAllText("akka.conf")));
			system.ActorOf(Props.Create<MessageRecipientActor>(), "MessageRecipient");
			Console.WriteLine("Hello World!");
			Console.ReadLine();
		}
	}
}
