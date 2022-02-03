namespace Projeto1
{
    public static class SelecaoHelper
    {
        public static double ObtenhaValorAleatorio(double valor){
            var rand = new Random();

            return valor * rand.NextDouble();
        }
    }
}