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

        public int Create(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();                
                conn.CreateTable<ConstrucionEmployee>();
                conn.Insert(obj);
                return conn.ExecuteScalar<int>("SELECT MAX(Id) FROM Construction");
            }
        }

        public bool Delete(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();                
                conn.CreateTable<ConstrucionEmployee>();
                return conn.Delete(obj) > 0;
            }
        }

        public List<Construction> GetAll()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                try
                {
                    conn.CreateTable<Construction>();                    
                    conn.CreateTable<ConstrucionEmployee>();
                    return conn.GetAllWithChildren<Construction>().ToList();
                }
                catch (Exception e)
                {
                    Construction c = new Construction() { State = new State().SetError(e.Message) };
                    List<Construction> lst = new List<Construction>();
                    lst.Add(c);
                    return lst;
                }
                
            }
        }

        public Construction GetById(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();                
                conn.CreateTable<ConstrucionEmployee>();
                return conn.Query<Construction>("SELECT * FROM Construction WHERE ID = ?", id).FirstOrDefault();
            }
        }

        public Construction GetWithChildren(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();                
                conn.CreateTable<ConstrucionEmployee>();
                return conn.GetWithChildren<Construction>(id);
            }
        }

        public bool Update(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();                
                conn.CreateTable<ConstrucionEmployee>();
                return conn.Update(obj) > 0;
            }
        }

        public bool UpdateWithChildren(Construction obj)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Construction>();                
                conn.CreateTable<ConstrucionEmployee>();
                conn.UpdateWithChildren(obj);
                return true;
            }
        }
    }
}
