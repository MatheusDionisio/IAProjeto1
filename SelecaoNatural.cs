namespace Projeto1
{
    public class SelecaoNatural
    {
        public void Iniciar()
        {
            var populacao = ObtenhaPopulacaoIncial();

            populacao.InicieFaseAcasalemento();

            for(int i = 0; i < 40; i++){
                Console.WriteLine($"Geração {i}");

                populacao.InicieFaseMutagenica();

                populacao.InicieFaseAcasalemento();
            }

            populacao.ObtenhaMelhorIndividuo();
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