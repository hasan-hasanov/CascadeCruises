using Adapter.EF.Queries.GetCabinClasses;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.CabinModels.RequestModels;
using Services.Models.CabinModels.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.NomenclatureHandlers
{
    public class GetCabinClassesHandler : IRequestHandler<CabinClassesRequestModel, IEnumerable<CabinClassResponseModel>>
    {
        private readonly IQueryHandler<GetCabinClassesQuery, IList<CabinClass>> _getCabinClassesQueryHandler;

        public GetCabinClassesHandler(IQueryHandler<GetCabinClassesQuery, IList<CabinClass>> getCabinClassesQueryHandler)
        {
            _getCabinClassesQueryHandler = getCabinClassesQueryHandler;
        }

        public async Task<IEnumerable<CabinClassResponseModel>> Handle(CabinClassesRequestModel request, CancellationToken cancellationToken)
        {
            IList<CabinClass> cabinClasses = await _getCabinClassesQueryHandler.HandleAsync(new GetCabinClassesQuery(), cancellationToken);
            return cabinClasses.Select(c => new CabinClassResponseModel(c)).ToList();
        }
    }
}
