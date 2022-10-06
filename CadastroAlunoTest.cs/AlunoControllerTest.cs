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
        Mock<IAlunoRepository> _mockAlunoController;
         AlunosController _controller;

        public AlunoControllerTest()
        {
            _mockAlunoController = new Mock<IAlunoRepository>();
            _controller = new AlunosController(_mockAlunoController.Object);
        }
        [Fact]
        public void ChamaORepositorioUmaVezComOuSemRegistro()
        {

            //arrange
            var result = _controller.Index();
            //act
            //assert

        }
    }
}

