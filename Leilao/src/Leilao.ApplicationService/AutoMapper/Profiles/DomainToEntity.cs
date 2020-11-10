using AutoMapper;
using Leilao.Domain.Commands.Bid;
using Leilao.Domain.Commands.Product;
using Leilao.Domain.Commands.User;
using Leilao.Domain.Models.Entities;

namespace Leilao.ApplicationService.AutoMapper.Profiles {

    public class DomainToEntity : Profile {

        public DomainToEntity() {

            //Users
            CreateMap<CreateUserCommand, User>().ConvertUsing(x => new User(x.Name, x.BirthDate));

            //Products
            CreateMap<CreateProductCommand, Product>().ConvertUsing(x => new Product(x.Name, x.Price));

            //Bids
            CreateMap<CreateBidCommand, Bid>().ConvertUsing(x => new Bid(x.ProductId, x.UserId, x.PriceOffer, x.QtdBids, x.Start, x.End, false));

        }

    }
}
