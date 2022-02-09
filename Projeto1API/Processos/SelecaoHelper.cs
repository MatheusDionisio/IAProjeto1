using System.Collections;
using Projeto1API.Models;

namespace Projeto1API.Processos
{
    public static class SelecaoHelper
    {
        public static double ObtenhaValorAleatorio(double valor){
            var rand = new Random();

            return valor * rand.NextDouble();
        }

        public static List<Individuo> ObtenhaIndividuosAleatorios(){
            Individuo individuo;
            var individuos = new List<Individuo>();

            for(int i =0;i<100;i++){

                individuo = new Individuo(ObtenhaGene(), ObtenhaGene());
                individuos.Add(individuo);
            }

            return individuos;
        }

        private static bool[] ObtenhaGene()
        {
            double valorSorteado = 0;
            bool[] gene = new bool[22];

            for(int i = 0; i < 22; i++){
                valorSorteado = SelecaoHelper.ObtenhaValorAleatorio(1);

                gene[i] = valorSorteado < 0.5;
            }

            return gene;
        }

    }
}