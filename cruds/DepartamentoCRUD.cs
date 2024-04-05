
using cat.itb.M6UF2EA3.connections;
using cat.itb.M6UF2EA3.model;
using NHibernate;

namespace cat.itb.M6UF2EA3.cruds
{
    public class DepartamentoCRUD
    {
        ISession session = SessionFactoryCloudzt.Open<Departamento>();
        public Departamento SelectById(int id)
        {
            Departamento result;
            result = session.Get<Departamento>(id);
            return result;
        }
        public List<Departamento> SelectAll(Func<Departamento,bool> searchTarget)
        {
            List<Departamento> result;
                result = (session.Query<Departamento>().Where(searchTarget)).ToList();
            return result;
        }
        public List<Departamento> SelectAll()
        {
            List<Departamento> result;
            
            result = (session.Query<Departamento>()).ToList();
            return result;
        }
        
        public string Insert(Departamento department)
        {
            string showInsertResult;
            using(ITransaction transaction = session.BeginTransaction())
            {
                session.Save(department);
                transaction.Commit();
                showInsertResult = $"Departamento {department.Name} ha sido insertado";
            }
            return showInsertResult;
        }
        public string InsertMany(List<Departamento> departamentos)
        {
            string showInsertResult="";
            foreach(Departamento department in departamentos)
            {
                showInsertResult += Insert(department)+Environment.NewLine;
            }
            return showInsertResult;
        }
        public void Update(Departamento departamento)
        {
                using(ITransaction trans = session.BeginTransaction())
                {
                    session.Update(departamento);
                    trans.Commit();
                }
        }
        public void Delete(Departamento departamento)
        {
            using (ITransaction trans = session.BeginTransaction())
            {
                session.Delete(departamento);
                trans.Commit();
            }
        }
    }
}
