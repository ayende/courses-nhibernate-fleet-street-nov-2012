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
			var result = (string)NHibernateUtil.String.NullSafeGet(rs, names);
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
			return new Dictionary<string, string>((IDictionary<string, string>)value);
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
			get { return new[] { NHibernateUtil.String.SqlType }; }
		}

		public Type ReturnedType
		{
			get { return typeof(IDictionary<string, string>); }
		}

		public bool IsMutable
		{
			get { return true; }
		}
	}

	public class NastyBooleanType : IUserType
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
			var val = rs[names[0]];

			if (val == DBNull.Value)
				return false;

			if (val is int)
				return ((int)val) != 0;

			var s = val as string;
			if (s != null)
			{
				if ("false".Equals(s, StringComparison.InvariantCulture) ||
					"null".Equals(s, StringComparison.InvariantCulture) ||
					"no".Equals(s, StringComparison.InvariantCulture) ||
					"0".Equals(s, StringComparison.InvariantCulture) ||
					"n".Equals(s, StringComparison.InvariantCulture))
					return false;
			}

			if (val is bool)
			{
				return val;
			}

			return true;
		}

		public void NullSafeSet(IDbCommand cmd, object value, int index)
		{
			if (value == null)
			{
				((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
			}
			else
			{
				((IDataParameter)cmd.Parameters[index]).Value = (bool)value;
			}
		}

		public object DeepCopy(object value)
		{
			return new Dictionary<string, string>((IDictionary<string, string>)value);
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
			get { return new[] { NHibernateUtil.String.SqlType }; }
		}

		public Type ReturnedType
		{
			get { return typeof(IDictionary<string, string>); }
		}

		public bool IsMutable
		{
			get { return true; }
		}
	}
}