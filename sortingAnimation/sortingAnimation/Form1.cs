// Name: Quinton Tiller
//Disciption: This programe will allow the user to generate an array and then select a sorting 
// algorithm of their choice to watch step by step how it will sort the array.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortingAnimation
{

    public partial class Form1 : Form
    {
        int[] mainArray = new int[5];
        List<TextBox> myTextboxList = new List<TextBox>();
        

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;

        }

        //Generate Array Button
        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = GenerateArray();
            mainArray = array;
            string results = string.Join(".", array);

            textBox1.Text = results;

            textBox3.Text = results[0].ToString();
            textBox4.Text = results[2].ToString();
            textBox5.Text = results[4].ToString();
            textBox6.Text = results[6].ToString();
            textBox7.Text = results[8].ToString();

        }

        public int[] GenerateArray()
        {
            int Min = 0;
            int Max = 9;
            int[] array = new int[5];

            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(Min, Max);
            }
            return array;
        }

        //Selection Sort BUtton
        private void button2_Click(object sender, EventArgs e)
        {
            myTextboxList.Clear();
            myTextboxList.Add(textBox3);
            myTextboxList.Add(textBox4);
            myTextboxList.Add(textBox5);
            myTextboxList.Add(textBox6);
            myTextboxList.Add(textBox7);
            timer1.Enabled = true;
            pictureBox1.Top = textBox3.Bottom;
            pictureBox1.Left = textBox3.Left;
            pictureBox2.Top = textBox4.Bottom;
            pictureBox2.Left = textBox4.Left;
        }

        //Assening button
        private void button3_Click(object sender, EventArgs e)
        {
            int[] array = GenerateArray();
            Array.Sort(array);

            string results = string.Join(".", array);

            textBox1.Text = results;

            textBox3.Text = results[0].ToString();
            textBox4.Text = results[2].ToString();
            textBox5.Text = results[4].ToString();
            textBox6.Text = results[6].ToString();
            textBox7.Text = results[8].ToString();
        }
        //Desending Button
        private void button4_Click(object sender, EventArgs e)
        {
            int[] array = GenerateArray();
            Array.Sort(array);
            Array.Reverse(array);

            string results = string.Join(".", array);

            textBox1.Text = results;

            textBox3.Text = results[0].ToString();
            textBox4.Text = results[2].ToString();
            textBox5.Text = results[4].ToString();
            textBox6.Text = results[6].ToString();
            textBox7.Text = results[8].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // One by one move boundary of unsorted subarray

            for (int i = 0; i < myTextboxList.Count - 1; i++)
            {

                // Find the minimum element in unsorted array 
                int min_idx = i;



                highlightSmallest(i);


                for (int j = i + 1; j < myTextboxList.Count; j++)


                    if (int.Parse(myTextboxList[j].Text) < int.Parse(myTextboxList[min_idx].Text))
                    {
                        min_idx = j;

                    }
                highlightswap(min_idx);


                // Swap the found minimum element with the first 
                // element 
                int temp = int.Parse(myTextboxList[min_idx].Text);
                myTextboxList[min_idx].Text = myTextboxList[i].Text;
                myTextboxList[i].Text = temp.ToString();



            }
            timer1.Enabled = false;
        }
        //InsertionSort Button
        private void button5_Click(object sender, EventArgs e)
        {
            myTextboxList.Clear();
            myTextboxList.Add(textBox3);
            myTextboxList.Add(textBox4);
            myTextboxList.Add(textBox5);
            myTextboxList.Add(textBox6);
            myTextboxList.Add(textBox7);
            timer2.Enabled = true;
            pictureBox1.Top = textBox3.Bottom;
            pictureBox1.Left = textBox3.Left;
            pictureBox2.Top = textBox4.Bottom;
            pictureBox2.Left = textBox4.Left;
        }
        public void highlightSmallest(int i)
        {

            if (i == 0)
            {
                pictureBox1.Top = textBox3.Bottom;
            }
            if (i == 1)
            {
                pictureBox1.Top = textBox4.Bottom;
                pictureBox1.Left = textBox4.Left;
            }
            if (i == 2)
            {
                pictureBox1.Top = textBox5.Bottom;
                pictureBox1.Left = textBox5.Left;
            }
            if (i == 3)
            {
                pictureBox1.Top = textBox6.Bottom;
                pictureBox1.Left = textBox6.Left;
            }
            if (i == 4)
            {
                pictureBox1.Top = textBox7.Bottom;
                pictureBox1.Left = textBox7.Left;
            }
            int count = 0;
            if (timer1.Enabled == true) {
                timer1.Enabled = false;
                count = 1;
            }
            else if (timer2.Enabled == true) {
                timer2.Enabled = false;
                count = 2;
            }
            else if (timer3.Enabled == true) {
                timer3.Enabled = false;
                count = 3;
            }
            else if (timer4.Enabled == true) {

                timer4.Enabled = false;
                count = 4;
            }
            DialogResult res = MessageBox.Show("Step", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                if (count == 1)
                    timer1.Enabled = true;
                else if (count == 2)
                    timer2.Enabled = true;
                else if (count == 3)
                    timer3.Enabled = true;
                else if (count == 4)
                    timer4.Enabled = true;
                
            }
            if (res == DialogResult.Cancel)
            {
                Environment.Exit(0);

            }


        }
        public void highlightswap(int j)
        {

            if (j == 1)
            {
                pictureBox2.Top = textBox4.Bottom;
                pictureBox2.Left = textBox4.Left;
            }
            if (j == 2)
            {
                pictureBox2.Top = textBox5.Bottom;
                pictureBox2.Left = textBox5.Left;
            }
            if (j == 3)
            {
                pictureBox2.Top = textBox6.Bottom;
                pictureBox2.Left = textBox6.Left;
            }
            if (j == 4)
            {
                pictureBox2.Top = textBox7.Bottom;
                pictureBox2.Left = textBox7.Left;
            }
            int count = 0;
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                count = 1;
            }
            else if (timer2.Enabled == true)
            {
                timer2.Enabled = false;
                count = 2;
            }
            else if (timer3.Enabled == true)
            {
                timer3.Enabled = false;
                count = 3;
            }
            else if (timer4.Enabled == true)
            {
                timer4.Enabled = false;
                count = 4;
            }

            DialogResult res = MessageBox.Show("Step", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                if (count == 1)
                    timer1.Enabled = true;
                else if (count == 2)
                    timer2.Enabled = true;
                else if (count == 3)
                    timer3.Enabled = true;
                else if (count == 4)
                    timer4.Enabled = true;
            }
            if (res == DialogResult.Cancel)
            {
                Environment.Exit(0);

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < myTextboxList.Count - 1; i++)
            {
                highlightSmallest(i);
                for (int j = i + 1; j > 0; j--)
                {
                    highlightswap(j);
                    if (int.Parse(myTextboxList[j - 1].Text) > int.Parse(myTextboxList[j].Text))
                    {
                        int temp = int.Parse(myTextboxList[j - 1].Text);
                        myTextboxList[j - 1].Text = myTextboxList[j].Text;
                        myTextboxList[j].Text = temp.ToString();
                    }
                }
            }
            timer2.Enabled = false;
        }
        //ShellSort Button
        private void button6_Click(object sender, EventArgs e)
        {
            myTextboxList.Clear();
            myTextboxList.Add(textBox3);
            myTextboxList.Add(textBox4);
            myTextboxList.Add(textBox5);
            myTextboxList.Add(textBox6);
            myTextboxList.Add(textBox7);
            timer3.Enabled = true;
            pictureBox1.Top = textBox3.Bottom;
            pictureBox1.Left = textBox3.Left;
            pictureBox2.Top = textBox4.Bottom;
            pictureBox2.Left = textBox4.Left;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int n = myTextboxList.Count;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already in gapped order 
                // keep adding one more element until the entire array is 
                // gap sorted  
                for (int i = gap; i < n; i += 1)
                {
                    highlightSmallest(i);
                    // add a[i] to the elements that have been gap sorted 
                    // save a[i] in temp and make a hole at position i 
                    int temp = int.Parse(myTextboxList[i].Text);

                    // shift earlier gap-sorted elements up until the correct  
                    // location for a[i] is found 
                    int j;
                    for (j = i; j >= gap && int.Parse(myTextboxList[j - gap].Text) > temp; j -= gap)
                        myTextboxList[j].Text = myTextboxList[j - gap].Text;
                    highlightswap(j);

                    //  put temp (the original a[i]) in its correct location 
                    myTextboxList[j].Text = temp.ToString();
                }
            }
            timer3.Enabled = false;
        }
        //BubbleSort Button
        private void button7_Click(object sender, EventArgs e)
        {
            myTextboxList.Clear();
            myTextboxList.Add(textBox3);
            myTextboxList.Add(textBox4);
            myTextboxList.Add(textBox5);
            myTextboxList.Add(textBox6);
            myTextboxList.Add(textBox7);
            timer4.Enabled = true;
            pictureBox1.Top = textBox3.Bottom;
            pictureBox1.Left = textBox3.Left;
            pictureBox2.Top = textBox4.Bottom;
            pictureBox2.Left = textBox4.Left;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int n = myTextboxList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                highlightSmallest(i);
                for (int j = 0; j < n - i - 1; j++)
                {
                    highlightswap(j);
                    if (int.Parse(myTextboxList[j].Text) > int.Parse(myTextboxList[j + 1].Text))
                    {
                        // swap temp and arr[i] 
                        int temp = int.Parse(myTextboxList[j].Text);
                        myTextboxList[j].Text = myTextboxList[j + 1].Text;
                        myTextboxList[j + 1].Text = temp.ToString();
                    }
                }
            }
            timer4.Enabled = false;
        }
    }
}

