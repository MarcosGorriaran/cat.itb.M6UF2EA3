
using cat.itb.M6UF2EA3.connections;
using cat.itb.M6UF2EA3.model;
using NHibernate;

namespace cat.itb.M6UF2EA3.cruds
{
    public class DepartamentoCRUD
    {
        /*public static Empleado SelectById(int id)
        {

        }
        public static List<Empleado> SelectAll()
        {

        }
        */
        public static string Insert(Departamento department)
        {
            string showInsertResult;
            using (ISession session = SessionFactoryCloudzt.Open<Departamento>())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(department);
                    transaction.Commit();
                    showInsertResult = $"Departamento {department.Name} ha sido insertado";
                }
            }
            return showInsertResult;
        }
        public static string InsertMany(List<Departamento> departamentos)
        {
            string showInsertResult="";
            foreach(Departamento department in departamentos)
            {
                showInsertResult += Insert(department)+Environment.NewLine;
            }
            return showInsertResult;
        }/*
        public static void UpdateAdapter(Empleado employee)
        {

        }
        public static void Delete(int id)
        {

        }*/
    }
}
