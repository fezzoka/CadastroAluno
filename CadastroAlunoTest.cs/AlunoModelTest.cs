using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunoTest.cs
{
    public class AlunoModelTest
    {
    [Fact]
    public void AtualizarDadosAlteraNomeETurma()
        {
            //arrange
            Aluno aluno = new Aluno();
            //ACT
            var res = aluno;
          aluno.AtualizarDados("joao Silva", "T91");
            //assert
            Assert.Equal(res, aluno);
        }
        [Theory]
        [InlineData("Joao","t90")]
        [InlineData("pablo2512  s", "t9sadvb/0")]
        [InlineData("Jo22356ao", "t290")]
        [InlineData("...", "  ")]
        public void AtualizarDadosNaoAlteraNomeETurma(string Nome,string turma)
        {
            //arrange
            Aluno aluno = new Aluno();
            //ACT
            var res = aluno;
            aluno.AtualizarDados(Nome,turma);
            //assert
            Assert.Equal(res, aluno);
        }
        [Fact]
        public void VerificaAprovacapRetornaVerdadeiroSeMediaMaior5()
        {
            //arrange
            Aluno aluno = new Aluno();
            //act
            aluno.media = 6;
            var Result = aluno.VerificaAprovacao();
            //assert
            Assert.Equal(true,Result);
        }
        [Fact]
        public void VerificaNaoAprovacapRetornaFalsoSeMediaMaior5()
        {
            //arrange
            Aluno aluno = new Aluno();
            //act
            aluno.media = 4;
            var Result = aluno.VerificaAprovacao();
            //assert
            Assert.Equal(false, Result);
        }
        [Fact]
        public void MetodoAtualizaMediaAtualizComValorCerto()
        {
            //arrange
            Aluno aluno = new Aluno();
            //act
            var novamedia = 7;
            aluno.media = 4;
            aluno.AtualizaMedia(novamedia);
            //assert
            Assert.Equal(aluno.media, novamedia);
        }
        [Fact]
        public void MetodoAtualizaMedioAtualizComValorCerto_vazio()
        {
            //arrange
            Aluno aluno = new Aluno();
            //act
            var novamedia = 2;
            aluno.media = 4;
            aluno.AtualizaMedia(novamedia);
            //assert
            Assert.Equal(aluno.media, novamedia);
        }
    }
}
