using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/pets")]
public class PetsController : ControllerBase
{
    private static readonly List<Pet> Pets = new();

    [HttpGet]
    public ActionResult<List<Pet>> ListarPets()
    {
        return Ok(Pets);
    }

    [HttpPost]
    public ActionResult<Pet> CadastrarPet(Pet pet)
    {
        bool clienteExiste = ClientesController
            .ObterClientes()
            .Any(c => c.Id == pet.ClienteId);

        if (!clienteExiste)
        {
            return BadRequest("O ClienteId informado não existe.");
        }

        pet.Id = Pets.Count + 1;

        Pets.Add(pet);

        return Ok(pet);
    }

    [HttpGet("cliente/{clienteId:int}")]
    public ActionResult<List<Pet>> ListarPetsPorCliente(int clienteId)
    {
        var petsDoCliente = Pets
            .Where(p => p.ClienteId == clienteId)
            .ToList();

        return Ok(petsDoCliente);
    }
}