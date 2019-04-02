using System.Collections.Generic;
using System.Net;
using Delivery.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<DeliveryBlock>> GetDeliveryBlocks()
        {
            var data = RandomData.GetRandomBlocks(30);

            data.SortBlocks();

            return Ok(data);
        }
    }
}