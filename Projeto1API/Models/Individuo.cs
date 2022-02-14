using Projeto1API.Extensions;
using Projeto1API.Helper;

namespace Projeto1API.Models
{
    public class Individuo : ICloneable
    {
        public Individuo(bool[] gene){
            Gene = gene;
            CalculeNovaFitness();
        }

        public bool[] Gene {get;set;}

        public double Fitness {get; set;}

        private double ValorX {get; set;}

        private double ValorY {get; set;}

        public override string ToString() =>
            $"Valor x = {this.ValorX}, y = {this.ValorY}, fitness = {this.Fitness}";

        public object Clone() =>
            this.MemberwiseClone();

        public void CalculeNovaFitness()
        {
            var geneX = Gene.Take(22).ToArray();
            var geneY = Gene.Skip(22).ToArray();

            ValorX = Math.Round(-100 +(geneX.BoolArrayToInt() * (200/(Math.Pow(2,22)-1))), 8);
            ValorY = Math.Round(-100 +(geneY.BoolArrayToInt() * (200/(Math.Pow(2,22)-1))), 8);
            
            Fitness = Math.Round(SelecaoHelper.F6(ValorX,ValorY), 8);
        }
    }
}