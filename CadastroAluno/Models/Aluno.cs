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
        public double media { get; set; }
        public void AtualizarDados(string nome,string turma)
        {
            Nome = nome;
            Turma = turma;
        }
        // Adicionado = na formula da media 
        public bool VerificaAprovacao() 
            => media >= 5;

        public void AtualizaMedia (double novaMedia) => media = novaMedia;

        internal static void AtualizaDados(object nome, object nascimeto, object email)
        {
            throw new NotImplementedException();
        }
    }
}
