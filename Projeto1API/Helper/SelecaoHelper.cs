using Projeto1API.Models;

namespace Projeto1API.Helper
{
    public static class SelecaoHelper
    {
        public static double ObtenhaValorAleatorio(double valor = 1) =>
            valor * new Random().NextDouble();

        public static List<Individuo> ObtenhaIndividuosAleatorios(){
            var individuos = new List<Individuo>();

            for(int i =0;i<100;i++){

                individuos.Add(ObtenhaIndividuoAleatorio());
            }

            return individuos;
        }

        private static Individuo ObtenhaIndividuoAleatorio() =>
            new Individuo(ObtenhaGeneAleatorio(), ObtenhaGeneAleatorio());

        private static bool[] ObtenhaGeneAleatorio()
        {
            bool[] gene = new bool[22];

            for(int i = 0; i < 22; i++){
                gene[i] = SelecaoHelper.ObtenhaValorAleatorio() < 0.3;
            }

            return gene;
        }

        public static double F6(double x, double y)
        {
            double primeiroTermo = Math.Pow(
                Math.Sin(
                    Math.Sqrt(
                        Math.Pow(x,2) + Math.Pow(y,2)
                    )
                ),2
            ) - 0.5;

            double segundoTermo = Math.Pow(
                (1 + 0.001 * (Math.Pow(x,2) + Math.Pow(y,2))
                
                ),2
            ) ;

            return 0.5 - (primeiroTermo / segundoTermo);
        }

    }
}