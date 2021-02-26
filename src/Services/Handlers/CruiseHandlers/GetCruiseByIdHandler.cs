using Adapter.EF.Queries.GetCruiseById;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.CruiseModels.RequestModels;
using Services.Models.CruiseModels.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CruiseHandlers
{
    public class GetCruiseByIdHandler : IRequestHandler<CruiseByIdRequestModel, CruiseResponseModel>
    {
        private readonly IQueryHandler<GetCruiseByIdQuery, Cruise> _getCruiseByIdQueryHandler;

        public GetCruiseByIdHandler(IQueryHandler<GetCruiseByIdQuery, Cruise> getCruiseByIdQueryHandler)
        {
            _getCruiseByIdQueryHandler = getCruiseByIdQueryHandler;
        }

        public async Task<CruiseResponseModel> Handle(CruiseByIdRequestModel request, CancellationToken cancellationToken)
        {
            Cruise cruise = await _getCruiseByIdQueryHandler.HandleAsync(new GetCruiseByIdQuery(request.Id), cancellationToken);
            return new CruiseResponseModel(cruise);
        }
    }
}
