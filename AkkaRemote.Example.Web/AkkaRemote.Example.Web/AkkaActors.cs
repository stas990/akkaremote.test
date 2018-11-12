using Akka.Actor;
using Akka.Configuration;
using AkkaRemote.Example.Web.Actors;
using System.IO;
using System.Threading;

namespace AkkaRemote.Example.Web
{
	public class AkkaActors
	{
		private ActorSystem _system;
		private static AkkaActors _instance;
		private static object _instanceLock = new object();

		private AkkaActors()
		{
			_system = ActorSystem.Create("ExampleActors", ConfigurationFactory.ParseString(File.ReadAllText("akka.conf")));
			MessageRecipientRef = _system.ActorSelection($"{Startup.Configuration["client"]}user/MessageRecipient");
			_system.ActorOf(RecipientWatcherActor.GetProps(MessageRecipientRef));
		}

		public static AkkaActors Instance
		{
			get
			{
				if(_instance == null)
				{
					lock(_instanceLock)
					{
						if (_instance == null)
						{
							var instance = new AkkaActors();
							Thread.MemoryBarrier();
							_instance = instance;
						}
					}
				}

				return _instance;
			}
		}

		public ICanTell MessageRecipientRef { get; }
	}
}
