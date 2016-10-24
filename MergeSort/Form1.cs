using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            runProgram(10);
        }

        void runProgram(int size)
        {
            Random ran = new Random();
            int[] randomNums = new int[size];
            for (int i = 0; i < randomNums.Length; i++)
            {
                randomNums[i] = ran.Next(0, 10000);//Start Number, End Number
            }
            StringBuilder output = new StringBuilder("");
            output.Append("Input\n");
            for (int i = 0; i < randomNums.Length; i++)
            {
                output.Append(randomNums[i] + " ");
                if(i % 20 == 19)
                {
                    output.Append("\n");
                }
            }
            MergeSort(randomNums);
            output.Append("\nOutput\n");
            for (int i = 0; i < randomNums.Length; i++)
            {
                output.Append(randomNums[i] + " ");
                if (i % 20 == 19)
                {
                    output.Append("\n");
                }
            }
            OutputBox.Text = output.ToString();
        }

        void MergeSort(int[] toSort)
        {
            if (toSort.Length == 1)
            {
                return;
            }
            int oddAddition = 0;
            if (toSort.Length % 2 == 1)
            {
                oddAddition = 1;
            }
            int[] half1 = toSort.Take(toSort.Length/2 + oddAddition).ToArray();
            int[] half2 = toSort.Skip(toSort.Length/2 + oddAddition).ToArray();
            MergeSort(half1);
            MergeSort(half2);
            int h1c = 0;
            int h2c = 0;
            for (int i = 0; i < toSort.Length; i++)
            {
                if (half1[h1c] <= half2[h2c])
                {
                    toSort[i] = half1[h1c];
                    h1c++;
                }
                else
                {
                    toSort[i] = half2[h2c];
                    h2c++;
                }
                if (h1c == half1.Length)
                {
                    for (int j = 0; h2c < half2.Length; j++)
                    {
                        toSort[i + j + 1] = half2[h2c];
                        h2c++;
                    }
                    break;
                }
                if (h2c == half2.Length)
                {
                    for (int j = 0; h1c < half1.Length; j++)
                    {
                        toSort[i + j + 1] = half1[h1c];
                        h1c++;
                    }
                    break;
                }
            }

            return;
        }
    }
}
