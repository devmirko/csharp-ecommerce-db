// See https://aka.ms/new-console-template for more information
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Order> EmployeeOrder { get; set; }

}