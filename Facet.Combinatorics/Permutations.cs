using System;
using System.Collections;
using System.Collections.Generic;

namespace Facet.Combinatorics
{
	public class Permutations<T> : IMetaCollection<T>, IEnumerable<IList<T>>, IEnumerable
	{
		public class Enumerator : IEnumerator<IList<T>>, IDisposable, IEnumerator
		{
			private enum Position
			{
				BeforeFirst,
				InSet,
				AfterLast
			}

			private T myTemp;

			private int myKviTemp;

			private Position myPosition = Position.BeforeFirst;

			private int[] myLexicographicalOrders;

			private List<T> myValues;

			private Permutations<T> myParent;

			public object Current
			{
				get
				{
					if (this.myPosition == Position.InSet)
					{
						return new List<T>(this.myValues);
					}
					throw new InvalidOperationException();
				}
			}

			IList<T> IEnumerator<IList<T>>.Current
			{
				get
				{
					if (this.myPosition == Position.InSet)
					{
						return new List<T>(this.myValues);
					}
					throw new InvalidOperationException();
				}
			}

			public Enumerator(Permutations<T> source)
			{
				this.myParent = source;
				this.myLexicographicalOrders = new int[source.myLexicographicOrders.Length];
				source.myLexicographicOrders.CopyTo(this.myLexicographicalOrders, 0);
				this.Reset();
			}

			public void Reset()
			{
				this.myPosition = Position.BeforeFirst;
			}

			public bool MoveNext()
			{
				if (this.myPosition == Position.BeforeFirst)
				{
					this.myValues = new List<T>(this.myParent.myValues.Count);
					this.myValues.AddRange(this.myParent.myValues);
					Array.Sort<int>(this.myLexicographicalOrders);
					this.myPosition = Position.InSet;
				}
				else if (this.myPosition == Position.InSet)
				{
					if (this.myValues.Count < 2)
					{
						this.myPosition = Position.AfterLast;
					}
					else if (!this.NextPermutation())
					{
						this.myPosition = Position.AfterLast;
					}
				}
				return this.myPosition != Position.AfterLast;
			}

			public virtual void Dispose()
			{
			}

			private bool NextPermutation()
			{
				int num = this.myLexicographicalOrders.Length - 1;
				while (this.myLexicographicalOrders[num - 1] >= this.myLexicographicalOrders[num])
				{
					num--;
					if (num == 0)
					{
						return false;
					}
				}
				int num2 = this.myLexicographicalOrders.Length;
				while (this.myLexicographicalOrders[num2 - 1] <= this.myLexicographicalOrders[num - 1])
				{
					num2--;
				}
				this.Swap(num - 1, num2 - 1);
				num++;
				num2 = this.myLexicographicalOrders.Length;
				while (num < num2)
				{
					this.Swap(num - 1, num2 - 1);
					num++;
					num2--;
				}
				return true;
			}

			private void Swap(int i, int j)
			{
				this.myTemp = this.myValues[i];
				this.myValues[i] = this.myValues[j];
				this.myValues[j] = this.myTemp;
				this.myKviTemp = this.myLexicographicalOrders[i];
				this.myLexicographicalOrders[i] = this.myLexicographicalOrders[j];
				this.myLexicographicalOrders[j] = this.myKviTemp;
			}
		}

		private class SelfComparer<U> : IComparer<U>
		{
			public int Compare(U x, U y)
			{
				return ((IComparable<U>)(object)x).CompareTo(y);
			}
		}

		private List<T> myValues;

		private int[] myLexicographicOrders;

		private long myCount;

		private GenerateOption myMetaCollectionType;

		public long Count
		{
			get
			{
				return this.myCount;
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
				return this.myValues.Count;
			}
		}

		protected Permutations()
		{
		}

		public Permutations(IList<T> values)
		{
			this.Initialize(values, GenerateOption.WithoutRepetition, null);
		}

		public Permutations(IList<T> values, GenerateOption type)
		{
			this.Initialize(values, type, null);
		}

		public Permutations(IList<T> values, IComparer<T> comparer)
		{
			this.Initialize(values, GenerateOption.WithoutRepetition, comparer);
		}

		public virtual IEnumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<IList<T>> IEnumerable<IList<T>>.GetEnumerator()
		{
			return new Enumerator(this);
		}

		private void Initialize(IList<T> values, GenerateOption type, IComparer<T> comparer)
		{
			this.myMetaCollectionType = type;
			this.myValues = new List<T>(values.Count);
			this.myValues.AddRange(values);
			this.myLexicographicOrders = new int[values.Count];
			if (type == GenerateOption.WithRepetition)
			{
				for (int i = 0; i < this.myLexicographicOrders.Length; i++)
				{
					this.myLexicographicOrders[i] = i;
				}
			}
			else
			{
				if (comparer == null)
				{
					comparer = new SelfComparer<T>();
				}
				this.myValues.Sort(comparer);
				int num = 1;
				if (this.myLexicographicOrders.Length != 0)
				{
					this.myLexicographicOrders[0] = num;
				}
				for (int j = 1; j < this.myLexicographicOrders.Length; j++)
				{
					if (comparer.Compare(this.myValues[j - 1], this.myValues[j]) != 0)
					{
						num++;
					}
					this.myLexicographicOrders[j] = num;
				}
			}
			this.myCount = this.GetCount();
		}

		private long GetCount()
		{
			int num = 1;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 1; i < this.myLexicographicOrders.Length; i++)
			{
				list2.AddRange(SmallPrimeUtility.Factor(i + 1));
				if (this.myLexicographicOrders[i] == this.myLexicographicOrders[i - 1])
				{
					num++;
				}
				else
				{
					for (int j = 2; j <= num; j++)
					{
						list.AddRange(SmallPrimeUtility.Factor(j));
					}
					num = 1;
				}
			}
			for (int k = 2; k <= num; k++)
			{
				list.AddRange(SmallPrimeUtility.Factor(k));
			}
			return SmallPrimeUtility.EvaluatePrimeFactors(SmallPrimeUtility.DividePrimeFactors(list2, list));
		}
	}
}
