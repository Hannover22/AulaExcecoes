using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioArquivos
{
    internal class Contato
    {
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public char Genero { get; set; }

        public Contato(string n, int t, char g)
        {
            this.Nome = n;
            this.Telefone = t;
            this.Genero = g;
        }
        public override string ToString()
        {
            return $"""Nome: {Nome}, Telefone: {Telefone}, Genero:{Genero}""";
        }
    }
}
