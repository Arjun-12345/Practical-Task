namespace EntityCRUD.Models
{
    public interface IDataAcess
    {
        List<Employee> GetAllEmployees(int id = 0);
        bool CreateEmployees(Employee employee);
        bool UpdateEmployees(Employee employee);
        bool DeleteEmployee(int id);
    }
}
