using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        public void addInfo()
        {
            students.Add(new Student { name = "Иванов Егор", recordBook = "20221085", groupName = "131б-ПИо", department = "ИТНиТ", specification = "Прикладная информатика", dateOfAdmission = new DateTime(2022, 09, 01) });
            students.Add(new Student { name = "Хмельницкий Роман", recordBook = "20227777", groupName = "131б-ПИо", department = "ИТНиТ", specification = "Прикладная информатика", dateOfAdmission = new DateTime(2022, 09, 01) });
            students.Add(new Student { name = "Шмалько Иван", recordBook = "20221255", groupName = "131б-ПИо", department = "ИТНиТ", specification = "Прикладная информатика", dateOfAdmission = new DateTime(2022, 09, 01) });
            students.Add(new Student { name = "Уткин Венедикт", recordBook = "20224465", groupName = "131б-ПИо", department = "ИТНиТ", specification = "Прикладная информатика", dateOfAdmission = new DateTime(2022, 09, 01) });
            students.Add(new Student { name = "Попов Арсений", recordBook = "20224516", groupName = "131б-ПИо", department = "ИТНиТ", specification = "Прикладная информатика", dateOfAdmission = new DateTime(2022, 09, 01) });
            dataGridView1.DataSource = students;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addInfo();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                textBox2.Text = row.Cells["recordBookDataGridViewTextBoxColumn"].Value.ToString();
                comboBox1.Text = row.Cells["groupNameDataGridViewTextBoxColumn"].Value.ToString();
                comboBox2.Text = row.Cells["departmentDataGridViewTextBoxColumn"].Value.ToString();
                textBox5.Text = row.Cells["specificationDataGridViewTextBoxColumn"].Value.ToString();
                dateTimePicker1.Text = row.Cells["dateOfAdmissionDataGridViewTextBoxColumn"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    public class Student
    {
        public string name { get; set; }
        public string recordBook {  get; set; }
        public string groupName { get; set; }
        public string department { get; set; }
        public string specification { get; set; }
        public DateTime dateOfAdmission {  get; set; }
    }
}
