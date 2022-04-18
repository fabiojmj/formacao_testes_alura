using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Testes.ClassData;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculosTestes
    {

        private Veiculo veiculo;

        //Construtor -> Setup
        public VeiculosTestes()
        {
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }


        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Testa Tipo do Veiculo")]
        public void TestaTipoVeiculoAutomovel()
        {
            //arrange
            //var veiculo = new Veiculo();
            //act
            //assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste nao implementado", DisplayName = "Testa Nome do Proprietario")]
        public void TestaNomeProprietarioDoVeiculo()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaAlterarDadosVeiculos()
        {
            //arrange
            var veiculoSalvo = new Veiculo
            {
                Proprietario = "Jose Silva",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Opala",
                Placa = "ZXC-8524"
            };

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Jose Silva",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Preto",
                Modelo = "Opala",
                Placa = "ZXC-8524"
            };
            var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculoSalvo);

            //act
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //assert
            Assert.Equal(veiculoSalvo.Cor, alterado.Cor);

        }

        [Fact]
        public void FichaInformativaDoVeiculo()
        {
            //arrange
            var veiculo = new Veiculo
            {
                Proprietario = "Jose Silva",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Preto",
                Modelo = "Opala",
                Placa = "ZXC-8524"
            };
            //act
            string dados = veiculo.ToString();
            //assert
            Assert.Contains("Tipo do Veiculo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosTresCaracteres()
        {
            //arrange
            string nomeProprietario = "ab";          

            //assert
            Assert.Throws<FormatException>(
                //act
                () =>
                {
                    new Veiculo(nomeProprietario);
                }
                );
        }

        [Fact]
        public void TestaExcecaoDoQuartoCaracterDaPlaca()
        {
            //arrange
            string placa = "ASDF8888";

            //act
            var mensagem = Assert.Throws<FormatException>(()=> {
                new Veiculo().Placa = placa;
            });

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }
    }
}
