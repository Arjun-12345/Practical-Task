﻿namespace EntityCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public int Salary {  get; set; }
        public int DepartmentId { get; set; }
        public int IsActive { get; set; }

    }
}
