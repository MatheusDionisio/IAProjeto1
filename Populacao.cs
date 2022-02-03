namespace Projeto1
{
    public class Populacao
    {
        public Populacao(List<Individuo> individuos){
            Individuos = individuos;
        }

        List<Individuo> Individuos {get;set;}

        public void ObtenhaMelhorIndividuo(){
            var resultado = Individuos.OrderBy(ind => ind.Fitness).Last();

            Console.WriteLine(resultado.ToString());
            // bool[] x = new bool[22]{false,false,false,false,true,false,true,false,false,false,false,true,true,false,false,false,false,false,false,false,false,true};
            // bool[] x2 = new bool[22]{true,false,false,false,false,false,false,false,false,true,true,false,false,false,false,true,false,true,false,false,false,false};

            // bool[] y = new bool[22]{true,false,false,false,true,false,true,false,true,false,false,false,true,true,true,false,true,true,true,false,true,true};

            // bool[] y2 = new bool[22]{true,true,false,true,true,true,false,true,true,true,false,false,false,true,false,true,false,true,false,false,false,true};
            // Console.WriteLine(new Individuo(x,y).ToString());
            // Console.WriteLine(new Individuo(x2,y2).ToString());
        }

        public void InicieFaseMutagenica(){
            Individuos = Individuos.Select(ind => ind.InicieMutacao()).ToList();
        }

        public void InicieFaseAcasalemento(){
            var proximaGeracao = new List<Individuo>();

            Individuo pai;
            Individuo mae;
            Individuo filho;

            for(int i = 0; i < 100; i++){
                pai = ObtenhaIndividuo();
                mae = ObtenhaIndividuo();
                
                while(mae == pai){

                    mae = ObtenhaIndividuo();

                }

                filho = IniciarReproducao(pai, mae);

                proximaGeracao.Add(filho);
            }

            Individuos = proximaGeracao;
        }

        private Individuo IniciarReproducao(Individuo pai, Individuo mae)
        {
            // RealizeCrossingOver(pai,mae);

            return RealizeCruzamento(pai, mae);        
        }

        private void RealizeCrossingOver(Individuo pai, Individuo mae){
            double valorSorteado = SelecaoHelper.ObtenhaValorAleatorio(1);

            if(valorSorteado <= 0.65){

                bool auxiliar;

                for(int i = 18;i<22;i++){
                    auxiliar = pai.GeneX[i];
                    pai.GeneX[i] = mae.GeneX[i];
                    mae.GeneX[i] = auxiliar;

                    auxiliar = pai.GeneY[i];
                    pai.GeneY[i] = mae.GeneY[i];
                    mae.GeneY[i] = auxiliar;
                }
            }
        }


        private Individuo RealizeCruzamento(Individuo pai, Individuo mae){
            bool[] GeneX = new bool[22];
            bool[] GeneY = new bool[22];

            for(int i = 0;i<22;i++){
                GeneX[i] = RealizeTrocaGene(pai.GeneX[i], mae.GeneX[i]);
                GeneY[i] = RealizeTrocaGene(pai.GeneY[i], mae.GeneY[i]);
            }

            return new Individuo(GeneX, GeneY);
        }

        private bool RealizeTrocaGene(bool gene1, bool gene2){
            if((gene1 && gene2)||(gene1 && !gene2)){
                return true;
            }

            return false;
        }   

        private Individuo ObtenhaIndividuo(){
            double fitnessTotal = 0;

            foreach(var individuo in Individuos){
                fitnessTotal += individuo.Fitness;
            }

            double fitness = SelecaoHelper.ObtenhaValorAleatorio(fitnessTotal);

            foreach(var individuo in Individuos){
                fitness -= individuo.Fitness;

                if(fitness <= 0){
                    return individuo;
                }
            }

            fitness = SelecaoHelper.ObtenhaValorAleatorio(Individuos.Count());

            return Individuos.ElementAt((int)fitness);

        }
    }
}