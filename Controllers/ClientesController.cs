using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private static readonly List<Cliente> Clientes = new();

    [HttpGet]
    public ActionResult<List<Cliente>> ListarClientes()
    {
        return Ok(Clientes);
    }

    [HttpPost]
    public ActionResult<Cliente> CadastrarCliente(Cliente cliente)
    {
        cliente.Id = Clientes.Count + 1;

        Clientes.Add(cliente);

        return Ok(cliente);
    }

    public static List<Cliente> ObterClientes()
{
    return Clientes;
}
}