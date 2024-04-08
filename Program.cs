using cat.itb.M6UF2EA3.cruds;
using cat.itb.M6UF2EA3.model;
using NHibernate.Criterion;

namespace cat.itb.M6UF2EA3;

public class Driver
{
    public static void Main()
    {
        int option;
        using EmpleadoCRUD empCRUD = new EmpleadoCRUD();
        using DepartamentoCRUD depCRUD = new DepartamentoCRUD();
        List<Departamento> newDepartments = new List<Departamento>(new Departamento[] {
            new Departamento()
            {
                Name = "TECNOLOGIA",
                Loc = "BARCELONA"
            },
            new Departamento()
            {
                Name = "INFORMATICA",
                Loc = "SEVILLA"
            }
        });
        do
        {
            Console.WriteLine("1: 1.1 Insert Departments\n" +
                "2: 1.2 Insert Employee\n" +
                "3: 1.3 Update Department 2\n" +
                "4: 1.4 Update employee Salary\n" +
                "5: 1.5 Delete Employee\n" +
                "6: 1.6 Show rich Employees\n" +
                "7: 1.7 Show employee department\n" +
                "8: 1.8 Show department employees\n"+
                "9: 2.1 Show Departments HQL\n"+
                "10: 2.2 Show Employees Criteria\n"+
                "11: 2.3 Show Rich Employees Criteria\n"+
                "12: 2.4 Show VENTAS loc HQL\n"+
                "13: 2.5 Show all VENDEDOR ordered QueryOver\n"+
                "19. Exit");
            option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:

                    depCRUD.InsertMany(newDepartments);
                    break;
                case 2:
                    foreach(Departamento departamento in newDepartments)
                    {
                        int deptno = depCRUD.SelectAll().First().ID;
                        empCRUD.Insert(new Empleado()
                        {
                            surname = "Someone",
                            empno = 9999,
                            job = "Empleado",
                            boss = 7902,
                            AltDate = new DateTime(2018, 12, 31, 5, 10, 20, DateTimeKind.Utc),
                            salary = 1040,
                            comision = null,
                            department = depCRUD.SelectAll(dep => dep.Name==departamento.Name).First()
                        }) ;
            
                    }
                    break;
                case 3:
                    Departamento updateElement = depCRUD.SelectById(2);
                    updateElement.Name = "RECERCA";
                    depCRUD.Update(updateElement);
                    break;
                case 4:
                    Empleado updateEmployee = empCRUD.SelectAll(emp => emp.empno == 7499).First();
                    updateEmployee.salary = 2100;
                    empCRUD.Update(updateEmployee);
                    break;
                case 5:
                    empCRUD.Delete(empCRUD.SelectAll(emp=>emp.surname.Equals("SALA")).First());
                    break;
                case 6:
                    List<Empleado> richEmployees = empCRUD.SelectAll(emp => emp.salary > 2000);
                    foreach (Empleado emp in richEmployees)
                    {
                        Console.WriteLine(emp.surname + ": " + emp.salary);
                    }
                    break;
                case 7:
                    Console.WriteLine(empCRUD.SelectById(6).department.Name);
                    break;
                case 8:
                    IList<Empleado> employees = depCRUD.SelectById(2).workers;
                    foreach (Empleado emp in employees)
                    {
                        Console.WriteLine(emp.surname);
                        Console.WriteLine("   "+emp.job);
                        Console.WriteLine("   "+emp.salary);
                    }
                    break;
                case 9:
                    IList<Departamento> departments = depCRUD.SelectAll("select c from Departamento c");
                    foreach(Departamento dep in departments)
                    {
                        Console.WriteLine(dep);
                    }
                    break;
                case 10:
                    List<Empleado> critEmployees = empCRUD.SelectAll(new List<ICriterion>());

                    foreach (Empleado employee in critEmployees)
                    {
                        Console.WriteLine(employee);
                       
                    }
                    break;
                case 11:
                    List<Empleado> critRichEmployees = empCRUD.SelectAll(new List<ICriterion>(new ICriterion[]{
                        Expression.Where<Empleado>(emp=>emp.salary>2000)
                    }));
                    foreach (Empleado employee in critRichEmployees)
                    {
                        Console.WriteLine(employee);

                    }
                    break;
                case 12:
                    string ventasLoc = depCRUD.SelectAll("select c from Departamento c").First().Loc;
                    Console.WriteLine(ventasLoc);
                    break;
                case 13:
                    break;
                case 19:
                    break;
                default:
                    break;
            }
        } while (option!=9);  
    }
}