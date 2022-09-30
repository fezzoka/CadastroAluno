using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }

        public AtualizarDados(string nome,string turma)
        {
            Nome = nome;
            turma = turma;
        }
    }
}
