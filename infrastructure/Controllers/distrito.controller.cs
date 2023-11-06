
using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.domain.entities;
using prueba_tecnica.domain.repositories;
using prueba_tecnica.infrastructure.DTOs;
using prueba_tecnica.infrastructure.repositories;


namespace prueba_tecnica.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class DistritoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DistritoController> _logger;
        private readonly IDistritoRepository _distritoRepository;

        public DistritoController(
            ILogger<DistritoController> logger,
            IDistritoRepository distritoRepository)
        {
            _distritoRepository = distritoRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public List<Distrito> List()
        {
            return _distritoRepository.Listar();
        }

        [HttpGet]
        [Route("{iddistrito:int}")]
        public Distrito FindById(int iddistrito)
        {
            return _distritoRepository.BuscarPorId(iddistrito);
        }

        [HttpPost]
        [Route("create")]
        public void Guardar([FromBody] DistritoDTO distritoDTO)
        {

            var distrito = _mapper.Map<Distrito>(distritoDTO);
            _distritoRepository.Guardar(distrito);
        }

        [HttpPut]
        [Route("update")]
        public void Update(Distrito distrito)
        {
            _distritoRepository.Actualizar(distrito);
        }

        [HttpDelete]
        [Route("delete/{iddistrito:int}")]
        public void Delete(int iddistrito)
        {
            _distritoRepository.Eliminar(iddistrito);
        }
    }
}