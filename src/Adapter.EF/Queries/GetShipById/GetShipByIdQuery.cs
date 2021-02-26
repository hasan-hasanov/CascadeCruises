using Core.Entities;
using Core.Queries;

namespace Adapter.EF.Queries.GetShipById
{
    public class GetShipByIdQuery : IQuery<Ship>
    {
        public GetShipByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
