using Projeto1API.Extensions;
using Projeto1API.Helper;

namespace Projeto1API.Models
{
    public class Populacao : ICloneable
    {
        List<Individuo> Individuos {get;set;}
        List<Individuo> ProximaGeracao = new List<Individuo>();
        
        public Populacao(List<Individuo> individuos){
            Individuos = individuos;
        }

        public Individuo ObtenhaMelhorIndividuoPopulacao() =>
            Individuos.OrderBy(ind => ind.Fitness).Last();

        public void InicieFaseMutagenica() =>
            ProximaGeracao = ProximaGeracao.Select(ind => ind.InicieMutacao()).ToList();

        public void InicieFaseAcasalemento(){

            for(int i = 0; i < 49; i++){
                RealizeAcasalamento();
            }

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

        public void ObtenhaNovaGeracao()
        {
            var melhor = ObtenhaMelhorIndividuoPopulacao();
            var melhorMutad = (Individuo)melhor.Clone();

            ProximaGeracao.Add(melhor);
            ProximaGeracao.Add(melhorMutad.MuteMelhor());

            Individuos = ProximaGeracao.Select(ind => ind).ToList();
            ProximaGeracao = new List<Individuo>();
        }

        private Individuo ObtenhaIndividuoPopulacao(){
            double fitnessTotal = Individuos.Sum(ind => ind.Fitness);

            double fitnessCorte = SelecaoHelper.ObtenhaValorAleatorio(fitnessTotal);

            foreach(Individuo ind in Individuos){
                fitnessCorte -= ind.Fitness;

                if(fitnessCorte <= 0){
                    return ind;
                }
            }

            return Individuos.First();

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
                auxiliar = pai.Gene[i];
                pai.Gene[i] = mae.Gene[i];
                mae.Gene[i] = auxiliar;
            }
            pontoCorte =(int) SelecaoHelper.ObtenhaValorAleatorio(22);
            for(int i = 22 + pontoCorte;i<44;i++){
                auxiliar = pai.Gene[i];
                pai.Gene[i] = mae.Gene[i];
                mae.Gene[i] = auxiliar;
            }
            pai.CalculeNovaFitness();
            mae.CalculeNovaFitness();
        }
        // private void TrocaDeGenes(Individuo pai, Individuo mae)
        // {
        //     int pontoCorte =(int) SelecaoHelper.ObtenhaValorAleatorio(44);

        //     bool auxiliar;
        //     for(int i = pontoCorte;i<44;i++){
        //         auxiliar = pai.Gene[i];
        //         pai.Gene[i] = mae.Gene[i];
        //         mae.Gene[i] = auxiliar;
        //     }
        //     pai.CalculeNovaFitness();
        //     mae.CalculeNovaFitness();
        // }

        public object Clone() =>
            this.MemberwiseClone();
    }
}