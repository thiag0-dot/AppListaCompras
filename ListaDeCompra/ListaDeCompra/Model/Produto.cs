using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ListaDeCompra.Model
{
    public class Produto
    {
        string _nome;
        double _qnt;

        [PrimaryKey, Autoincrement]
        public int Id { get; set; }

        public string Nome 
        {
            get => _nome;
            set
            {
                if (value == null)
                    throw new Exception("Nome inválido");

                _nome = value;
            }
        }

        public double Qnt
        {
            get
            {
                return _qnt;
            }

            set
            {
                if(!double.TryParse(value.ToString(), out _qnt))
                    _qnt = 0.0;

                if (value == 0)
                    throw new Exception("Quantidade inválida");

                _qnt = value;
            }
        }

        public double preco { get; set; }

        public double Precototal 
        {
            get => Preco * Qnt;
        }
    }
}
