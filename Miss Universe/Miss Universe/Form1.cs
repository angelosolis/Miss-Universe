using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Miss_Universe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            // Open the text file using a stream reader
            using (StreamReader sr = new StreamReader(@"Top20.txt"))
            {
                string line;

                // Read the file line by line and add each line as an item to the list box
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }
        }


        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {

                string selectedItem = listBox1.SelectedItem.ToString();

  
                if (listBox2.Items.Count == 10)
                {
                    MessageBox.Show("Top 10 is full.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                listBox1.Items.Remove(selectedItem);
                listBox2.Items.Add(selectedItem);
            }

            if (listBox2.Items.Count == 10)
            {
                listBox1.Enabled = false;
            }


        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                listBox2.Items.Remove(selectedItem);
                listBox3.Items.Add(selectedItem);

                if (listBox3.Items.Count == 3)
                {
                    MessageBox.Show("Top 3 is full.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            if (listBox3.Items.Count == 3)
            {
                listBox2.Enabled = false;
            }
        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {

                string selectedItem = listBox3.SelectedItem.ToString();
                listBox3.Items.Remove(selectedItem);
                listBox4.Items.Add(selectedItem);

                MessageBox.Show(selectedItem + " is the Miss Universe!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (listBox4.Items.Count == 1)
            {
                listBox3.Enabled = false;
            }
        }
        private void SaveListBoxToFile(ListBox listBox, string fileName)
        {
            // Open the file for writing using a stream writer
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                // Write each item in the list box to a new line in the file
                foreach (string item in listBox.Items)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                string fileName = "Top10.txt";

                // Save the list box items to the file
                SaveListBoxToFile(listBox2, fileName);

                // Show a message dialog to confirm that the file has been saved
                MessageBox.Show("Success!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The list is empty. Nothing to print.");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != 0)
            {
                string fileName = "Top3.txt";

                // Save the list box items to the file
                SaveListBoxToFile(listBox3, fileName);

                // Show a message dialog to confirm that the file has been saved
                MessageBox.Show("Success!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The list is empty. Nothing to print.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox4.Items.Count != 0)
            {
                string fileName = "MissUniverse.txt";

                // Save the list box items to the file
                SaveListBoxToFile(listBox4, fileName);

                // Show a message dialog to confirm that the file has been saved
                MessageBox.Show("Success!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The list is empty. Nothing to print.");
                return;
            }
        }

         private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            



        }

    }
}
