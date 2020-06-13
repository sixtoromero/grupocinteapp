using grupocinte.Application.DTO;
using grupocinte.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace grupocinte.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TipoIdentificacion, TipoIdentificacionDTO>().ReverseMap();
            CreateMap<Usuarios, UsuariosDTO>().ReverseMap();
        }
    }
}
