using System.Collections;

namespace Projeto1
{
    public class Individuo
    {
        public Individuo(bool[] geneX, bool[] geneY){
            GeneX =geneX;
            GeneY =geneY;

            BitArray arr = new BitArray(geneX);
            uint[] array = new uint[1];
            arr.CopyTo(array, 0);
            arr = new BitArray(geneY);
            uint[] array2 = new uint[1];
            arr.CopyTo(array2, 0);
            
            Fitness = ObtenhaFitness(array[0], array2[0]);
        }

        public bool[] GeneX {get;set;}

        public bool[] GeneY {get;set;}

        public double ValorX {get; set;}

        public double ValorY {get; set;}
        public uint RealX {get; set;}

        public uint RealY {get; set;}

        public double Fitness {get; set;}
    

        public double ObtenhaFitness(uint geneXint, uint geneYint){


            this.RealX = geneXint;
            this.RealY = geneYint;

            this.ValorX = -100 +(geneXint * (200/(Math.Pow(2,22)-1)));
            this.ValorY = -100 +(geneYint * (200/(Math.Pow(2,22)-1)));

            var x = this.ValorX;
            var y = this.ValorY;

            //(sen √(x^ 2 + y^2))^2 - 0,5
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

    }
}