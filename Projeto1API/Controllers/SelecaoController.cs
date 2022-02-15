using Microsoft.AspNetCore.Mvc;
using Projeto1API.Models;
using Projeto1API.Helper;

namespace Projeto1API.Controllers;

[ApiController]
[Route("[controller]")]
public class SelecaoController : ControllerBase
{
    [HttpGet]
    [Route("Melhores")]
    public List<double> Melhores()
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<double> melhores = new List<double>(){};

        for(int i = 0; i < 40; i++){

            melhores.Add(populacao.ObtenhaMelhorIndividuoPopulacao().Fitness);

            populacao.InicieFaseAcasalemento();

            populacao.InicieFaseMutagenica();

            populacao.ObtenhaNovaGeracao();
        }
       return melhores;
    }

    [HttpGet]
    [Route("Populacoes/{quantidade}")]
    public List<IEnumerable<double>> Populacoes(int quantidade)
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<IEnumerable<double>> populacoes = new List<IEnumerable<double>>(){};

         for(int i = 0; i < quantidade; i++){

            populacoes.Add(populacao.Individuos.Select(i => i.Fitness));

            populacao.InicieFaseAcasalemento();

            populacao.InicieFaseMutagenica();

            populacao.ObtenhaNovaGeracao();
        }

       return populacoes;
    }
}
