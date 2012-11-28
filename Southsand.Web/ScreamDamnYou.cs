using System.Media;
using System.Web;
using NHibernate;

namespace Southsand.Web
{
	public class ScreamDamnYou : EmptyInterceptor
	{
		public int NumberOfRequests
		{
			get { return (int) (HttpContext.Current.Items["number-of-request"] ?? 0); }
			set { HttpContext.Current.Items["number-of-request"] = value; }
		}

		public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
		{

			//if (NumberOfRequests++ > 10)
			//{
			//	new SoundPlayer("http://www.shockwave-sound.com/sound-effects/scream-sounds/2scream.wav").PlaySync();
			//}
			return base.OnPrepareStatement(sql);
		}	 
	}
}