using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.CabinModels.RequestModels;
using Services.Models.CabinModels.ResponseModels;
using Services.Models.PortModels.RequestModels;
using Services.Models.PortModels.ResponseModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CQS_Demo.Controllers
{
    public class NomenclatureController : BaseController
    {
        private readonly IMediator _mediator;

        public NomenclatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all the cabin classes.
        /// </summary>
        /// <remarks>
        /// API that retrieves all the cabin classes from database.
        /// </remarks>
        /// <returns>Returns list of all the cabin classes.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("cabin-class")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<CabinClassResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCabinClasses()
        {
            IEnumerable<CabinClassResponseModel> response = await _mediator.Send(new CabinClassesRequestModel());
            return this.Ok(response);
        }

        /// <summary>
        /// Retrieves all the ports.
        /// </summary>
        /// <remarks>
        /// API that retrieves all the ports from database.
        /// </remarks>
        /// <returns>Returns list of all the ports.</returns>
        /// <response code="200">Request completed successfully.</response>
        [HttpGet("ports")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<PortsResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPorts()
        {
            IEnumerable<PortsResponseModel> ports = await _mediator.Send(new PortsRequestModel());
            return this.Ok(ports);
        }
    }
}
