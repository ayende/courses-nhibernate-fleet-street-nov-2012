using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using Newtonsoft.Json;

namespace Southsand.Model
{
	public class Customer
	{
		public virtual long CustomerId { get; set; }
		public virtual string Email { get; set; }
		public virtual int Version { get; set; }

		public virtual DateTime LastAccess { get; set; }

		public virtual IDictionary<string, string> Custom { get; set; }
	}

	public class JsonType : IUserType
	{
		public bool Equals(object x, object y)
		{
			return object.Equals(x, y);
		}

		public int GetHashCode(object x)
		{
			return x.GetHashCode();
		}

		public object NullSafeGet(IDataReader rs, string[] names, object owner)
		{
			var result = (string) NHibernateUtil.String.NullSafeGet(rs, names);
			if (result == null)
				return null;
			return JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
		}

		public void NullSafeSet(IDbCommand cmd, object value, int index)
		{
			string val = value == null ? null : JsonConvert.SerializeObject(value);

			NHibernateUtil.String.NullSafeSet(cmd, val, index);
		}

		public object DeepCopy(object value)
		{
			return new Dictionary<string, string>((IDictionary<string, string>) value);
		}

		public object Replace(object original, object target, object owner)
		{
			return DeepCopy(target);
		}

		public object Assemble(object cached, object owner)
		{
			return cached;
		}

		public object Disassemble(object value)
		{
			return value;
		}

		public SqlType[] SqlTypes
		{
			get { return new[] {NHibernateUtil.String.SqlType}; }
		}

		public Type ReturnedType
		{
			get { return typeof (IDictionary<string, string>); }
		}

		public bool IsMutable
		{
			get { return true; }
		}
	}
}