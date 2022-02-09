using Microsoft.AspNetCore.Mvc;
using Projeto1API.Processos;

namespace Projeto1API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public void Get()
    {
        var selecao = new SelecaoNatural();

        selecao.Iniciar();
    }
}
