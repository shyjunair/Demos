using System;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using EFDemoCodeFirst.Models;
using System.Collections.Generic;

namespace EFDemoCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CPContext context = new CPContext();
                int scount = context.Schools.Count();
                int stdcount = context.Students.Count();
                MessageBox.Show($"Schools: {scount}, Students {stdcount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                SchoolId = 5,
                Name = "Test student",
                DOB = DateTime.Now,
                Address = "Bangalore"
            };
            using (var context = new CPContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
            MessageBox.Show("New student created.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var school = new School
            {
                Id = 5,
                Name = "Hitachi School"
            };
            using (var context = new CPContext())
            {
                context.Schools.Add(school);
                context.SaveChanges();
            }
            MessageBox.Show("New School created.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var context = new CPContext())
            {
                SqlParameter id = new SqlParameter("@Id", 3);
                var res = context.Database.SqlQuery<int>("p_GetStudentAge @Id", id).SingleOrDefault();

                MessageBox.Show("Result: " + res);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var context = new CPContext())
            {
                var res = context.Database.SqlQuery<Student>("p_GetStudent").ToList();
                var res2 = res.Where(x => x.Id > 2);

                var students = from s in res
                               where s.SchoolId == 2
                               select new SudentDTO
                               {
                                   Id = s.Id,
                                   Name = s.Name,
                                   Address = s.Address,
                                   DOB = s.DOB
                               };
                DataBind(students.ToList());
            }
        }

        private void DataBind(IEnumerable<SudentDTO> students)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = students;
        }
    }

    class SudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DOB { get; set; }
    }
}
