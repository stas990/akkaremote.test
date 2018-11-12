using Akka;
using Akka.Actor;
using AkkaRemote.Example.Shared.Models.Messages;

namespace AkkaRemote.Example.Web.Actors
{
	public class RecipientWatcherActor : UntypedActor
	{
		private ICanTell _watchingTarget;

		public static Props GetProps(ICanTell watchingTarget) => Props.Create(() => new RecipientWatcherActor(watchingTarget));

		public RecipientWatcherActor(ICanTell watchingTarget)
		{
			_watchingTarget = watchingTarget;
			_watchingTarget.Tell(new HandshakeMessage(), Self);
		}

		protected override void OnReceive(object message) => message.Match()
			.With<Terminated>(ReceiveTerminated)
			.With<HandshakeResponseMessage>(ReceiveHandshakeResponseMessage);

		private void ReceiveHandshakeResponseMessage(HandshakeResponseMessage message)
		{
			Context.Watch(Context.Sender);
		}

		private void ReceiveTerminated(Terminated terminated)
		{

		}
	}
}
