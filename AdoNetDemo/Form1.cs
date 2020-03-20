using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace AdoNetDemo
{
	public class Form1 : Form
	{
		private IContainer components = null;

		private Button button1;

		private Button button2;

		private Button button3;

		private DataGridView dataGridView1;

		private Button button4;

		private Button button6;

		private Button button7;

		private Button button5;

		public Form1()
		{
			InitializeComponent();
		}

		private void DataBind(DataTable dataTable)
		{
			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.DataSource = dataTable;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				AdoHelper helper = new AdoHelper();
				string sql = "select * from Student";
				string result = helper.ExecuteReader(sql);
				MessageBox.Show(result);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				AdoHelper helper = new AdoHelper();
				string procedureName = "p_GetStudentAge";
				MessageBox.Show(helper.ExecuteScalar(procedureName, 3).ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				AdoHelper helper = new AdoHelper();
				DataTable dt = helper.GetDataTable();
				DataBind(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				AdoHelper helper = new AdoHelper();
				DataSet ds = helper.GetDataSet();
				DataBind(ds.Tables[0]);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				AdoHelper helper = new AdoHelper();
				string result = helper.Insert();
				MessageBox.Show(result);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			try
			{
				AdoHelper helper = new AdoHelper();
				string result = helper.Update("new address", 3);
				MessageBox.Show(result);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			button4 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			button1.Location = new System.Drawing.Point(759, 392);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(109, 62);
			button1.TabIndex = 1;
			button1.Text = "Data Reader";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(612, 392);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(109, 62);
			button2.TabIndex = 2;
			button2.Text = "Scalar";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button3.Location = new System.Drawing.Point(171, 392);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(109, 62);
			button3.TabIndex = 5;
			button3.Text = "Data Table";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new System.Drawing.Point(24, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 62;
			dataGridView1.RowTemplate.Height = 28;
			dataGridView1.Size = new System.Drawing.Size(996, 350);
			dataGridView1.TabIndex = 7;
			button4.Location = new System.Drawing.Point(24, 392);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(109, 62);
			button4.TabIndex = 6;
			button4.Text = "Data Set";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button6.Location = new System.Drawing.Point(465, 392);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(109, 62);
			button6.TabIndex = 3;
			button6.Text = "Insert";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button7.Location = new System.Drawing.Point(318, 392);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(109, 62);
			button7.TabIndex = 4;
			button7.Text = "Update";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button5.Location = new System.Drawing.Point(906, 392);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(109, 62);
			button5.TabIndex = 0;
			button5.Text = "Close";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1042, 488);
			base.Controls.Add(button5);
			base.Controls.Add(button7);
			base.Controls.Add(button6);
			base.Controls.Add(button4);
			base.Controls.Add(dataGridView1);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Name = "Form1";
			Text = "ADO.Net Demo";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}
	}
}
