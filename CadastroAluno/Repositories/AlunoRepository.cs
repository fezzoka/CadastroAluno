using CadastroAluno.Contracts;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroAluno.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CadastroAlunoContext _context;

        public AlunoRepository(CadastroAlunoContext context)
        {
            _context = context;
        }

        public AlunoRepository()
        {
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<int> UpdateAluno(int id, Aluno alunoAlterado)
        {
            var cliente = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return 0;

            Aluno.AtualizaDados(alunoAlterado.Nome, alunoAlterado.Turma, alunoAlterado.media);

            _context.Entry(cliente).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public Task DeleteAluno(int id)
        {
            throw new NotImplementedException();
        }
    }
}