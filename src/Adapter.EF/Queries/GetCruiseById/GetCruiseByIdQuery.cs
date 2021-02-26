using Core.Entities;
using Core.Queries;

namespace Adapter.EF.Queries.GetCruiseById
{
    public class GetCruiseByIdQuery : IQuery<Cruise>
    {
        public GetCruiseByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
