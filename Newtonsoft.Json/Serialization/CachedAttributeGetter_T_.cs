using Newtonsoft.Json.Utilities;
using System;

namespace Newtonsoft.Json.Serialization
{
	internal static class CachedAttributeGetter<T>
	where T : Attribute
	{
		private readonly static ThreadSafeStore<object, T> TypeAttributeCache;

		static CachedAttributeGetter()
		{
			Class6.yDnXvgqzyB5jw();
			CachedAttributeGetter<T>.TypeAttributeCache = new ThreadSafeStore<object, T>(new Func<object, T>(JsonTypeReflector.GetAttribute<T>));
		}

		public static T GetAttribute(object type)
		{
			return CachedAttributeGetter<T>.TypeAttributeCache.Get(type);
		}
	}
}