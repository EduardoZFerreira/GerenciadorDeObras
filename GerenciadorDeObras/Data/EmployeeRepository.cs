using GerenciadorDeObras.Entities;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeObras.Data
{
    public class EmployeeRepository
    {
        public static EmployeeRepository Build()
        {
            return new EmployeeRepository();
        }

        public bool Create(Employee obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Employee>();
                return conn.Insert(obj) > 0;
            }
        }

        public bool Delete(Employee obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Employee>();
                return conn.Delete(obj) > 0;
            }
        }

        public List<Employee> GetAll()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Employee>();
                return conn.Table<Employee>().ToList();
            }
        }

        public Employee GetById(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Employee>();
                return conn.Query<Employee>("SELECT * FROM Employee WHERE ID = ?", id).FirstOrDefault();
            }
        }

        public Employee GetWithChildren(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Employee>();
                return conn.GetWithChildren<Employee>(id);
            }
        }

        public bool Update(Employee obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Employee>();
                return conn.Update(obj) > 0;
            }
        }
    }
}
