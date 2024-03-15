using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        konus_class conus1 = new konus_class(2, 15);
        konus_class conus2 = new konus_class();
        konus_class conus3 = new konus_class(8, 10);
        konus_class Not_name;
        private bool flag = false;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// A class for calculating the diameter and volume of a straight cone.
        /// </summary>
        public class konus_class
        {
            private double radius;
            private double height;

            public konus_class(double radius, double height)
            {
                this.radius = radius; this.height = height;
            }
            public konus_class(double radius)
            {
                this.radius = radius;
            }
            public konus_class()
            {
                radius = 0;
                height = 0;
            }
            public double Calcul_Diameter()
            {
                return 2 * radius;
            }

            public double Calcul_Volume()
            {
                return (Math.PI * Math.Pow(radius, 2) * height) / 3;
            }
            public void SetRadius(double rad)
            {
                if (rad < 0)
                {
                    MessageBox.Show("Введите не отрицательное число");
                }
                else 
                {
                    radius = rad;
                }
            }
            public void SetHeight( double len_height) 
            {
                if (len_height < 0)
                {
                    MessageBox.Show("Введите не отрицательное число");
                }
                if (len_height < 9 || len_height > 30)
                {
                    MessageBox.Show("Введите число больше 9 и меньше 30 (для высоты) ");
                }
                else
                {
                    height = len_height;
                }
            }
            public double GetRadius()
            {
                return radius;
            }
            public double GetHeight()
            {
                return height;
            }
        }


        private void buttonDiam_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                textBox3.Text = Not_name.Calcul_Diameter().ToString();
                return;
            }

            double radius;
            if (double.TryParse(textBox1.Text, out radius))
            {
                if (radius > 0)
                {
                    konus_class cone = new konus_class(radius);
                    textBox3.Text = cone.Calcul_Diameter().ToString();
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение радиуса");
                }
            }
            else
            {
                MessageBox.Show("Не введено значение радиуса");
            }
        }

        private void buttonVolume_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                textBox4.Text = Not_name.Calcul_Volume().ToString();
                return;
            }

            double radius, height;
            if (double.TryParse(textBox1.Text, out radius) && double.TryParse(textBox2.Text, out height))
            {
                if (radius >= 0)
                {
                    if (height > 9 && height < 30)
                    {
                        konus_class cone = new konus_class(radius, height);
                        textBox4.Text = cone.Calcul_Volume().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Значение высоты должно быть от 9 до 30");
                    }
                }
                else
                {
                    MessageBox.Show("Введите неотрицательное значение для радиуса");
                }
            }
            else
            {
                MessageBox.Show("Не все значения введены");
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            flag = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            double radius;
            double height;
            if (double.TryParse(textBox1.Text, out radius) && double.TryParse(textBox2.Text, out height))
            {
                Not_name = new konus_class();
                Not_name.SetRadius(radius);
                Not_name.SetHeight(height);
            }
            if (radioButton1.Checked)
            {
                conus1 = Not_name;
            }
            if (radioButton2.Checked)
            {
                conus2 = Not_name;
            }
            if (radioButton3.Checked)
            {
                conus3 = Not_name;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                textBox1.Text = Not_name.GetRadius().ToString();
                textBox2.Text = Not_name.GetHeight().ToString();
                double radius;
                double height;
                if (double.TryParse(textBox1.Text, out radius) && double.TryParse(textBox2.Text, out height))
                {
                    if (radius >= 0)
                    {
                        if (height > 9 && height < 30)
                        {
                            textBox3.Text = Not_name.Calcul_Diameter().ToString();
                            textBox4.Text = Not_name.Calcul_Volume().ToString();
                        }
                        else
                        {
                            MessageBox.Show("Значение высоты должны от 9 до 30");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите неотрицательное значение для радиуса");
                    }

                }
                else
                {
                    MessageBox.Show("Не все значения введены или введены некорректно");
                }
            }
            else
            {
                MessageBox.Show("Выберите объект");
            }
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Not_name = conus1;
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                Not_name = conus2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                Not_name = conus3;
        }
    }
}
