using CQS_Demo.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.ShipModels.RequestModels;
using Services.Models.ShipModels.ResponseModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CascadeCruises.Controllers
{
    [Route("api/ship")]
    public class ShipController : BaseController
    {
        private readonly IMediator _mediator;

        public ShipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all the ships.
        /// </summary>
        /// <remarks>
        /// API that retrieves all the ships from database.
        /// </remarks>
        /// <returns>Returns list of all the ships and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ShipResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetShips()
        {
            IEnumerable<ShipResponseModel> shipsResponse = await _mediator.Send(new ShipsRequestModel());
            return this.Ok(shipsResponse);
        }

        /// <summary>
        /// Retrieves ship by given id.
        /// </summary>
        /// <remarks>
        /// API that retrieves ship from database by given id.
        /// </remarks>
        /// <param name="id">The id of the ship</param>  
        /// <returns>Returns ship information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ShipResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetShipById(int id)
        {
            ShipResponseModel shipResponse = await _mediator.Send(new ShipByIdRequestModel(id));
            return this.Ok(shipResponse);
        }

        /// <summary>
        /// Insert ship.
        /// </summary>
        /// <remarks>
        /// API that insert ship in database.
        /// </remarks>
        /// <response code="200">Request completed successfully.</response>
        /// <response code="400">Request could not be understood by the server.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertShip([FromBody] ShipInsertRequestModel model)
        {
            await _mediator.Send(model);
            return this.NoContent();
        }

        /// <summary>
        /// Update ship.
        /// </summary>
        /// <remarks>
        /// API that update existing ship in database.
        /// </remarks>
        /// <response code="204">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        /// <response code="400">Request could not be understood by the server.</response>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShip([FromBody] ShipModifyRequestModel model)
        {
            await _mediator.Send(model);
            return this.NoContent();
        }

        /// <summary>
        /// Delete ship.
        /// </summary>
        /// <remarks>
        /// API that delete existing ship in database by given Id.
        /// </remarks>
        /// <param name="id">The id of the ship</param>  
        /// <response code="204">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteShip(int id)
        {
            await _mediator.Send(new DeleteShipRequestModel(id));
            return this.NoContent();
        }
    }
}
