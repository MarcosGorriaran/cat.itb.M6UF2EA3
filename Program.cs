using cat.itb.M6UF2EA3.cruds;
using cat.itb.M6UF2EA3.model;

namespace cat.itb.M6UF2EA3;

public class Driver
{
    public static void Main()
    {
        int option;
        EmpleadoCRUD empCRUD = new EmpleadoCRUD();
        DepartamentoCRUD depCRUD = new DepartamentoCRUD();
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
            Console.WriteLine("1. Insert Departments\n" +
                "2. Insert Employee\n" +
                "3. Update Department 2\n" +
                "4. Update employee Salary\n" +
                "5. Delete Employee\n" +
                "6. Show rich Employees\n" +
                "7. Show employee department\n" +
                "8. Show department employees\n"+
                "9. Exit \n");
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
                    break;
                default:
                    break;
            }
        } while (option!=9);
        
        

        

        

        

       

        

        
    }
}