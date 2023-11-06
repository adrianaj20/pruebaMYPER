
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
    public class ProvinciaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ProvinciaController> _logger;
        private readonly IProvinciaRepository _provinciaRepository;

        public ProvinciaController(
            ILogger<ProvinciaController> logger,
            IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public List<Provincia> List()
        {
            return _provinciaRepository.Listar();
        }

        [HttpGet]
        [Route("{idprovincia:int}")]
        public Provincia FindById(int idprovincia)
        {
            return _provinciaRepository.BuscarPorId(idprovincia);
        }

        [HttpPost]
        [Route("create")]
        public void Guardar([FromBody] ProvinciaDTO prvinciaDTO)
        {
            var provincia = _mapper.Map<Provincia>(prvinciaDTO);
            _provinciaRepository.Guardar(provincia);
        }

        [HttpPut]
        [Route("update")]
        public void Update(Provincia provincia)
        {
            _provinciaRepository.Actualizar(provincia);
        }

        [HttpDelete]
        [Route("delete/{idprovincia:int}")]
        public void Delete(int idprovincia)
        {
            _provinciaRepository.Eliminar(idprovincia);
        }
    }
}