using AutoMapper;
using prueba_tecnica.domain.entities;

namespace prueba_tecnica.infrastructure.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trabajador, TrabajadorDTO>(); // Mapeo
            CreateMap<TrabajadorDTO, Trabajador>(); // Mapeo inverso 

            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<ProvinciaDTO, Provincia>();

            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();
        }
    }
}
