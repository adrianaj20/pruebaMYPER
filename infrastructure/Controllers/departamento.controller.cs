
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
    public class DepartamentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DepartamentoController> _logger;
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(
            ILogger<DepartamentoController> logger,
            IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public List<Departamento> List()
        {
            return _departamentoRepository.Listar();
        }

        [HttpGet]
        [Route("{iddepartamento:int}")]
        public Departamento FindById(int iddepartamento)
        {
            return _departamentoRepository.BuscarPorId(iddepartamento);
        }

        [HttpPost]
        [Route("create")]
        public void Guardar([FromBody] DepartamentoDTO departamentoDTO)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            _departamentoRepository.Guardar(departamento);
        }

        [HttpPut]
        [Route("update")]
        public void Update(Departamento departamento)
        {
            _departamentoRepository.Actualizar(departamento);
        }

        [HttpDelete]
        [Route("delete/{iddepartamento:int}")]
        public void Delete(int iddepartamento)
        {
            _departamentoRepository.Eliminar(iddepartamento);
        }
    }

}