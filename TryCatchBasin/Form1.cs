using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryCatchBasin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2;

            if (Double.TryParse(textBox1.Text, out num1) && Double.TryParse(textBox2.Text, out num2))
            {
                double answer = num1 / num2;
                MessageBox.Show(answer.ToString("N"));
            }
            else
            {
                MessageBox.Show("Please enter valid numbers", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(textBox1.Text);
                double num2 = Convert.ToDouble(textBox2.Text);
                double answer = num1 / num2;
                MessageBox.Show(answer.ToString("N"));
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Please enter valid numbers", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Some other error occured!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Python31\b.txt";

            try
            {
                StreamReader sr = new StreamReader(filepath);
                while (!sr.EndOfStream)
                {
                    MessageBox.Show(sr.ReadLine());
                }
                sr.Close();
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("File was not found - creating file now.");

                try
                {
                    StreamWriter sw = new StreamWriter(filepath);
                    sw.WriteLine("FirstLineInitialization");
                    sw.Close();
                }
                catch (Exception exception2)
                {
                    MessageBox.Show("Problem occured creating the file");
                }
            }
            catch (UnauthorizedAccessException exception)
            {
                MessageBox.Show("No Access Allowed");
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occured - " + exception.Message);
            }
            finally
            {

            }

        }
    }
}
