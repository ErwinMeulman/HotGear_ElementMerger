using Autodesk.Revit.DB;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Facet.Combinatorics
{
	public class Variations<T> : IMetaCollection<T>, IEnumerable<IList<T>>, IEnumerable
	{
		public class EnumeratorWithRepetition : IEnumerator<IList<T>>, IDisposable, IEnumerator
		{
			private Variations<T> myParent;

			private List<T> myCurrentList;

			private List<int> myListIndexes;

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

			public EnumeratorWithRepetition(Variations<T> source)
			{
				this.myParent = source;
				this.Reset();
			}

			public void Reset()
			{
				this.myCurrentList = null;
				this.myListIndexes = null;
			}

			public bool MoveNext()
			{
				int num = 1;
				if (this.myListIndexes == null)
				{
					this.myListIndexes = new List<int>();
					for (int i = 0; i < this.myParent.LowerIndex; i++)
					{
						this.myListIndexes.Add(0);
					}
					num = 0;
				}
				else
				{
					int num2 = this.myListIndexes.Count - 1;
					while (num2 >= 0 && num > 0)
					{
						List<int> list = this.myListIndexes;
						int index = num2;
						list[index] += num;
						num = 0;
						if (this.myListIndexes[num2] >= this.myParent.UpperIndex)
						{
							this.myListIndexes[num2] = 0;
							num = 1;
						}
						num2--;
					}
				}
				this.myCurrentList = null;
				return num != 1;
			}

			public void Dispose()
			{
			}

			private void ComputeCurrent()
			{
				if (this.myCurrentList == null)
				{
					this.myCurrentList = new List<T>();
					foreach (int myListIndex in this.myListIndexes)
					{
						this.myCurrentList.Add(this.myParent.myValues[myListIndex]);
					}
				}
			}
		}

		public class EnumeratorWithoutRepetition : IEnumerator<IList<T>>, IDisposable, IEnumerator
		{
			private Variations<T> myParent;

			private List<T> myCurrentList;

			private Permutations<int>.Enumerator myPermutationsEnumerator;

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

			public EnumeratorWithoutRepetition(Variations<T> source)
			{
				this.myParent = source;
				this.myPermutationsEnumerator = (Permutations<int>.Enumerator)this.myParent.myPermutations.GetEnumerator();
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
					IList<int> list = (IList<int>)this.myPermutationsEnumerator.Current;
					for (int i = 0; i < this.myParent.LowerIndex; i++)
					{
						this.myCurrentList.Add(this.myParent.myValues[0]);
					}
					for (int j = 0; j < list.Count; j++)
					{
						int num2 = list[j];
						if (num2 != 2147483647)
						{
							this.myCurrentList[num2] = this.myParent.myValues[num];
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

		private Permutations<int> myPermutations;

		private GenerateOption myMetaCollectionType;

		private int myLowerIndex;

		private IList<Element> pickedElements;

		public long Count
		{
			get
			{
				if (this.Type == GenerateOption.WithoutRepetition)
				{
					return this.myPermutations.Count;
				}
				return (long)Math.Pow((double)this.UpperIndex, (double)this.LowerIndex);
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

		protected Variations()
		{
		}

		public Variations(IList<T> values, int lowerIndex)
		{
			this.Initialize(values, lowerIndex, GenerateOption.WithoutRepetition);
		}

		public Variations(IList<T> values, int lowerIndex, GenerateOption type)
		{
			this.Initialize(values, lowerIndex, type);
		}

		public Variations(IList<Element> pickedElements)
		{
			this.pickedElements = pickedElements;
		}

		public IEnumerator<IList<T>> GetEnumerator()
		{
			if (this.Type == GenerateOption.WithRepetition)
			{
				return new EnumeratorWithRepetition(this);
			}
			return new EnumeratorWithoutRepetition(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (this.Type == GenerateOption.WithRepetition)
			{
				return new EnumeratorWithRepetition(this);
			}
			return new EnumeratorWithoutRepetition(this);
		}

		private void Initialize(IList<T> values, int lowerIndex, GenerateOption type)
		{
			this.myMetaCollectionType = type;
			this.myLowerIndex = lowerIndex;
			this.myValues = new List<T>();
			this.myValues.AddRange(values);
			if (type == GenerateOption.WithoutRepetition)
			{
				List<int> list = new List<int>();
				int num = 0;
				for (int i = 0; i < this.myValues.Count; i++)
				{
					if (i >= this.myValues.Count - this.myLowerIndex)
					{
						list.Add(num++);
					}
					else
					{
						list.Add(2147483647);
					}
				}
				this.myPermutations = new Permutations<int>(list);
			}
		}
	}
}
