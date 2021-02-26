using CQS_Demo.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.CruiseModels.RequestModels;
using Services.Models.ReportsModel.RequestModels;
using Services.Models.ReportsModel.ResponseModels;
using Services.Models.ShipModels.RequestModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CascadeCruises.Controllers
{
    [Route("api/report")]
    public class ReportController : BaseController
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all the cruises profits.
        /// </summary>
        /// <remarks>
        /// API that retrieves all the cruises profits from database.
        /// </remarks>
        /// <returns>Returns list of all the cruises profits and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("profits")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<CruiseProfitResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCruisesProfits()
        {
            IEnumerable<CruiseProfitResponseModel> cruiseProfits = await _mediator.Send(new CruiseProfitsRequestModel());
            return this.Ok(cruiseProfits);
        }

        /// <summary>
        /// Retrieves the cruise passengers who are above sixty by CruiseId.
        /// </summary>
        /// <remarks>
        /// API that retrieves the cruise passengers who are above sixty from database by given CruiseId.
        /// </remarks>
        /// <param name="id">The id of the cruise</param>  
        /// <returns>Returns list of all passengers who are above sixty and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<PassengerAgeAboveSixtyResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPassengerAgeAboveSixtyByCruiseId(int id)
        {
            IEnumerable<PassengerAgeAboveSixtyResponseModel> passengerAgeAboveSixtyResponse = await _mediator.Send(new PassengerAgeAboveSixtyByCruiseIdRequestModel(id));
            return this.Ok(passengerAgeAboveSixtyResponse);
        }

        /// <summary>
        /// Retrieves classification of ships with most rooms.
        /// </summary>
        /// <remarks>
        /// API that retrieves classification of ships with most rooms from database.
        /// </remarks>
        /// <returns>Returns classification of ships with most rooms and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("ship/max-rooms-count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ShipByMaxRoomsCountResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetShipByMaxRoomsCount()
        {
            IEnumerable<ShipByMaxRoomsCountResponseModel> shipByMaxRoomsCountResponse = await _mediator.Send(new ShipByMaxRoomsCountRequestModel());
            return this.Ok(shipByMaxRoomsCountResponse);
        }

        /// <summary>
        /// Retrieves ship information with ports.
        /// </summary>
        /// <remarks>
        /// API that retrieves ship information with ports from database.
        /// </remarks>
        /// <returns>Returns ship information with ports and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("ship/info")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ShipInformationWithPortsResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetShipInformationWithPorts()
        {
            IEnumerable<ShipInformationWithPortsResponseModel> shipInformationWithPortsResponse = await _mediator.Send(new ShipInformationWithPortsRequestModel());
            return this.Ok(shipInformationWithPortsResponse);
        }
    }
}
