using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab88.View
{
    public interface lab8View
    {
        string StudentName { get; set; }
        int RecordBook { get; set; }
        string Department {  get; set; }
        string Specification {  get; set; }
        DateTime DateOfAdmission {  get; set; }
        string Group {  get; set; }
        int Id {  get; set; }

        void DisplayStudents(DataTable students);
        event EventHandler AddStudent;
        event EventHandler UpdateStudent;
        event EventHandler DeleteStudent;
        event EventHandler ViewStudents;
    }
}
