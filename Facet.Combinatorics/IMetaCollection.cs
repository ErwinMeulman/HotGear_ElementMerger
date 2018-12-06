using System.Collections;
using System.Collections.Generic;

namespace Facet.Combinatorics
{
	internal interface IMetaCollection<T> : IEnumerable<IList<T>>, IEnumerable
	{
		long Count
		{
			get;
		}

		GenerateOption Type
		{
			get;
		}

		int UpperIndex
		{
			get;
		}

		int LowerIndex
		{
			get;
		}
	}
}
