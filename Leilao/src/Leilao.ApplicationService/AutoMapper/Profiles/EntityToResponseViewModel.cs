using AutoMapper;
using Leilao.ApplicationService.ViewModels.Response;
using Leilao.Domain.Models.Entities;
using System;

namespace Leilao.ApplicationService.AutoMapper.Profiles {

    public class EntityToResponseViewModel : Profile {

        public EntityToResponseViewModel() {

            //Users
            CreateMap<User, UserResponseViewModel>().ConvertUsing(x => new UserResponseViewModel { Id = x.Id, BirthDate = x.BirthDate, Name = x.Name, Age = CalcAge(x.BirthDate)});

            //Products
            CreateMap<Product, ProductResponseViewModel>().ConvertUsing(x => new ProductResponseViewModel { Id = x.Id, Price = x.Price, Name = x.Name});

        }

        private int CalcAge(DateTime birthDate) {

            int age = DateTime.Now.Year - birthDate.Year;

            if(DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age -= 1;

            return age;
        }
    }
}
