using System;
using System.Collections;
using System.Collections.Generic;

namespace Facet.Combinatorics
{
	public class Combinations<T> : IMetaCollection<T>, IEnumerable<IList<T>>, IEnumerable
	{
		public class Enumerator : IEnumerator<IList<T>>, IDisposable, IEnumerator
		{
			private Combinations<T> myParent;

			private List<T> myCurrentList;

			private Permutations<bool>.Enumerator myPermutationsEnumerator;

			public IList<T> Current
			{
				get
				{
					this.ComputeCurrent();
					return this.myCurrentList;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					this.ComputeCurrent();
					return this.myCurrentList;
				}
			}

			public Enumerator(Combinations<T> source)
			{
				this.myParent = source;
				this.myPermutationsEnumerator = (Permutations<bool>.Enumerator)this.myParent.myPermutations.GetEnumerator();
			}

			public void Reset()
			{
				this.myPermutationsEnumerator.Reset();
			}

			public bool MoveNext()
			{
				bool result = this.myPermutationsEnumerator.MoveNext();
				this.myCurrentList = null;
				return result;
			}

			public void Dispose()
			{
			}

			private void ComputeCurrent()
			{
				if (this.myCurrentList == null)
				{
					this.myCurrentList = new List<T>();
					int num = 0;
					IList<bool> list = (IList<bool>)this.myPermutationsEnumerator.Current;
					for (int i = 0; i < list.Count; i++)
					{
						if (!list[i])
						{
							this.myCurrentList.Add(this.myParent.myValues[num]);
							if (this.myParent.Type == GenerateOption.WithoutRepetition)
							{
								num++;
							}
						}
						else
						{
							num++;
						}
					}
				}
			}
		}

		private List<T> myValues;

		private Permutations<bool> myPermutations;

		private GenerateOption myMetaCollectionType;

		private int myLowerIndex;

		public long Count
		{
			get
			{
				return this.myPermutations.Count;
			}
		}

		public GenerateOption Type
		{
			get
			{
				return this.myMetaCollectionType;
			}
		}

		public int UpperIndex
		{
			get
			{
				return this.myValues.Count;
			}
		}

		public int LowerIndex
		{
			get
			{
				return this.myLowerIndex;
			}
		}

		protected Combinations()
		{
		}

		public Combinations(IList<T> values, int lowerIndex)
		{
			this.Initialize(values, lowerIndex, GenerateOption.WithoutRepetition);
		}

		public Combinations(IList<T> values, int lowerIndex, GenerateOption type)
		{
			this.Initialize(values, lowerIndex, type);
		}

		public IEnumerator<IList<T>> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		private void Initialize(IList<T> values, int lowerIndex, GenerateOption type)
		{
			this.myMetaCollectionType = type;
			this.myLowerIndex = lowerIndex;
			this.myValues = new List<T>();
			this.myValues.AddRange(values);
			List<bool> list = new List<bool>();
			if (type == GenerateOption.WithoutRepetition)
			{
				for (int i = 0; i < this.myValues.Count; i++)
				{
					if (i >= this.myValues.Count - this.myLowerIndex)
					{
						list.Add(false);
					}
					else
					{
						list.Add(true);
					}
				}
			}
			else
			{
				for (int j = 0; j < values.Count - 1; j++)
				{
					list.Add(true);
				}
				for (int k = 0; k < this.myLowerIndex; k++)
				{
					list.Add(false);
				}
			}
			this.myPermutations = new Permutations<bool>(list);
		}
	}
}
