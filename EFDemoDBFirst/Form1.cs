using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFDemoDBFirst.EFClasses;

namespace EFDemoDBFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ShyjuDB())
                {
                    var res = context.p_GetStudentAge(2).FirstOrDefault();
                    MessageBox.Show(res.Value.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Test()
        {
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var nm = from n in months
                     where n > 5
                     select n;

            string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var ms = from m in monthNames
                     where m.Contains("M")
                     select m;

            string s = string.Empty;
            foreach (var item in ms)
            {
                MessageBox.Show(item);

            }
            //MessageBox.Show(s);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var nm = from n in months
                     where n > 5
                     select n;

            string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var ms = from m in monthNames
                     where m.Contains("M")
                     select m;

            string s = string.Empty;
            foreach (var item in ms)
            {
                MessageBox.Show(item);

            }
            //MessageBox.Show(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student
                {
                    SchoolId = 5,
                    Name = "Test student",
                    DOB = DateTime.Now,
                    Address = "Bangalore"
                };
                using (var context = new ShyjuDB())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
                MessageBox.Show("New student created.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ShyjuDB())
                {
                    var res = context.p_GetStudent(0).ToList();
                    var students = from s in res
                                   where s.SchoolId != 2
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
