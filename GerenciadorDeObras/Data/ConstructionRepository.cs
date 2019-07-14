using GerenciadorDeObras.Entities;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeObras.Data
{
    public class ConstructionRepository
    {
        public static ConstructionRepository Build()
        {
            return new ConstructionRepository();
        }

        public bool Create(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();
                return conn.Insert(obj) > 0;
            }
        }

        public bool Delete(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();
                return conn.Delete(obj) > 0;
            }
        }

        public List<Construction> GetAll()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                return conn.Table<Construction>().ToList();
            }
        }

        public Construction GetById(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                return conn.Query<Construction>("SELECT * FROM Construction WHERE ID = ?", id).FirstOrDefault();
            }
        }

        public Construction GetWithChildren(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                return conn.GetWithChildren<Construction>(id);
            }
        }

        public bool Update(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();
                return conn.Update(obj) > 0;
            }
        }

        public bool UpdateWithChildren(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();
                conn.UpdateWithChildren(obj);
                return true;
            }
        }
    }
}
