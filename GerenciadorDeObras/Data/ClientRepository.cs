using GerenciadorDeObras.Entities;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeObras.Data
{
    public class ClientRepository
    {
        public static ClientRepository Build()
        {
            return new ClientRepository();
        }

        public bool Create(Client obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Client>();
                return conn.Insert(obj) > 0;
            }
        }

        public bool Delete(Client obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Client>();
                return conn.Delete(obj) > 0;
            }
        }

        public List<Client> GetAll()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                return conn.Table<Client>().ToList();
            }
        }

        public Client GetById(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                return conn.Query<Client>("SELECT * FROM Client WHERE ID = ?", id).FirstOrDefault();
            }
        }

        public Client GetWithChildren(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                return conn.GetWithChildren<Client>(id);
            }
        }

        public bool Update(Client obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Client>();
                return conn.Update(obj) > 0;
            }
        }

        public bool UpdateWithChildren(Client obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Client>();
                conn.UpdateWithChildren(obj);
                return true;
            }
        }
    }
}
