using System;
using Xunit;
using Moq;
using CadastroAluno.Contracts;
using CadastroAluno.Models;
using CadastroAluno.Controllers;

namespace CadastroAlunoTest.cs
{
    public class AlunoControllerTest
    {
        private Mock<IAlunoRepository> _mockAlunoController;
        private AlunosController _controller;

        public AlunoControllerTest()
        {
            _mockAlunoController = new Mock<IAlunoRepository>();
            _controller = new AlunosController(_mockAlunoController.Object);
        }
       

    }
}

