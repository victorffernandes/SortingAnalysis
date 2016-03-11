using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingAnalysis
{
	public partial class Form1 : Form
	{
		ILinkedList b;
		public Form1()
		{
			int t = 10;
			InitializeComponent();
			b = new ILinkedList();

			add(t);
			//b.print();
			Console.WriteLine("Sorting " + t + " elements:");
			b.bubbleSort();
			//add new point
			//point x = t
			//point y = temp
			while(t <= 2000)
			{
				add(5);
				t += 5;
				//b.print();
				Console.WriteLine("Sorting " + t + " elements:");
				b.bubbleSort();
			}
			
		}
		void add(int t)
		{
			Random a = new Random();

			for(int i = 0; i < t; i++)
			{
				b.push(a.Next(0,2000));
			}
		}
	}
}
