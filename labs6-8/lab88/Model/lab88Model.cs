using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab88.Model
{
    public class StudentModel
    {
        private string connectionString = "Data Source=EGOR\\SQLEXPRESS;Initial Catalog=lab8;Integrated Security=True;";

        public void CreateStudent(string name, int recordBook, string department, string specification, DateTime dateOfAdmission, string group)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, RecordBook, Department, Specification, DateOfAdmission, [Group]) VALUES (@Name, @RecordBook, @Department, @Specification, @DateOfAdmission, @Group)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@RecordBook", recordBook);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Specification", specification);
                cmd.Parameters.AddWithValue("@DateOfAdmission", dateOfAdmission);
                cmd.Parameters.AddWithValue("@Group", group);

                if (recordBook.ToString().Length != 8)
                {
                    MessageBox.Show("Неверное количество символов в поле 'Студ.билет'!");
                }

                if (name == "" || recordBook == null || department == "" || specification == "" || dateOfAdmission.Date > DateTime.Now || group == "")
                {
                    MessageBox.Show("Введите данные во все поля!");
                }

                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ReadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void UpdateStudent(int id, string name, int recordBook, string department, string specification, DateTime dateOfAdmission, string group)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Students SET Name = @Name, RecordBook = @RecordBook, Department = @Department, Specification = @Specification, DateOfAdmission = @DateOfAdmission, [Group] = @Group WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@RecordBook", recordBook);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Specification", specification);
                cmd.Parameters.AddWithValue("@DateOfAdmission", dateOfAdmission);
                cmd.Parameters.AddWithValue("@Group", group);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
