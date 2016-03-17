using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace SortingAnalysis
{
	public partial class Form1 : Form
	{
        List<int> b;
        float time = 0;
        public static float time2 = 0;
        DataPoint last;
        ILinkedList b2;
		public Form1()
		{
            b2 = new ILinkedList();
			InitializeComponent();
			b = new List<int>();
			
		}
		void add(int t)
		{
			Random a = new Random();

			for(int i = 0; i < t; i++)
			{
				b.Add(a.Next(0,2000));
			}
		}

        void addLL(int t)
        {
            Random a = new Random();

            for (int i = 0; i < t; i++)
            {
                b2.push(a.Next(0, 2000));
            }
        }
        public void bubbleSort(List<int> l)
        {
            Stopwatch msw = new Stopwatch();
            msw.Start();
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[i] < l[j])
                    {
                        int temp = l[i];
                        l[i] = l[j];
                        l[j] = temp;
                    }
                }
            }
            msw.Stop();
            time += msw.Elapsed.Milliseconds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b.Count < 2000)
            {
                add(10);
                bubbleSort(b);
                chart1.Series["Series1"].Points.AddXY(b.Count, time);
                last = chart1.Series["Series1"].Points[chart1.Series["Series1"].Points.Count - 1];
            }
            while (b.Count < 2000)
            {
                add(5);
                bubbleSort(b);
                last.Color = Color.Blue;
                chart1.Series["Series1"].Points.AddXY(b.Count, time);
                last = chart1.Series["Series1"].Points[chart1.Series["Series1"].Points.Count-1];
                last.Color = Color.Red;
                Refresh();
               
            }
            if (b.Count >= 2000)
            { 
                chart1.Series["Series1"].Color = Color.Green; 
                DataPointCollection collection = chart1.Series["Series1"].Points;
                foreach(DataPoint p in collection)
                {
                    p.Color = Color.Green;
                    Refresh();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                addLL(10);
                b2.bubbleSort();
                chart2.Series["Series1"].Points.AddXY(b2.Length, time2);
                last = chart2.Series["Series1"].Points[chart2.Series["Series1"].Points.Count - 1];
            
            while (b2.Length < 600)
            {
                addLL(5);
                b2.bubbleSort();
                last.Color = Color.Blue;
                chart2.Series["Series1"].Points.AddXY(b2.Length, time2);
                last = chart2.Series["Series1"].Points[chart2.Series["Series1"].Points.Count - 1];
                last.Color = Color.Red;
                Refresh();

            }
            if (b2.Length >= 600)
            {
                chart2.Series["Series1"].Color = Color.Green;
                DataPointCollection collection = chart2.Series["Series1"].Points;
                foreach (DataPoint p in collection)
                {
                    p.Color = Color.Green;
                    Refresh();
                }
            }
        }
	}
}
