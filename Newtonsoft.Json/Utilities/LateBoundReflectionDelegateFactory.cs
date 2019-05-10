using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory
	{
		private readonly static LateBoundReflectionDelegateFactory _instance;

		internal static ReflectionDelegateFactory Instance
		{
			get
			{
				return LateBoundReflectionDelegateFactory._instance;
			}
		}

		static LateBoundReflectionDelegateFactory()
		{
			Class6.yDnXvgqzyB5jw();
			LateBoundReflectionDelegateFactory._instance = new LateBoundReflectionDelegateFactory();
		}

		public LateBoundReflectionDelegateFactory()
		{
			Class6.yDnXvgqzyB5jw();
			base();
		}

		public override Func<T> CreateDefaultConstructor<T>(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			if (type.IsValueType())
			{
				return () => (T)Activator.CreateInstance(type);
			}
			ConstructorInfo defaultConstructor = ReflectionUtils.GetDefaultConstructor(type, true);
			return () => (T)defaultConstructor.Invoke(null);
		}

		public override Func<T, object> CreateGet<T>(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			return (T o) => propertyInfo.GetValue(o, null);
		}

		public override Func<T, object> CreateGet<T>(FieldInfo fieldInfo)
		{
			ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
			return (T o) => fieldInfo.GetValue(o);
		}

		public override MethodCall<T, object> CreateMethodCall<T>(MethodBase method)
		{
			ValidationUtils.ArgumentNotNull(method, "method");
			ConstructorInfo constructorInfo = method as ConstructorInfo;
			ConstructorInfo constructorInfo1 = constructorInfo;
			ConstructorInfo constructorInfo2 = constructorInfo;
			if (constructorInfo1 != null)
			{
				return (T o, object[] a) => constructorInfo2.Invoke(a);
			}
			return (T o, object[] a) => method.Invoke(o, a);
		}

		public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
		{
			ValidationUtils.ArgumentNotNull(method, "method");
			ConstructorInfo constructorInfo = method as ConstructorInfo;
			ConstructorInfo constructorInfo1 = constructorInfo;
			ConstructorInfo constructorInfo2 = constructorInfo;
			if (constructorInfo1 != null)
			{
				return (object[] a) => constructorInfo2.Invoke(a);
			}
			return (object[] a) => method.Invoke(null, a);
		}

		public override Action<T, object> CreateSet<T>(FieldInfo fieldInfo)
		{
			ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
			return (T o, object v) => fieldInfo.SetValue(o, v);
		}

		public override Action<T, object> CreateSet<T>(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			return (T o, object v) => propertyInfo.SetValue(o, v, null);
		}
	}
}