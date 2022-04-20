using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        private Patio estacionamento;

        public PatioTestes()
        {
            estacionamento = new Patio();
        }

        [Fact]
        public void TesteValidaFaturamento()
        {
            //arrange            
            var veiculo = new Veiculo {
                Proprietario = "Andre Silva",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "ASD-9999"
            };
            //var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2,faturamento);
        }

        [Theory]
        [InlineData("Andre Silva","ASD-1498","GOL")]
        [InlineData("Jose Silva", "ASD-1499", "Fusca")]
        [InlineData("Maria Silva", "ASD-1488", "Opala")]
        public void TesteFaturamentoVariosVeiculos(string proprietario,string placa,string modelo)
        {
            //arrange
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Modelo = modelo
            };

            //var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //act
            double faturamento = estacionamento.TotalFaturado();
            //assert
            Assert.Equal(2,faturamento);
        }

        [Theory]
        [InlineData("Andre Silva", "ASD-1498","Preto", "GOL")]
        public void TesteLocalizaVeiculoPatioComBaseNoTicket(string proprietario,string placa, string cor, string modelo)
        {
            //arrange
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };
            //var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            //act
            Veiculo consultado = estacionamento.LocalizaVeiculoPatio(veiculo.IdTicket);

            //assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }
        
        [Fact]
        public void TestaGeraTicket()
        {
            //arrange
            string placa = "ASD-1498";
            //act
            //string ticket = estacionamento.GeraTicket(placa);
            //assert
            //Assert.Equal();
        }

    }
}
