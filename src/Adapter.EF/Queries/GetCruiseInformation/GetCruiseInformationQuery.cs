using Core.Entities;
using Core.Queries;
using System;
using System.Collections.Generic;

namespace Adapter.EF.Queries.GetCruiseInformation
{
    public class GetCruiseInformationQuery : IQuery<IList<Cruise>>
    {
        public GetCruiseInformationQuery()
            : this(DateTime.Now)
        { }

        protected GetCruiseInformationQuery(DateTime currentDate)
        {
            CurrentDate = currentDate;
        }

        public DateTime CurrentDate { get; }
    }
}
