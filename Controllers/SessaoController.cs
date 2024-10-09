using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("{controller}")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma sessão ao banco de dados
    /// </summary>
    /// <param name="sessaoDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
    {
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoID), new { id = sessao.Id }, sessaoDto);
        }
    }



    /// <summary>
    /// Consulta toda a lista de sessões cadastrados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadSessaoDto> RecuperaSessao([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {

        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.Skip(skip).Take(take));

    }


    /// <summary>
    /// Consulta sessão cadastrados por ID
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso consulta seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RecuperaSessaoID(int id)
    {
        var sessao = _context.Cinemas.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao == null) return NotFound();
        var cinemaDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(cinemaDto);
    }

}
