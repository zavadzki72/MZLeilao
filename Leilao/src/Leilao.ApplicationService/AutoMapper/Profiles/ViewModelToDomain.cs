using AutoMapper;
using Leilao.ApplicationService.ViewModels.Request.Bid;
using Leilao.ApplicationService.ViewModels.Request.Product;
using Leilao.ApplicationService.ViewModels.Request.User;
using Leilao.Domain.Commands.Bid;
using Leilao.Domain.Commands.Product;
using Leilao.Domain.Commands.User;

namespace Leilao.ApplicationService.AutoMapper.Profiles {
    public class ViewModelToDomain : Profile {

        public ViewModelToDomain() {

            //Users
            CreateMap<CreateUserRequestViewModel, CreateUserCommand>().ConvertUsing(x => new CreateUserCommand(x.Name, x.BirthDate));

            //Products
            CreateMap<CreatePrductRequestViewModel, CreateProductCommand>().ConvertUsing(x => new CreateProductCommand(x.Name, x.Price));

            //Bids
            CreateMap<CreateBidRequestViewModel, CreateBidCommand>().ConvertUsing(x => new CreateBidCommand(x.IdProduct, x.IdUser, x.PriceOffer, x.QtdBids, x.StartTime, x.EndTime));
        }

    }
}
