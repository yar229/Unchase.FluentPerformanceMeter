﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Unchase.PerformanceMeter.TestWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [SwaggerTag("Unchase.PerformanceMeter Test WebAPI Controller")]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValuesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            PerformanceMeter<ValuesController>.SetMethodCallsCacheTime(5);
        }

        /// <summary>
        /// Get methods performance info.
        /// </summary>
        /// <returns>Returns methods performance info.</returns>
        /// <response code="200">Returns methods performance info.</response>
        [HttpGet("GetPerformanceInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerRequestResponseExamples.GetPerformanceInfoResponse200Example))]
        [IgnoreMethodPerformance]
        public ActionResult<IPerformanceInfo> GetPerformanceInfo()
        {
            return Ok(PerformanceMeter<ValuesController>.GetPerformanceInfo());
        }

        [HttpGet("TestGet")]
        public ActionResult<string> PublicTestGetMethod()
        {
            using (PerformanceMeter<ValuesController>.Watching(nameof(PublicTestGetMethod)).WithHttpContextAccessor(_httpContextAccessor).Start())
            {
                return "value";
            }
        }

        [HttpPost("TestPost")]
        public ActionResult<string> PublicPostMethod([FromBody] string value)
        {
            using (PerformanceMeter<ValuesController>.Watching(nameof(PublicPostMethod)).WithCaller("Test caller").Start())
            {
                return Ok(value);
            }
        }
    }
}