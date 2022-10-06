using System;
using Xunit;
using Moq;
using CadastroAluno.Contracts;
using CadastroAluno.Models;
using CadastroAluno.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAlunoTest.cs
{
    public class AlunoControllerTest
    {
        Mock<IAlunoRepository> _mockAlunoController;
        AlunosController controller;


        Aluno alunoValido;

        public AlunoControllerTest()
        {
            _mockAlunoController = new Mock<IAlunoRepository>();
            alunoValido = new Aluno()
            {
                Id = 3,
                media = 6,
                Nome = "Ronaldo",
                Turma = "t92"
            };
            controller = new AlunosController(_mockAlunoController.Object);
        }
        [Fact]
        public async void ChamaORepositorioUmaVezComOuSemRegistro()
        {

            //arrange
            //act
            var result = await controller.Index();
            //assert
            Assert.IsType<ViewResult>(result);

            Assert.NotNull(result);
        }
        [Fact]
        public async void CreateAluno_ModelStateValida_ChamaRepositorioUmaVez()
        {
            //Arrange


            _mockAlunoController.Setup(r => r.AddAluno(alunoValido))
                .ReturnsAsync(alunoValido);

            //Act
            await controller.Create(alunoValido);

            //Assert 
            _mockAlunoController.Verify(rp => rp.AddAluno(alunoValido), Times.Once);
        }
        [Fact]
        public async void DetailsIdBadRequestFoundController()
        {
            //Arrange

            var alunoSemid = await controller.Details(-1);

            //Act

            //Assert
            Assert.IsType<BadRequestResult>(alunoSemid);

        }
        [Fact]
        public async void DetailsIdNuloNotFoundController()
        {
            //Arrange
            var alunoid = await controller.Details(5);

            //Act

            //Assert
            Assert.IsType<NotFoundResult>(alunoid);

        }
        [Fact]
        public async void AlunoEncontradoNoBanco_Controller()
        {
            //Arrange
            AlunosController controller = new AlunosController(_mockAlunoController.Object);
            _mockAlunoController.Setup(a => a.GetAluno(1))
               .ReturnsAsync(alunoValido);
            //Act
            var alunos = await controller.Details(1);
            //Assert
            Assert.IsType<ViewResult>(alunos);
        }
        [Fact]
        public async void MetodoDetailsChamarUmaVezORepositorio()
        {
            //Arrange        

            var result = _mockAlunoController.Setup(a => a.GetAluno(1))
                .ReturnsAsync(alunoValido);
            //Act
            var alunos = await controller.Details(1);
            //Assert
            _mockAlunoController.Verify(ar => ar.GetAluno(1), Times.Once);
        }
        [Fact]
        public void MetodoCreateDeveRetornarUmaViewResult()
        {
            //Arrange


            //Act
            var aluno = controller.Create();

            //Assert
            Assert.IsType<ViewResult>(aluno);
        }
        [Fact]
        public async void MetodoFoiChamadoApenasUmavezeSeForDoTipoRedirectToAction()
        {
            //Arrange         
            //Act
            var result = await controller.Create(alunoValido);
            //Assert
            _mockAlunoController.Verify(ar => ar.AddAluno(alunoValido), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}


