using AutoMapper;
using backendApi.DTOs;
using backendApi.Models;
using System.Globalization;

namespace backendApi.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                destino.NombreDepartamento,
                opt => opt.MapFrom(origen => origen.IdDepartamentoNavigation.Nombre)
                ).ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => origen.FechaContrato.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(destino =>
                destino.IdDepartamentoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaContrato, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );
            #endregion
        }
    }
}
