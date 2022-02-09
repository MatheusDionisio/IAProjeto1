namespace Projeto1
{
    public class Populacao
    {
        public Populacao(List<Individuo> individuos){
            Individuos = individuos;
        }

        List<Individuo> Individuos {get;set;}
        List<Individuo> ProximaGeracao = new List<Individuo>();

        public Individuo ObtenhaMelhorIndividuo(){
            var resultado = Individuos.OrderBy(ind => ind.Fitness).Last();

            // Console.WriteLine("Resultado: " + resultado.ToString());
            // bool[] x = new bool[22]{false,false,false,false,true,false,true,false,false,false,false,true,true,false,false,false,false,false,false,false,false,true};
            bool[] x2 = new bool[22]{true,false,false,false,false,false,false,false,false,true,true,false,false,false,false,true,false,true,false,false,false,false};

            // bool[] y = new bool[22]{true,false,false,false,true,false,true,false,true,false,false,false,true,true,true,false,true,true,true,false,true,true};

            bool[] y2 = new bool[22]{true,true,false,true,true,true,false,true,true,true,false,false,false,true,false,true,false,true,false,false,false,true};
            // Console.WriteLine(new Individuo(x,y).ToString());
            // Console.WriteLine("Exemplo1: " + new Individuo(x2,y2).ToString());
            // Console.WriteLine("ResultadoIdeal: " + resultado.F6(0,0));

            return resultado;
        }

        public void InicieFaseMutagenica(){
            Individuos = Individuos.Select(ind => ind.InicieMutacao()).ToList();
        }

        public void InicieFaseAcasalemento(){
            Individuo pai;
            Individuo mae;

            for(int i = 0; i < 50; i++){
                pai = ObtenhaIndividuo();
                mae = ObtenhaIndividuo();
                
                while(mae == pai){

                    mae = ObtenhaIndividuo();

                }

                RealizeCruzamento(pai, mae); 
            }
            var individuo = ObtenhaMelhorIndividuo();

            // Console.WriteLine(individuo.ToString() + $" geneX = {individuo.GeneX.Texto()} geneY = {individuo.GeneY.Texto()}");
            ProximaGeracao.Add(individuo);
            Individuos = ProximaGeracao;
            ProximaGeracao = new List<Individuo>();
        }

        private void RealizeCruzamento(Individuo pai, Individuo mae){
            
            int valorSorteado =(int) SelecaoHelper.ObtenhaValorAleatorio(22);

            TrocaDeGenes(pai, mae, valorSorteado);

            Individuo filho = new Individuo(pai.GeneX.Select(gene => gene).ToArray(),pai.GeneY.Select(gene => gene).ToArray());

            Individuo filha = new Individuo(mae.GeneX.Select(gene => gene).ToArray(),mae.GeneY.Select(gene => gene).ToArray());

            TrocaDeGenes(pai, mae, valorSorteado);
            
            ProximaGeracao.Add(filho);
            ProximaGeracao.Add(filha);
        }

        private void TrocaDeGenes(Individuo pai, Individuo mae, int pontoCorte)
        {
            bool auxiliar;
            for(int i = pontoCorte;i<22;i++){
                auxiliar = pai.GeneX[i];
                pai.GeneX[i] = mae.GeneX[i];
                mae.GeneX[i] = auxiliar;

                auxiliar = pai.GeneY[i];
                pai.GeneY[i] = mae.GeneY[i];
                mae.GeneY[i] = auxiliar;
            }
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