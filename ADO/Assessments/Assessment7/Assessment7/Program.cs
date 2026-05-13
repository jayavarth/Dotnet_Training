using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment7
{
    class Employee
    {
        public int Empno { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSal { get; set; }
        public char EmpType { get; set; }
        DataAccess access = new DataAccess();

        public int AddEmployee()
        {
            Console.WriteLine("Enter Employee Name :");
            EmpName = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary :");
            EmpSal = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Employee Type (F/P) :");
            EmpType = Convert.ToChar(Console.ReadLine().ToUpper());

            return access.InsertEmployee(EmpName, EmpSal, EmpType);
        }

        public void UpdateSalary()
        {
            Console.WriteLine("Enter Employee ID :");
            Empno = int.Parse(Console.ReadLine());

            decimal updatedSalary =
                access.UpdateEmployeeSalary(Empno);

            if (updatedSalary > 0)
            {
                Console.WriteLine("Updated Salary : " + updatedSalary);
            }
            else
            {
                Console.WriteLine("Employee ID Not Found");
            }
        }

        public SqlDataReader ShowEmployees()
        {
            return access.GetEmployees();
        }
    }

    class DataAccess
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public SqlConnection GetConnection()
        {
            string str = "Data Source=ICS-LT-1C73YS3;Initial Catalog=EmployeeManagement;Integrated Security=True";

            con = new SqlConnection(str);
            con.Open();
            return con;
        }

        public int InsertEmployee(string name, decimal sal, char type)
        {
            int result = 0;

            try
            {
                con = GetConnection();
                cmd = new SqlCommand("add_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empname", name);
                cmd.Parameters.AddWithValue("@empsal", sal);
                cmd.Parameters.AddWithValue("@emptype", type);

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        public SqlDataReader GetEmployees()
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("select * from employee_details", con);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public decimal UpdateEmployeeSalary(int empid)
        {
            decimal salary = 0;

            try
            {
                con = GetConnection();

                cmd = new SqlCommand("update_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", empid);

                cmd.Parameters.Add("@updatedsal", SqlDbType.Decimal);
                cmd.Parameters["@updatedsal"].Direction = ParameterDirection.Output;
                cmd.Parameters["@updatedsal"].Precision = 10;
                cmd.Parameters["@updatedsal"].Scale = 2;

                cmd.ExecuteNonQuery();

                salary = Convert.ToDecimal(cmd.Parameters["@updatedsal"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return salary;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.WriteLine("Insert Employee");
            int res = emp.AddEmployee();

            if (res > 0)
                Console.WriteLine("Employee Inserted Successfully");
            else
                Console.WriteLine("Insertion Failed");

            //--------------------------------------
            Console.WriteLine("\nEmployee Details");
            SqlDataReader dr = emp.ShowEmployees();

            while (dr.Read())
            {
                Console.WriteLine(dr["empno"] + " " + dr["empname"] + " " + dr["empsal"] + " " + dr["emptype"]);
            }

            //-------------------------------------
            Console.WriteLine("Update Employees");

            emp.UpdateSalary();

            //--------------------------------------
            Console.WriteLine("\nEmployee Details");

            while (dr.Read())
            {
                Console.WriteLine( dr["empno"] + " " +dr["empname"] + " " +dr["empsal"] + " " +dr["emptype"]);
            }

            Console.ReadLine();
        }
    }
}