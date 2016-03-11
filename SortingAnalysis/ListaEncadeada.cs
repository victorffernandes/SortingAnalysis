using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAnalysis
{
	#region Element Class
	class Element
	{
		public int data;
		public Element successor = null;

		public Element(int d)
		{
			data = d;
		}
	}
	#endregion


	class ILinkedList
	{
		Element root;

		#region Print All Elements Method
		public void print()
		{
			Element actual = root;
			do
			{
				Console.WriteLine(actual.data);
				actual = actual.successor;
			}
			while (actual.successor != null);
			Console.WriteLine(actual.data);
		}
		#endregion

		#region Length Method
		public int getLength()
		{
			Element actual = root;
			int i = 1;
			while (actual.successor != null)
			{
				i++;
				actual = actual.successor;
			}
			if (root == null) return 0;
			else return i;
		}

		public int Length
		{
			get
			{
				return getLength();
			}
		}

		#endregion

		#region Overload Remove Methods
		public void Remove(int index)
		{
			Element a = root;
			Element b = null;
			if (index != 0)
			{
				for (int i = 0; i < index; i++)
				{
					b = a;
					a = a.successor;
				}
				if (a.successor != null) b.successor = a.successor;
				else b.successor = null;
			}
			else
			{
				root = root.successor;
			}
		}

		//public void Remove(int value, string inutil)
		//{
		//	Element a = root;
		//	Element b = null; 
		//	if (!root.data.Equals(value))
		//	{
		//		while (a.successor != null)
		//		{
		//			if (a.data.Equals(value))
		//			{
		//				b.successor = a.successor;
		//			}
		//			b = a;
		//			a = a.successor;
		//		}
		//		if (a.successor != null) b.successor = a.successor;
		//		else b.successor = null;
		//	}
		//	else
		//	{
		//		root = root.successor;
		//	}
		//}
		#endregion

		#region Methods

		public void AddAfterValue(int sort, int value)
		{
			Element a = root;
			Element New = new Element(value);
			while (a.successor != null)
			{
				if (a.data.Equals(sort))
				{
					New.successor = a.successor;
					a.successor = New;
				}
				a = a.successor;
			}
		}

		public void AddAtBeggining(int value)
		{
			Element g = new Element(value);
			g.successor = root;
			root = g;
		}

		public void InsertAt(int index, int value)
		{
			if (index == 0) AddAtBeggining(value);
			else if (getLength() - 1 == index) push(value);
			else
			{
				Element a = root;
				Element b = null;
				Element c = new Element(value);
				for (int i = 0; i < index; i++)
				{
					b = a;
					a = a.successor;
				}
				b.successor = c;
				c.successor = a;
			}
		}

		public Element getItem(int index)
		{
			Element a = root;
			for (int i = 0; i < index; i++)
			{
				a = a.successor;
			}
			return a;
		}

		public void push(int i)
		{
			if (root == null)
			{
				root = new Element(i);
			}
			else
			{
				Element actual = root;
				while (actual.successor != null)
				{
					actual = actual.successor;
				}
				actual.successor = new Element(i);
			}
		}

		public void SwitchPosition(int p1, int p2)
		{
			Element e1 = getItem(p1);
			Element e2 = getItem(p2);
			int temp = e1.data;

			e1.data = e2.data;
			e2.data = temp;
		}

		#endregion 

		#region Sorting Methods

		public void bubbleSort() {
			Stopwatch msw = new Stopwatch();
			msw.Start();
				for (int i = 0; i < this.Length; i++) {
					for (int j = i + 1; j < this.Length; j++) {
						if (this.getItem(i).data < this.getItem(j).data) {
							SwitchPosition(i,j);
						}
					}
				}
			//print();
			msw.Stop();
			Console.WriteLine(msw.Elapsed);
		}

	#endregion
	}
}