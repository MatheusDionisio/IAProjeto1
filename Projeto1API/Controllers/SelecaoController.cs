using Microsoft.AspNetCore.Mvc;
using Projeto1API.Extensions;
using Projeto1API.Models;
using Projeto1API.Processos;

namespace Projeto1API.Controllers;

[ApiController]
[Route("[controller]")]
public class SelecaoController : ControllerBase
{
    [HttpPost]
    public List<Individuo> Post([FromBody] SelecaoParametro parametros)
    {
        var populacao = new Populacao(SelecaoHelper.ObtenhaIndividuosAleatorios());
        
        List<Individuo> melhores = new List<Individuo>(){populacao.ObtenhaMelhorIndividuoPopulacao()};

        populacao.InicieFaseAcasalemento();

        for(int i = 0; i < parametros.NumeroGeracoes; i++){

            populacao.InicieFaseMutagenica();

            populacao.InicieFaseAcasalemento();
            
            melhores.Add(populacao.ObtenhaMelhorIndividuoPopulacao());
        }

       return melhores;
    }
}
