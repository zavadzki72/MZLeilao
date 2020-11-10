using AutoMapper;
using Leilao.ApplicationService.AutoMapper.Config;
using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.Services;
using Leilao.CrossCutting.Bus;
using Leilao.Data.SqlServer.Repositories;
using Leilao.Domain.CommandHandlers;
using Leilao.Domain.Commands.Bid;
using Leilao.Domain.Commands.Product;
using Leilao.Domain.Commands.User;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Core.Notifications;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leilao.CrossCutting.IoC {

    public static class NativeInjectorBootStrapper {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // AutoMapper
            var config = AutoMapperConfig.RegisterMaps();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // ApplicationService
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IProductApplicationService, ProductApplicationService>();
            services.AddScoped<IBidApplicationService, BidApplicationService>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            // Domain - Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // Domain - Commands
            //// User
            services.AddScoped<IRequestHandler<CreateUserCommand, User>, UserCommandHandler>();
            //// Product
            services.AddScoped<IRequestHandler<CreateProductCommand, Product>, ProductCommandHandler>();
            //// Bid
            services.AddScoped<IRequestHandler<CreateBidCommand, Bid>, BidCommandHandler>();

            // Repositories - SqlServer
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBidRepository, BidRepository>();

        }

    }
}
