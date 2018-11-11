using Akka.Actor;
using AkkaRemote.Example.Shared.Models.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaRemote.Example.Web.Controllers
{
	public class MessangerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Send(string message)
		{
			AkkaActors.Instance.MessageRecipientRef.Tell(new TextMessage(message), ActorRefs.NoSender);

			return RedirectToAction("Index");
		}
	}
}
