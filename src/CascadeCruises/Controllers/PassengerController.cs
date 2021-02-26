using CQS_Demo.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.PassengerModels.RequestModels;
using Services.Models.PassengerModels.ResponseModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CascadeCruises.Controllers
{
    [Route("api/passenger")]
    public class PassengerController : BaseController
    {
        private readonly IMediator _mediator;

        public PassengerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all the Passenger reservations by given id.
        /// </summary>
        /// <remarks>
        /// API that retrieves all the Passenger reservations from database by given id.
        /// </remarks>
        /// <param name="id">The id of the passenger</param>  
        /// <returns>Returns list of all the Passenger reservations and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<PassengerReservationResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPassengerReservationById(int id)
        {
            IEnumerable<PassengerReservationResponseModel> passengers = await _mediator.Send(new PassengerReservationByIdRequestModel(id));
            return this.Ok(passengers);
        }

        /// <summary>
        /// Insert passenger.
        /// </summary>
        /// <remarks>
        /// API that insert passenger in database.
        /// </remarks>
        /// <response code="200">Request completed successfully.</response>
        /// <response code="400">Request could not be understood by the server.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertPassenger([FromBody] PassengerInsertRequestModel model)
        {
            await _mediator.Send(model);
            return this.NoContent();
        }

        /// <summary>
        /// Update Passenger information.
        /// </summary>
        /// <remarks>
        /// API that update passenger information existing in database.
        /// </remarks>
        /// <response code="204">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        /// <response code="400">Request could not be understood by the server.</response>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePassenger([FromBody] PassengerResponseModel model)
        {
            await _mediator.Send(model);
            return this.NoContent();
        }

        /// <summary>
        /// Delete passenger.
        /// </summary>
        /// <remarks>
        /// API that delete existing passenger in database by given Id.
        /// </remarks>
        /// <param name="id">The id of the passenger</param>  
        /// <response code="204">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            await _mediator.Send(new DeletePassengerByIdRequestModel(id));
            return this.NoContent();
        }
    }
}
