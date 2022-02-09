using Projeto1API.Extensions;
using Projeto1API.Processos;

namespace Projeto1API.Models
{
    public class Populacao
    {
        List<Individuo> Individuos {get;set;}
        List<Individuo> ProximaGeracao = new List<Individuo>();
        
        public Populacao(List<Individuo> individuos){
            Individuos = individuos;
        }

        public Individuo ObtenhaMelhorIndividuoPopulacao(){
            return Individuos.OrderBy(ind => ind.Fitness).Last();
        } 

        public void InicieFaseMutagenica(){
            Individuos = Individuos.Select(ind => ind.InicieMutacao()).ToList();
        }

        public void InicieFaseAcasalemento(){

            for(int i = 0; i < 50; i++){
                RealizeAcasalamento();
            }

            ObtenhaNovaGeracao();
        }

        private void RealizeAcasalamento()
        {
            var pai = ObtenhaIndividuoPopulacao();
            var mae = ObtenhaIndividuoPopulacao();
            
            while(mae == pai){

                mae = ObtenhaIndividuoPopulacao();

            }

            RealizeCruzamento(pai, mae); 
        }

        private void ObtenhaNovaGeracao()
        {
            ProximaGeracao.Add(ObtenhaMelhorIndividuoPopulacao());
            Individuos = ProximaGeracao;
            ProximaGeracao = new List<Individuo>();
        }

        private Individuo ObtenhaIndividuoPopulacao(){
            double fitnessTotal = Individuos.Sum(ind => ind.Fitness);

            double fitnessCorte = SelecaoHelper.ObtenhaValorAleatorio(fitnessTotal);

            return Individuos.First(ind => (fitnessCorte -= ind.Fitness)<= 0);

        }
        
        private void RealizeCruzamento(Individuo pai, Individuo mae){
            
            var filho = (Individuo)pai.Clone();
            var filha = (Individuo)mae.Clone();

            TrocaDeGenes(filho, filha);
            
            ProximaGeracao.Add(filho);
            ProximaGeracao.Add(filha);
        }

        private void TrocaDeGenes(Individuo pai, Individuo mae)
        {
            int pontoCorte =(int) SelecaoHelper.ObtenhaValorAleatorio(22);

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
    }
}