using Microsoft.AspNetCore.Mvc;
using Projeto1API.Models;
using Projeto1API.Helper;

namespace Projeto1API.Controllers;

[ApiController]
[Route("[controller]")]
public class SelecaoController : ControllerBase
{
    [HttpPost]
    [Route("Melhores")]
    public List<Individuo> Melhores()
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<Individuo> melhores = new List<Individuo>(){populacao.ObtenhaMelhorIndividuoPopulacao()};

        populacao.InicieFaseAcasalemento();

        for(int i = 0; i < 40; i++){

            // populacao.InicieFaseMutagenica();

            populacao.InicieFaseAcasalemento();
            
            melhores.Add(populacao.ObtenhaMelhorIndividuoPopulacao());
        }

        foreach(var ind in melhores){
            Console.WriteLine(ind.ToString());
        }

        Console.WriteLine("Fim");

       return melhores;
    }

    [HttpPost]
    [Route("Populacoes")]
    public List<Populacao> Populacoes()
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<Populacao> populacoes = new List<Populacao>(){(Populacao)populacao.Clone()};

        populacao.InicieFaseAcasalemento();

        for(int i = 0; i < 40; i++){

            // populacao.InicieFaseMutagenica();

            populacao.InicieFaseAcasalemento();
            
            populacoes.Add((Populacao)populacao.Clone());
        }

       return populacoes;
    }
}
