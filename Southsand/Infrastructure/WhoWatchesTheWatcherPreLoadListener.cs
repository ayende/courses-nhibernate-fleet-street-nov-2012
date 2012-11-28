using System;
using System.Security.Principal;
using NHibernate;
using NHibernate.Event;
using Southsand.Model;

namespace Southsand.Infrastructure
{
	public class WhoWatchesTheWatcherPreLoadListener : IPreLoadEventListener
	{
		public void OnPreLoad(PreLoadEvent @event)
		{
			var user = WindowsIdentity.GetCurrent().Name;
			
			using (var s = @event.Session.GetSession(EntityMode.Poco))
			{
				s.Save(new LogEntry
					{
						At = DateTime.Now,
						EntityId = (long) @event.Id,
						Type = @event.Persister.EntityName,
						User = user
					});
				s.Flush();
			}
		}
	}

}