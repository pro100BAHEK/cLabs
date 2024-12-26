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
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;

namespace lab9
{
    public partial class Form1 : Form
    {
        BindingList<Student> studs = new BindingList<Student>();
        public class Student
        {
            private string name;
            private string stud;
            private string inst;

            public string Name { get => name; set => name = value; }
            public string Stud { get => stud; set => stud = value; }
            public string Inst { get => inst; set => inst = value; }

            public override string ToString()
            {
                return $"{Name} {Stud} {Inst}";
            }
        }

        private void addStuds()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("ФИО", 200);
            listView1.Columns.Add("Студ.билет", 200);
            listView1.Columns.Add("Институт", 200);

            //studs.Add(new Student { Name = "Иванов Егор Ильич", Stud = "20221085", Inst = "ИТНиТ" });
            foreach (Student s in studs)
            {
                ListViewItem item = new ListViewItem(s.Name);
                item.SubItems.Add(s.Stud);
                item.SubItems.Add(s.Inst);
                listView1.Items.Add(item);
            }
        }

        public Form1()
        {
            InitializeComponent();
            addStuds();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                if (studs.Any(s => s.Stud == textBox2.Text))
                {
                    MessageBox.Show("Студент с таким билетом уже существует!");
                }
                else
                {
                    studs.Add(new Student { Name = (textBox1.Text), Stud = (textBox2.Text), Inst = comboBox1.Text });
                    MessageBox.Show("Студент успешно добавлен!");
                    addStuds();
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;
                studs.RemoveAt(index);
                listView1.Items.RemoveAt(index);
                MessageBox.Show("Студент успешно удалён!");
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string choose = comboBox2.Text;

            if (string.IsNullOrEmpty(choose))
            {
                MessageBox.Show("Выберите формат для сохранения!");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                switch (choose)
                {
                    case "json":
                        saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                        break;

                    case "xml":
                        saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
                        break;

                    case "csv":
                        saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                        break;

                    default:
                        MessageBox.Show("Неизвестный формат! Выберите JSON, XML или CSV.", "Ошибка");
                        return;
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;

                    try
                    {
                        switch (choose)
                        {
                            case "json":
                                SaveToJson(path);
                                break;

                            case "xml":
                                SaveToXml(path);
                                break;

                            case "csv":
                                SaveToCsv(path);
                                break;
                        }

                        MessageBox.Show("Список студентов успешно сохранён!", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Supported Files|*.json;*.xml;*.csv|JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|CSV Files (*.csv)|*.csv",
                Title = "Выберите файл для загрузки"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string extension = Path.GetExtension(path).ToLower();

                try
                {
                    // Определение формата по расширению
                    switch (extension)
                    {
                        case ".json":
                            LoadFromJson(path);
                            break;

                        case ".xml":
                            LoadFromXml(path);
                            break;

                        case ".csv":
                            LoadFromCsv(path);
                            break;

                        default:
                            MessageBox.Show("Формат файла не поддерживается.", "Ошибка");
                            return;
                    }

                    MessageBox.Show("Список студентов успешно загружен!", "Успех");
                    UpdateListView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка");
                }
            }
        }

        private void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(studs, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json, Encoding.UTF8);
        }

        private void LoadFromJson(string path)
        {
            string json = File.ReadAllText(path, Encoding.UTF8);
            var loadedStudents = JsonConvert.DeserializeObject<BindingList<Student>>(json);
            if (loadedStudents != null)
            {
                studs.Clear();
                foreach (var student in loadedStudents)
                {
                    studs.Add(student);
                }
            }
        }

        private void SaveToXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Student>));
            using (StreamWriter writer = new StreamWriter(path))
            {
                xmlSerializer.Serialize(writer, studs);
            }
        }

        private void LoadFromXml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Student>));
            using (StreamReader reader = new StreamReader(path))
            {
                var loadedStudents = (BindingList<Student>)xmlSerializer.Deserialize(reader);
                studs.Clear();
                foreach (var student in loadedStudents)
                {
                    studs.Add(student);
                }
            }
        }


        private void SaveToCsv(string path)
        {
            StringBuilder csvContent = new StringBuilder();

            // Заголовки
            csvContent.AppendLine("Name,Stud,Inst");

            // Данные
            foreach (var student in studs)
            {
                csvContent.AppendLine($"{student.Name},{student.Stud},{student.Inst}");
            }

            File.WriteAllText(path, csvContent.ToString(), Encoding.UTF8);
        }

        private void LoadFromCsv(string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            studs.Clear();

            // Пропускаем первую строку (заголовок)
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length == 3)
                {
                    studs.Add(new Student
                    {
                        Name = parts[0].Trim(),
                        Stud = parts[1].Trim(),
                        Inst = parts[2].Trim()
                    });
                }
            }
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();
            foreach (var student in studs)
            {
                ListViewItem item = new ListViewItem(student.Name);
                item.SubItems.Add(student.Stud);
                item.SubItems.Add(student.Inst);
                listView1.Items.Add(item);
            }
        }
    }
}