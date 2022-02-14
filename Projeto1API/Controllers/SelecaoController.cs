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
    public List<double> Melhores()
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<double> melhores = new List<double>(){};

        for(int i = 0; i < 4000; i++){

            melhores.Add(populacao.ObtenhaMelhorIndividuoPopulacao().Fitness);

            populacao.InicieFaseAcasalemento();

            populacao.InicieFaseMutagenica();

            populacao.ObtenhaNovaGeracao();
        }
       return melhores;
    }

    [HttpPost]
    [Route("Populacoes")]
    public List<Populacao> Populacoes()
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<Populacao> populacoes = new List<Populacao>(){(Populacao)populacao.Clone()};

        populacao.InicieFaseAcasalemento();

        for(int i = 0; i < 4000; i++){

            populacao.InicieFaseMutagenica();

            populacao.InicieFaseAcasalemento();
            
            populacoes.Add((Populacao)populacao.Clone());
        }

       return populacoes;
    }
}
