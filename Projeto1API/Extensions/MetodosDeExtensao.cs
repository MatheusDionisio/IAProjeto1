using System.Collections;
using Projeto1API.Models;
using Projeto1API.Helper;

namespace Projeto1API.Extensions
{
    public static class MetodosDeExtensao
    {
        public static Individuo InicieMutacao(this Individuo individuo){
            
            for(int i=0;i<44;i++){
                individuo.Gene[i].MuteGene();
            }
            individuo.CalculeNovaFitness();

            return individuo;
        }
        
        public static void MuteGene(this bool gene){
            double valorSorteado = SelecaoHelper.ObtenhaValorAleatorio(1);
            if(valorSorteado <= 0.0008){
                gene = !gene;
            }
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