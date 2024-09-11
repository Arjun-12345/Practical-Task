using ADO.Net.Client.Core;
using Microsoft.Data.SqlClient;
using System.Data;
namespace EntityCRUD.Models
{
    public class DataAccess : IDataAcess
    {
        //public DataAccess(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        private readonly string connectionString = "Server=Laptop; Database = Entity; Trusted_Connection=True;TrustServerCertificate = true;";

        public List<Employee> GetAllEmployees(int id = 0)
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetAllEmployeeData", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var employee = new Employee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Dob = reader["Dob"].ToString(),
                            Salary = Convert.ToInt32(reader["Salary"]),
                            DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                            IsActive = Convert.ToInt32(reader["IsActive"])
                        };
                        employees.Add(employee);
                    }
                };
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool IDataAcess.CreateEmployees(Employee employee)
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("CreateNewEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Dob", employee.Dob);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    var reader = command.ExecuteNonQuery();
                    if (reader > 0)
                    {
                        return true;
                    }
                };
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool IDataAcess.DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        bool IDataAcess.UpdateEmployees(Employee employee)
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Dob", employee.Dob);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    var reader = command.ExecuteNonQuery();
                    if (reader > 0)
                    {
                        return true;
                    }
                };
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
