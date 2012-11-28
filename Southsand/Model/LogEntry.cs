using System;

namespace Southsand.Model
{
	public class LogEntry
	{
		public virtual string Type { get; set; }
		public virtual long EntityId { get; set; }
		public virtual DateTime At { get; set; }
		public virtual string User { get; set; }
	}
}