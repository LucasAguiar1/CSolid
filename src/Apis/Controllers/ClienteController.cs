using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apis.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    protected IClienteAppService _clienteAppService;

    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger, IClienteAppService clienteAppService)
    {
        _logger = logger;
        _clienteAppService = clienteAppService;
    }

    [HttpGet(Name = "ObterTodos")]
    public IEnumerable<Cliente> ObterTodos()
    {
       // 0 api exposta (serviço). - 1 apllication ( Domain infra dentro de aplication) 2 Domain  3 infra
        
      return   _clienteAppService.ObterTodos();
       
    }

    [HttpGet("{id}" ,Name = "ObterPorId")]
    public Cliente ObterPorId(int id)
    {
        return _clienteAppService.ObterPorId(id);

    }

    [HttpPut(Name = "Atualizar")]
    public IActionResult Atualizar([FromBody] Cliente cliente)
    {
        if (cliente == null)
        {
            return BadRequest("Corpo da requisição inválido.");
        }
        Cliente clienteAtualizado = _clienteAppService.Atualizar(cliente);

        // Pode retornar o cliente atualizado se necessário
        return Ok(clienteAtualizado);
    }
    [HttpPost(Name = "Cadastrar")]
    public IActionResult Cadatrar([FromBody] Cliente cliente)
    {
        if (cliente == null)
        {
            return BadRequest("Corpo da requisição inválido.");
        }
        Cliente clienteAdicionar = _clienteAppService.Adicionar(cliente);

        // Pode retornar o cliente atualizado se necessário
        return Ok(clienteAdicionar);

    }

    [HttpDelete("{id}", Name = "Deletar")]
    public void Deletar(int id)
    {
        _clienteAppService.Remover(id);

    }
}

