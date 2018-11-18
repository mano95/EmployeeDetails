using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    public class Employee
    {
        public int nEmployeeID { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strRole { get; set; }
        public DateTime dJoiningDate;
    }

    public class EmployeeDao
    {
        Employee emp;
        List<Employee> list;
        string connection="server=DESKTOPP-8R9B60K;user=;database=test;password=1234";
        SqlConnection con = new SqlConnection(connection);
        
        public EmployeeDao()
        {
            list = new List<Employee>();
        }

        public void AddEmployee(int empId,string fname,string lname,string role,DateTime joiningDate)
        {
            emp = new Employee();
            emp.nEmployeeID = empId;
            emp.strFirstName = fname;
            emp.strLastName = lname;
            emp.strRole = role;
            emp.dJoiningDate = joiningDate;
            list.Add(emp);

        }

        public void ReadEmployee()
        {

            foreach(var data in list)
            {
                Console.WriteLine("EmpID :{0},FirstName:{1},LastName:{2},Role:{3},JoiningDate:{4}",data.nEmployeeID,data.strFirstName,data.strLastName,data.strRole,data.dJoiningDate);
            }
        }
    }

    class Program
    {
        public static void Main(string []args)
        {
            EmployeeDao empDao = new EmployeeDao();
            int option;
            do
            {
                Console.WriteLine("1.Add Employee\n2.DisplayEmployee\n");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter EmployeeID");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter firstName");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter laststName");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Enter Role");
                        string role = Console.ReadLine();
                        Console.WriteLine("Enter joiningDate");
                        DateTime joiningDate = Convert.ToDateTime(Console.ReadLine()).Date;
                        empDao.AddEmployee(empId, fname, lname, role, joiningDate);
                        break;
                    case 2:
                        empDao.ReadEmployee();
                        break;
                }
            } while (option <= 2);
            Console.ReadKey();
           
        }
    }
        
}
