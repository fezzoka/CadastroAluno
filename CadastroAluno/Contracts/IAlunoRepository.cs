using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroAluno.Contracts
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAlunos();

        Task<Aluno> GetAlunoById(int id);

        Task<Aluno> AddAluno(Aluno aluno);

        Task<int> UpdateAluno(int id, Aluno alunoalterado);

        Task DeleteAluno(int id);
    }
}