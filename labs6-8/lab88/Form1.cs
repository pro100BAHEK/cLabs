using lab88.Model;
using lab88.Presenter;
using lab88.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab88
{
    public partial class Form1 : Form, lab8View
    {
        public string StudentName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public int RecordBook
        {
            get { return int.Parse(textBox2.Text); }
            set { textBox2.Text = value.ToString(); }
        }

        public string Department
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = value; }
        }

        public string Specification
        {
            get { return comboBox2.SelectedItem.ToString(); }
            set { comboBox2.SelectedItem = value; }
        }

        public DateTime DateOfAdmission
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public string Group
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }

        public int Id { get; set; }

        public event EventHandler AddStudent;
        public event EventHandler UpdateStudent;
        public event EventHandler DeleteStudent;
        public event EventHandler ViewStudents;

        public void DisplayStudents(DataTable students)
        {
            dataGridView1.DataSource = students;
        }

        public Form1()
        {
            InitializeComponent();

            var model = new StudentModel();
            var presenter = new lab8Presenter(this, model);

            button2.Click += (s, e) => ViewStudents?.Invoke(s, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                Id = id;
                DeleteStudent?.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                Id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                UpdateStudent?.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show("Выберите студента для изменения");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab8DataSet.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.lab8DataSet.Students);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] college = { $"Сетевое и системное администрирование", 
                                "Информационные системы и программирование", 
                                "Обеспечение информационной безопасности автоматизированных систем", 
                                "Экономика и бухгалтерский учет (по отраслям)", 
                                "Право и организация социального обеспечения", 
                                "Юриспруденция" };
            string[] gum = { $"Международные отношения",
                            "Публичная политика и социальные науки", 
                            "Реклама и связи с общественностью", 
                            "Журналистика", 
                            "Педагогическое образование с двумя профилями подготовки", 
                            "Филология" };
            string[] est = { $"Химия", 
                            "Геология", 
                            "Картография и геоинформатика", 
                            "Экология и природопользование", 
                            "Биология", 
                            "Педагогическое образование (с двумя профилями подготовки)" };
            string[] lang = { $"Педагогическое образование", 
                             "Педагогическое образование (с двумя профилями подготовки)", 
                             "Лингвистика" };
            string[] hist = { $"Педагогическое образование", 
                            "Педагогическое образование (с двумя профилями подготовки)", 
                            "Педагогическое образование (с двумя профилями подготовки)", 
                            "История" };
            string[] cult = { $"Педагогическое образование", 
                            "Педагогическое образование (с двумя профилями)", 
                            "Религиоведение", 
                            "Культурология", 
                            "Народная художественная культура", 
                            "Библиотечно-информационная деятельность", 
                            "Дизайн", 
                            "Декоративно-прикладное искусство и народные промыслы" };
            string[] med = { $"Лечебное дело", 
                            "Педиатрия" };
            string[] ped = { $"Педагогическое образование", 
                            "Психолого-педагогическое образование", 
                            "Специальное (дефектологическое) образование", 
                            "Педагогическое образование (с двумя профилями подготовки)" };
            string[] soc = { $"Психология", 
                            "Социальная работа", 
                            "Педагогическое образование", 
                            "Педагогическое образование (с двумя профилями подготовки)", 
                            "Физическая культура" };
            string[] itnit = { $"Прикладная математика и информатика", 
                              "Математика и компьютерные науки", 
                              "Физика", 
                              "Радиофизика", 
                              "Прикладная информатика", 
                              "Информационная безопасность", 
                              "Техносферная безопасность", 
                              "Профессиональное обучение", 
                              "Педагогическое образование (с двумя профилями подготовки)" };
            string[] econ = { $"Экономика", 
                              "Менеджмент", 
                              "Туризм", 
                              "Сервис" };
            string[] yur = { "Юриспруденция" };

            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.DataSource = college;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.DataSource = gum;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = est;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.DataSource = lang;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.DataSource = hist;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                comboBox2.DataSource = cult;
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                comboBox2.DataSource = med;
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                comboBox2.DataSource = ped;
            }
            else if(comboBox1.SelectedIndex == 8)
            {
                comboBox2.DataSource = soc;
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                comboBox2.DataSource = itnit;
            }
            else if (comboBox2.SelectedIndex == 10)
            {
                comboBox2.DataSource = econ;
            }
            else if (comboBox1.SelectedIndex == 11)
            {
                comboBox2.DataSource = yur;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["RecordBook"].Value.ToString() == textBox2.Text)
                {
                    MessageBox.Show("Студентов с одинаковыми студенческими билетами быть не может!");
                }
                else
                {
                    AddStudent?.Invoke(sender, e);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (dateTimePicker1.Value.Year.ToString());
        }
    }
}
