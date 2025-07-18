﻿using AutoMapper;
using HDP.Core.Entidade;
using HDP.Core.Enum;
using HDP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Application.Mapper
{
    public class HDPProfile: Profile
    {
        public HDPProfile()
        {
            this.CreateMap<Categoria, CategoriaViewModelInput>().ReverseMap();

            this.CreateMap<Categoria, CategoriaViewModelOutput>()
                .ForMember(s => s.Codigo, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(s => s.StatusDescricao, cfg => cfg.MapFrom(s => s.Status == StatusEnum.Ativo ? "Ativo" : "Inativo"));

            this.CreateMap<DepartamentoViewModelInput, Departamento>();

            this.CreateMap<Departamento, DepartamentoViewModelOutput>()
                  .ForMember(s => s.Codigo, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(s => s.StatusDescricao, cfg => cfg.MapFrom(s => s.Status == StatusEnum.Ativo ? "Ativo" : "Inativo"));

            this.CreateMap<CargoViewModelInput, Cargo>();

            this.CreateMap<Cargo, CargoViewModelOutput>()
                  .ForMember(s => s.Codigo, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(s => s.StatusDescricao, cfg => cfg.MapFrom(s => s.Status == StatusEnum.Ativo ? "Ativo" : "Inativo"));

            this.CreateMap<PerfilViewModelInput, Perfil>();

            this.CreateMap<Perfil, PerfilViewModelOutput>()
                  .ForMember(s => s.Codigo, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(s => s.StatusDescricao, cfg => cfg.MapFrom(s => s.Status == StatusEnum.Ativo ? "Ativo" : "Inativo"));


        }
    }
}
