using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || comboBox1.SelectedText != "" || comboBox2.SelectedText != "" || comboBox3.SelectedText != "" || dateTimePicker1.Text != "")
            {
                new Student { name = textBox1.Text, recordBook = textBox2.Text, groupName = comboBox1.SelectedItem.ToString(), department = comboBox2.SelectedItem.ToString(), specification = comboBox3.SelectedItem.ToString(), dateOfAdmission = dateTimePicker1.Value };
            }
            else
            {
                MessageBox.Show("Заполните все данные!");
            }
        }
    }
}
