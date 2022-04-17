using Alura.Estacionamento.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes.ClassData
{
    public class ClassDataVeiculo : Veiculo, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Veiculo
                {
                    Proprietario = "André Silva",
                    Placa = "ASD-9999",
                    Cor="Verde",
                    Modelo="Fusca"
                }
                //,
                //new Veiculo
                //{
                //    Proprietario = "Pablo Silva",
                //    Placa = "QWE-9999",
                //    Cor="AZUL",
                //    Modelo="VOYAGE"
                //}
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public void Acelerar(int tempoSeg)
        {
            base.Acelerar(tempoSeg);
        }

        public void Frear(int tempoSeg)
        {
            base.Frear(tempoSeg);
        }
    }
}
