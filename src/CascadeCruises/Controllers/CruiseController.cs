using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.CruiseModels.RequestModels;
using Services.Models.CruiseModels.ResponseModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CQS_Demo.Controllers
{
    [Route("api/cruise")]
    public class CruiseController : BaseController
    {
        private readonly IMediator _mediator;

        public CruiseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all the cruises that are not started.
        /// </summary>
        /// <remarks>
        /// API that retrieves all the cruises from database that are not yet started.
        /// </remarks>
        /// <returns>Returns list of all the cruises and thier information.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<CruiseResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCruises()
        {
            IEnumerable<CruiseResponseModel> response = await _mediator.Send(new CruisesRequestModel());
            return this.Ok(response);
        }

        /// <summary>
        /// Retrieves cruise by given id.
        /// </summary>
        /// <remarks>
        /// API that retrieves cruise from database by given id.
        /// </remarks>
        /// <param name="id">The id of the cruise</param>  
        /// <returns>Returns cruise information.</returns>
        /// <response code="200">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CruiseResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCruiseById(int id)
        {
            CruiseResponseModel response = await _mediator.Send(new CruiseByIdRequestModel(id));
            return this.Ok(response);
        }

        /// <summary>
        /// Insert cruise.
        /// </summary>
        /// <remarks>
        /// API that insert cruise in database.
        /// </remarks>
        /// <response code="200">Request completed successfully.</response>
        /// <response code="400">Request could not be understood by the server.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertCruise([FromBody] CruiseInsertRequestModel model)
        {
            await _mediator.Send(model);
            return this.NoContent();
        }

        /// <summary>
        /// Update cruise.
        /// </summary>
        /// <remarks>
        /// API that update existing cruise in database.
        /// </remarks>
        /// <response code="204">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        /// <response code="400">Request could not be understood by the server.</response>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCruise([FromBody] CruiseModfiyRequestModel model)
        {
            await _mediator.Send(model);
            return this.NoContent();
        }

        /// <summary>
        /// Delete cruise.
        /// </summary>
        /// <remarks>
        /// API that delete existing cruise in database by given Id.
        /// </remarks>
        /// <param name="id">The id of the cruise</param>  
        /// <response code="204">Request completed successfully.</response>
        /// <response code="404">The requested resource does not exist on the server.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCruise(int id)
        {
            await _mediator.Send(new DeleteCruiseRequestModel(id));
            return this.NoContent();
        }
    }
}
