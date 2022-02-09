using System.Collections;
using Projeto1API.Extensions;
using Projeto1API.Processos;

namespace Projeto1API.Models
{
    public class Individuo : ICloneable
    {
        public Individuo(bool[] geneX, bool[] geneY){
            GeneX =geneX;
            GeneY =geneY;
            ValorX = -100 +(GeneX.BoolArrayToInt() * (200/(Math.Pow(2,22)-1)));
            ValorY = -100 +(GeneY.BoolArrayToInt() * (200/(Math.Pow(2,22)-1)));
            Fitness = SelecaoHelper.F6(ValorX,ValorY);
        }

        public bool[] GeneX {get;set;}

        public bool[] GeneY {get;set;}

        public double Fitness {get; set;}

        private double ValorX {get; set;}

        private double ValorY {get; set;}

        public override string ToString() =>
            $"Valor x = {this.ValorX}, y = {this.ValorY}, fitness = {this.Fitness}";

        public object Clone() =>
            this.MemberwiseClone();
    }
}