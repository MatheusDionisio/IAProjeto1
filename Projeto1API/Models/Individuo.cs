using System.Collections;
using Projeto1API.Extensions;

namespace Projeto1API.Models
{
    public class Individuo : ICloneable
    {
        public Individuo(bool[] geneX, bool[] geneY){
            GeneX =geneX;
            GeneY =geneY;
            Fitness = ObtenhaFitness();
        }

        public bool[] GeneX {get;set;}

        public bool[] GeneY {get;set;}

        public double ValorX {get; set;}

        public double ValorY {get; set;}
        public uint RealX {get; set;}

        public uint RealY {get; set;}

        public double Fitness {get; set;}
    

        public double ObtenhaFitness(){

            uint geneXint = GeneX.BoolArrayToInt();
            uint geneYint = GeneY.BoolArrayToInt();

            this.RealX = geneXint;
            this.RealY = geneYint;

            this.ValorX = -100 +(geneXint * (200/(Math.Pow(2,22)-1)));
            this.ValorY = -100 +(geneYint * (200/(Math.Pow(2,22)-1)));

            var x = this.ValorX;
            var y = this.ValorY;

           return F6(x,y);
            
        }

        public double F6(double x, double y)
        {
            double primeiroTermo = Math.Pow(
                Math.Sin(
                    Math.Sqrt(
                        Math.Pow(x,2) + Math.Pow(y,2)
                    )
                ),2
            ) - 0.5;

            //(1,0 + 0,001(x^2 + y^2 ))^2
            double segundoTermo = Math.Pow(
                (1 + 0.001 * (Math.Pow(x,2) + Math.Pow(y,2))
                
                ),2
            ) ;

            return 0.5 - (primeiroTermo / segundoTermo);
        }

        public override string ToString()
        {
            return $"Valor x = {this.ValorX}, y = {this.ValorY}, fitness = {this.Fitness}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();;
        }
    }
}