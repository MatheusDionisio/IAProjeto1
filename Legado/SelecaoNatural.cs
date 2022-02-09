namespace Projeto1
{
    public class SelecaoNatural
    {
        public void Iniciar()
        {
            var populacao = ObtenhaPopulacaoIncial();
            var individuo = populacao.ObtenhaMelhorIndividuo();

            populacao.InicieFaseAcasalemento();
            Console.WriteLine(individuo.ToString() + $" geneX = {individuo.GeneX.Texto()} geneY = {individuo.GeneY.Texto()}");
            for(int i = 0; i < 4000; i++){

                populacao.InicieFaseMutagenica();

                populacao.InicieFaseAcasalemento();
                
                populacao.ObtenhaMelhorIndividuo();
            }

            individuo = populacao.ObtenhaMelhorIndividuo();

            Console.WriteLine(individuo.ToString() + $" geneX = {individuo.GeneX.Texto()} geneY = {individuo.GeneY.Texto()}");
            Console.WriteLine(individuo.ToString());
        }

        private Populacao ObtenhaPopulacaoIncial(){
            bool[] geneX;
            bool[] geneY;

            Individuo individuo;

            var individuos = new List<Individuo>();

            for(int i =0;i<100;i++){
                geneX = ObtenhaGene();
                geneY = ObtenhaGene();

                individuo = new Individuo(geneX, geneY);
                individuos.Add(individuo);
            }

            var populacao = new Populacao(individuos);
            return populacao;
        }

        private bool[] ObtenhaGene()
        {
            double valorSorteado = 0;
            bool[] gene = new bool[22];

            for(int i = 0; i < 22; i++){
                valorSorteado = SelecaoHelper.ObtenhaValorAleatorio(1);

                gene[i] = valorSorteado < 0.5;
            }

            return gene;
        }
    }
}