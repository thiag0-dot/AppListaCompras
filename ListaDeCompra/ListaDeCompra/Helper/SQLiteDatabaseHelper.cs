using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ListaDeCompra.Model;
using SQLite;


namespace ListaDeCompra.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Nome = ?, Qnt = ?, Preco = ? WHERE id = ?";

            return _conn.QueryAsync<Produto>(sql, p.Nome, p.Qnt, p.Preco, p.Id);
        }
    }   
}
