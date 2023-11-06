
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.domain.entities;
using prueba_tecnica.domain.repositories;
using prueba_tecnica.infrastructure.repositories;
using prueba_tecnica.infrastructure.DTOs;
using AutoMapper;

namespace prueba_tecnica.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class TrabajadorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TrabajadorController> _logger;
        private readonly ITrabajadorRepository _trabajadorRepository;

        public TrabajadorController(
            ILogger<TrabajadorController> logger,
            ITrabajadorRepository trabajadorRepository)
        {
            _trabajadorRepository = trabajadorRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public List<Trabajador> List()
        {
            return _trabajadorRepository.Listar();
        }

        [HttpGet]
        [Route("{idtrabajador:int}")]
        public Trabajador FindById(int idtrabajador)
        {
            return _trabajadorRepository.BuscarPorId(idtrabajador);
        }

        [HttpPost]
        [Route("create")]
        public void Guardar([FromBody] TrabajadorDTO trabajadorDTO)
        {

            var trabajador = _mapper.Map<Trabajador>(trabajadorDTO);
            _trabajadorRepository.Guardar(trabajador);
        }

        [HttpPut]
        [Route("update")]
        public void Update(Trabajador trabajador)
        {
            _trabajadorRepository.Actualizar(trabajador);
        }

        [HttpDelete]
        [Route("delete/{idtrabajador:int}")]
        public void Delete(int idtrabajador)
        {
            _trabajadorRepository.Eliminar(idtrabajador);
        }
    }

}