using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetDemo
{
	public class AdoHelper
	{
		public string ConnectionString
		{
			get;
		}

		public AdoHelper()
		{
			ConnectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;
		}

		public AdoHelper(string connectionString)
		{
			ConnectionString = connectionString;
		}

		private SqlConnection GetConnection()
		{
			SqlConnection con = new SqlConnection(ConnectionString);
			con.Open();
			return con;
		}

		public string ExecuteReader(string sql)
		{
			StringBuilder sb = new StringBuilder();
			using (SqlConnection cn = GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(sql, cn))
				{
					SqlDataReader rdr = cmd.ExecuteReader();
					while (rdr.Read())
					{
						sb.AppendLine($"{rdr[0]}, {rdr[1]}, {rdr[2]}, {rdr[3]}, {rdr[4]}");
					}
				}
			}
			return sb.ToString();
		}

		public int ExecuteScalar(string procedureName, int id)
		{
			using (SqlConnection conn = GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(procedureName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("id", 3);
					return Convert.ToInt32(cmd.ExecuteScalar());
				}
			}
		}

		public string Insert()
		{
			string query = "insert into Student ([Name], [SchoolId], [DOB], [Address]) values (@Name, @SchoolId, @DOB, @Place)";
			using (SqlConnection conn = GetConnection())
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = query;
					cmd.Parameters.AddWithValue("@Name", "Anil");
					cmd.Parameters.AddWithValue("@SchoolId", 2);
					cmd.Parameters.AddWithValue("@DOB", DateTime.Now.AddYears(-20));
					cmd.Parameters.AddWithValue("@Place", "Hyderabad");
					int count = cmd.ExecuteNonQuery();
					return $"{count} Record(s) inserted";
				}
			}
		}

		public string Update(string address, int id)
		{
			string query = "update Student set Address = @Address where Id = @id";
			using (SqlConnection conn = GetConnection())
			{
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = query;
					cmd.Parameters.AddWithValue("@Address", address);
					cmd.Parameters.AddWithValue("@id", id);
					int count = cmd.ExecuteNonQuery();
					return $"{count} Record(s) updated";
				}
			}
		}

		public DataTable GetDataTable()
		{
			string query = "select * from Student with (nolock)";
			DataTable dt = new DataTable();
			using (SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString))
			{
				da.Fill(dt);
			}
			return dt;
		}

		public DataSet GetDataSet()
		{
			string query = "select * from School select * from Student";
			DataSet ds = new DataSet("My Dataset");
			using (SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString))
			{
				da.TableMappings.Add("Table", "School");
				da.TableMappings.Add("Table1", "Student");
				da.Fill(ds);
				DataTable sch = ds.Tables["School"];
				DataTable std = ds.Tables["Student"];
				DataRelation relation = new DataRelation("School", sch.Columns["Id"], std.Columns["SchoolId"], createConstraints: true);
				ds.Relations.Add(relation);
			}
			return ds;
		}
	}
}
