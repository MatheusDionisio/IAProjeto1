namespace Projeto1
{
    public static class MetodosDeExtensao
    {
        public static Individuo InicieMutacao(this Individuo individuo){
            
            for(int i=0;i<22;i++){
                individuo.GeneX[i].MuteGene();
                individuo.GeneY[i].MuteGene();
            }
            return individuo;
        }
        
        public static void MuteGene(this bool gene){
            double valorSorteado = SelecaoHelper.ObtenhaValorAleatorio(1);
            if(valorSorteado <= 0.008){
                gene = !gene;
            }
        }

        public static uint BoolArrayToInt(this bool[] bits){
            uint r = 0;

            for(int i = 0; i < bits.Length; i++) if(bits[i]) r |=(uint) 1 << (bits.Length - i);

            return r;
        }
        
    }
}