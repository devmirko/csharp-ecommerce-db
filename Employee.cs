// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Order> EmployeeOrder { get; set; }


    public static void AddEmployee()
    {
        
        CommerceContext db = new CommerceContext();
        //creo una lista dipendenti
        List<Employee> employees = new List<Employee>();
        //aggiugo alla lista 
        employees.Add(new Employee { Name = "Mirko", Surname = "Simonetti"});
        employees.Add(new Employee { Name = "Giacomo", Surname = "Ponzi" });
        employees.Add(new Employee { Name = "Mario", Surname = "Rossi" });
        //faccio un for ed inserisco nel db 
        foreach (Employee employee in employees)
        {
            db.Employees.Add(employee);
        }

        db.SaveChanges();

    }

}