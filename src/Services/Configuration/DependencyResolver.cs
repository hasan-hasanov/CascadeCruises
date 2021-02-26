using Adapter.EF.Commands.DeleteCruise;
using Adapter.EF.Commands.DeletePassenger;
using Adapter.EF.Commands.DeleteShip;
using Adapter.EF.Commands.InsertCruise;
using Adapter.EF.Commands.InsertPassenger;
using Adapter.EF.Commands.InsertShip;
using Adapter.EF.Commands.UpdateCruise;
using Adapter.EF.Commands.UpdatePassenger;
using Adapter.EF.Commands.UpdateShip;
using Adapter.EF.Context;
using Adapter.EF.Decorators;
using Adapter.EF.Queries.GetCabinClasses;
using Adapter.EF.Queries.GetCruiseById;
using Adapter.EF.Queries.GetCruiseInformation;
using Adapter.EF.Queries.GetCruiseProfits;
using Adapter.EF.Queries.GetPassengerAgeAboveSixty;
using Adapter.EF.Queries.GetPassengerReservation;
using Adapter.EF.Queries.GetProts;
using Adapter.EF.Queries.GetShipById;
using Adapter.EF.Queries.GetShipByMaxRoomsCount;
using Adapter.EF.Queries.GetShipInformation;
using Adapter.EF.Queries.GetShipInformationWithPorts;
using Common.Constants;
using Core.Commands;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using Infrastructure.Validations.CruiseValidations;
using Infrastructure.Validations.PassengerValidations;
using Infrastructure.Validations.ShipValidations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services.Models.CruiseModels.RequestModels;
using Services.Models.PassengerModels.RequestModels;
using Services.Models.ShipModels.RequestModels;
using Services.Validations.CruiseValidations;
using System.Collections.Generic;

namespace Services.Configuration
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(
            this IServiceCollection serviceCollection,
            IConfigurationRoot configuration)
        {
            serviceCollection.AddDbContext<CascadeCruisesContext>(x => x.UseSqlServer(configuration[AppSettingsConstants.ConnectionString]));

            serviceCollection.AddScoped<IQueryHandler<GetShipInformationQuery, IList<Ship>>, GetShipInformationQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetCruiseByIdQuery, Cruise>, GetCruiseByIdQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetCruiseInformationQuery, IList<Cruise>>, GetCruiseInformationQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetShipByIdQuery, Ship>, GetShipByIdQueryHandler>();

            serviceCollection.AddScoped<IQueryHandler<GetCabinClassesQuery, IList<CabinClass>>>(
                serviceProvider => new DatabaseQueryDurationLogDecorator<GetCabinClassesQuery, IList<CabinClass>>(
                    serviceProvider.GetService<ILogger<GetCabinClassesQuery>>(),
                    new GetCabinClassesQueryHandler(serviceProvider.GetService<CascadeCruisesContext>())));

            serviceCollection.AddScoped<IQueryHandler<GetPortsQuery, IList<Port>>, GetPortsQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetPassengerReservationQuery, IList<PassengerReservation>>, GetPassengerReservationQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetCruisesProfitsQuery, IList<CruiseProfit>>, GetCruisesProfiteQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetShipByMaxRoomsCountQuery, IList<ShipByMaxRoomsCount>>, GetShipByMaxRoomsCountQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetShipInformationWithPortsQuery, IList<ShipInformationWithPorts>>, GetShipInformationWithPortsQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetPassengersAgeAboveSixtyQuery, IList<PassengerAgeAboveSixty>>, GetPassengersAgeAboveSixtyQueryHandler>();

            serviceCollection.AddScoped<ICommandHandler<InsertCruiseCommand>>(
                serviceProvider => new DeadlockRetryCommandHandlerDecorator<InsertCruiseCommand>(
                    new InsertCruiseCommandHandler(serviceProvider.GetService<CascadeCruisesContext>())));

            serviceCollection.AddScoped<ICommandHandler<InsertShipCommand>>(
                serviceProvider => new DeadlockRetryCommandHandlerDecorator<InsertShipCommand>(
                    new InsertShipCommandHandler(serviceProvider.GetService<CascadeCruisesContext>())));

            serviceCollection.AddScoped<ICommandHandler<InsertPassengerCommand>>(
                serviceProvider => new DeadlockRetryCommandHandlerDecorator<InsertPassengerCommand>(
                    new InsertPassengerCommandHandler(serviceProvider.GetService<CascadeCruisesContext>())));

            serviceCollection.AddScoped<ICommandHandler<UpdateCruiseCommand>, UpdateCruiseCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<UpdateShipCommand>, UpdateShipCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<UpdatePassengerCommand>, UpdatePassengerCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DeleteCruiseCommand>, DeleteCruiseCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DeletePassengerCommand>, DeletePassengerCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler<DeleteShipCommand>, DeleteShipCommandHandler>();

            serviceCollection.AddScoped<IValidation<CruiseInsertRequestModel>, InsertCruiseRequestModelValidation>();
            serviceCollection.AddScoped<IValidation<CruiseModfiyRequestModel>, CruiseModfiyRequestModelValidation>();
            serviceCollection.AddScoped<IValidation<ShipInsertRequestModel>, ShipInsertRequestModelValidation>();
            serviceCollection.AddScoped<IValidation<PassengerInsertRequestModel>, PassengerInsertRequestModelValidation>();

            return serviceCollection;
        }
    }
}
