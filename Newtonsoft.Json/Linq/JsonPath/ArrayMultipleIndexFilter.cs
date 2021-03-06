using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	internal class ArrayMultipleIndexFilter : PathFilter
	{
		public List<int> Indexes
		{
			get;
			set;
		}

		public ArrayMultipleIndexFilter()
		{
			Class6.yDnXvgqzyB5jw();
			base();
		}

		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			return new ArrayMultipleIndexFilter.<ExecuteFilter>d__4(-2)
			{
				<>4__this = this,
				<>3__current = current,
				<>3__errorWhenNoMatch = errorWhenNoMatch
			};
		}
	}
}