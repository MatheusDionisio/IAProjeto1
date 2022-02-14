using System.Collections;
using Projeto1API.Models;
using Projeto1API.Helper;

namespace Projeto1API.Extensions
{
    public static class MetodosDeExtensao
    {
        public static Individuo InicieMutacao(this Individuo individuo){
            foreach(var cromossomo in individuo.Gene){
               cromossomo.MuteCromossomo();
            }
            individuo.CalculeNovaFitness();

            return individuo;
        }
        
        public static bool MuteCromossomo(this bool gene){
            double valorSorteado = SelecaoHelper.ObtenhaValorAleatorio();
            if(valorSorteado <= 0.008){
                gene = !gene;
                return true;
            }
            return false;
        }

        public static Individuo MuteMelhor(this Individuo individuo){
            int valorSorteado = (int)SelecaoHelper.ObtenhaValorAleatorio(44);
            
            individuo.Gene[valorSorteado] = !individuo.Gene[valorSorteado];

            individuo.CalculeNovaFitness();
            return individuo;
        }

        public static uint BoolArrayToInt(this bool[] bits){
            BitArray arr = new BitArray(bits);
            uint[] array = new uint[1];
            arr.CopyTo(array, 0);
            return array[0];
        }

        public static string Texto(this bool[] bits){
            
            string palavra = "";

            foreach(var bit in bits){
                if(bit)
                    palavra+="1";
                else
                    palavra+="0";    
            }

            return palavra;
        }
        
    }
}